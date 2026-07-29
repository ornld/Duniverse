// The boot storm, drawn on a worker thread.
//
// It used to run on the main thread and it stuttered, badly, about three quarters of the way
// through a load. Nothing about the animation was wrong: starting the Blazor runtime is
// synchronous main-thread work, and while it runs requestAnimationFrame does not fire at all.
// Smoothing the motion cannot help with that. A frozen thread draws nothing, whatever the
// maths says.
//
// So the storm was moved off that thread. An OffscreenCanvas is handed over here once, this
// worker owns it, and its frames go to the compositor without the main thread being involved.
// The page can block for as long as it likes now and the sand keeps blowing at full rate,
// which is the entire point: the animation exists to cover that wait, so it cannot be the
// thing the wait interrupts.
//
// The main thread still sends the load percentage across, but only as a target. Intensity is
// eased toward it here, so a page too busy to post an update for half a second produces a
// storm that keeps building smoothly rather than one that steps whenever news arrives.

let canvas = null;
let ctx = null;
let w = 0;
let h = 0;
let dpr = 1;

let intensity = 0;
let target = 0;
let clearing = 0;
let clearFrom = 0;
let clearSpan = 0;
let clearingActive = false;
let running = false;

let grains = [];
let members = [];
let bucketStyle = [];

const PALETTE = ["#f4c07c", "#e0a458", "#e0a458", "#c97f3d", "#a05c22", "#8a4a1a", "#ffdf9e"];
const SIZE_TIERS = 3;
const ALPHA_TIERS = 3;
const BUCKETS = PALETTE.length * SIZE_TIERS * ALPHA_TIERS;

function build(grainCount) {
    bucketStyle = [];
    for (let c = 0; c < PALETTE.length; c++) {
        for (let s = 0; s < SIZE_TIERS; s++) {
            for (let a = 0; a < ALPHA_TIERS; a++) {
                bucketStyle[(c * SIZE_TIERS + s) * ALPHA_TIERS + a] = {
                    color: PALETTE[c],
                    width: (0.5 + s * 0.45) * dpr,
                    alpha: 0.24 + a * 0.26
                };
            }
        }
    }

    grains = [];
    for (let i = 0; i < grainCount; i++) {
        const g = {};
        g.x = Math.random() * w;
        g.y = Math.random() * h;
        g.px = g.x;
        g.py = g.y;
        g.vy = (0.15 + Math.random() * 0.5) * dpr;

        const sizeTier = (Math.random() * SIZE_TIERS) | 0;
        const alphaTier = (Math.random() * ALPHA_TIERS) | 0;
        const colour = Math.random() < 0.05
            ? PALETTE.length - 1
            : (Math.random() * (PALETTE.length - 1)) | 0;
        g.b = (colour * SIZE_TIERS + sizeTier) * ALPHA_TIERS + alphaTier;
        g.carry = (1.55 - sizeTier * 0.3) * (0.55 + Math.random() * 0.9);
        grains.push(g);
    }

    // Shuffled so that any prefix of the array is a fair sample of every bucket. The active
    // count is a prefix, so without this the storm would gain colours in creation order.
    for (let i = grains.length - 1; i > 0; i--) {
        const j = (Math.random() * (i + 1)) | 0;
        const t = grains[i]; grains[i] = grains[j]; grains[j] = t;
    }

    // Which grains sit in which bucket, worked out once, so a frame touches each grain twice:
    // once to move it, once to draw it. Drawing per bucket means one path and one stroke for
    // every colour, width and opacity combination rather than one per grain.
    members = [];
    for (let b = 0; b < BUCKETS; b++) {
        members.push([]);
    }
    for (let i = 0; i < grains.length; i++) {
        members[grains[i].b].push(i);
    }
}

let last = 0;
// Counted so the page can ask, from a console, whether this thread is still drawing while the
// main one is blocked. That question is the entire reason the storm lives out here, and it is
// not answerable by looking at the screen: a blocked page cannot screenshot itself.
let frames = 0;

function frame(now) {
    if (!running) {
        return;
    }

    if (!last) {
        last = now;
    }
    const raw = now - last;
    last = now;

    // Movement measured in time rather than frames, so the storm holds its pace through an
    // uneven tick. Clamped, so a long gap stretches into a gust instead of teleporting the
    // field, which the streaks render as motion blur for free.
    const dt = Math.min(raw / 16.667, 4);

    // Eased toward whatever the page last reported. This is what keeps the build smooth even
    // when the main thread goes quiet for a while.
    intensity += (target - intensity) * Math.min(1, 0.06 * dt);

    if (clearingActive) {
        clearing = Math.min(1, (now - clearFrom) / clearSpan);
        if (clearing >= 1) {
            clearingActive = false;
            self.postMessage({ type: "cleared" });
        }
    }

    const gust =
        0.5 * Math.sin(now * 0.00055) +
        0.3 * Math.sin(now * 0.0016 + 2.1) +
        0.2 * Math.sin(now * 0.00037 + 4.4);

    const shaped = intensity * intensity;
    const base = 0.5 + shaped * 14 + clearing * 30;
    const wind = base * (0.55 + 0.45 * (gust * 0.5 + 0.5)) * dpr;
    const active = Math.max(24, Math.round(grains.length * (0.12 + shaped * 0.88)));

    for (let i = 0; i < active; i++) {
        const g = grains[i];
        g.px = g.x;
        g.py = g.y;
        g.x += (wind * g.carry + (Math.random() - 0.5) * 0.4 * dpr) * dt;
        g.y += (g.vy * (1 - clearing * 0.8) + (Math.random() - 0.5) * 0.25 * dpr) * dt;

        if (g.x > w + 8 * dpr || g.y > h + 8 * dpr) {
            if (clearing > 0.35) {
                // Once the storm is breaking, what leaves stays gone. The air thinning out
                // is the clear; nothing is faded under a blanket.
                g.px = g.x;
                continue;
            }
            // Carried round rather than respawned. Returning every grain to the upwind edge
            // drags the whole population into a band there within one crossing, and the rest
            // of the screen empties out. Wrapping keeps the spread the field already has.
            g.x -= w + 16 * dpr;
            g.y = Math.random() * h;
            g.px = g.x;
            g.py = g.y;
        }
    }

    ctx.clearRect(0, 0, w, h);
    ctx.lineCap = "round";

    const stretch = 0.9 + shaped * 1.6 + clearing * 5;
    const fade = 1 - clearing * 0.15;

    for (let b = 0; b < BUCKETS; b++) {
        const list = members[b];
        let drew = false;

        for (let k = 0; k < list.length; k++) {
            const i = list[k];
            if (i >= active) {
                continue;
            }
            const g = grains[i];
            if (g.px === g.x && g.py === g.y) {
                continue;
            }
            if (!drew) {
                ctx.beginPath();
                drew = true;
            }
            ctx.moveTo(g.px + (g.px - g.x) * stretch, g.py + (g.py - g.y) * stretch);
            ctx.lineTo(g.x, g.y);
        }

        if (drew) {
            const style = bucketStyle[b];
            ctx.strokeStyle = style.color;
            ctx.lineWidth = style.width;
            ctx.globalAlpha = style.alpha * fade;
            ctx.stroke();
        }
    }

    ctx.globalAlpha = 1;
    frames++;
    started = true;
    schedule();
}

// Frames are driven by requestAnimationFrame where it works, and by a plain timer where it
// does not, decided by watching rather than by feature detection.
//
// A worker's requestAnimationFrame exists here but is driven by the placeholder canvas's
// rendering, so it simply never fires if that canvas is not being drawn: detached from the
// document, fully hidden, whatever. Feature detection cannot tell the difference, because the
// function is present either way and just stays silent. So the first frame is raced against a
// timer, and if rAF has not delivered by then the loop switches to the timer for good.
//
// The timer is a perfectly good driver here. Movement is measured in elapsed time, so uneven
// spacing costs nothing, and this thread has nothing else competing for it.
let useTimer = false;
let started = false;

function schedule() {
    if (useTimer || typeof self.requestAnimationFrame !== "function") {
        setTimeout(function () { frame(performance.now()); }, 16);
        return;
    }

    self.requestAnimationFrame(frame);

    if (!started) {
        setTimeout(function () {
            if (!started && running) {
                useTimer = true;
                frame(performance.now());
            }
        }, 150);
    }
}

self.onmessage = function (event) {
    const data = event.data || {};

    if (data.type === "init") {
        canvas = data.canvas;
        dpr = data.dpr || 1;
        w = canvas.width;
        h = canvas.height;
        ctx = canvas.getContext("2d");
        if (!ctx) {
            self.postMessage({ type: "failed" });
            return;
        }
        build(data.grains || 600);
        running = true;
        schedule();
        return;
    }

    if (data.type === "intensity") {
        const n = Number(data.value);
        if (Number.isFinite(n)) {
            target = Math.max(0, Math.min(1, n));
        }
        return;
    }

    if (data.type === "clear") {
        // Snapped to full before breaking, so a clear that arrives during a fast load still
        // reads as a storm ending rather than a breeze stopping.
        target = 1;
        intensity = 1;
        clearFrom = performance.now();
        clearSpan = Math.max(120, data.ms || 800);
        clearing = 0;
        clearingActive = true;
        return;
    }

    if (data.type === "stats") {
        self.postMessage({ type: "stats", frames: frames, at: performance.now() });
        return;
    }

    if (data.type === "stop") {
        running = false;
        self.close();
    }
};

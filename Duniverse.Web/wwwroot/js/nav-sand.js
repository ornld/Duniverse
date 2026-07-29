// The blowing sand in the Index dropdown and the first-visit ritual. I wanted sand,
// not snow. Snow falls straight down; sand gets carried sideways in gusts. Grains blow
// in from the upwind side, ride a shared wind that surges and dies (three sine waves
// at different speeds, so the gusts never quite repeat), and slowly sink until they
// settle and fade out. A moving grain draws as a streak along its path, a settled one
// as a dot. Small grains catch the wind harder than heavy ones, and a rare brighter
// glint stands in for the spice. Faded grains respawn upwind after a short pause, so
// the effect keeps going as long as the panel stays open. The loop watches
// canvas.isConnected and stops itself once Blazor removes the panel. The canvas is
// sized for devicePixelRatio so grains stay sharp on retina screens, and the whole
// thing skips itself for anyone with reduced motion turned on.
window.duneNav = {
    sandSettle: function (canvas) {
        if (!canvas || window.matchMedia("(prefers-reduced-motion: reduce)").matches) {
            return;
        }

        const ctx = canvas.getContext("2d");
        const dpr = window.devicePixelRatio || 1;
        const rect = canvas.getBoundingClientRect();
        canvas.width = rect.width * dpr;
        canvas.height = rect.height * dpr;
        const w = canvas.width;
        const h = canvas.height;

        // Spice colors. The bright ones are rarer, which makes the drift feel deeper.
        const palette = ["#f4c07c", "#e0a458", "#e0a458", "#c97f3d", "#a05c22", "#8a4a1a"];

        function spawn(grain, now, initial) {
            // Grains come in two ways: over the top, or straight through the upwind
            // edge at any height. Without the edge entries, the wind sweeps everything
            // out the far side before it can sink and the bottom of the panel stays
            // empty.
            if (Math.random() < 0.55) {
                grain.x = (Math.random() * 1.1 - 0.35) * w;
                grain.y = -Math.random() * h * 0.5;
            } else {
                grain.x = -Math.random() * 0.12 * w;
                grain.y = Math.random() * h * 0.8;
            }
            grain.px = grain.x;
            grain.py = grain.y;
            grain.vy = (0.3 + Math.random() * 0.65) * dpr;
            grain.size = (0.6 + Math.random() * 1.2) * dpr;
            // Light grains catch the wind more than heavy ones, so one gust turns
            // into layers moving at different speeds.
            grain.carry = 1.55 - (grain.size / dpr - 0.6) * 0.7;
            const glint = Math.random() < 0.05;
            grain.color = glint ? "#ffdf9e" : palette[(Math.random() * palette.length) | 0];
            grain.alpha = glint ? 0.5 + Math.random() * 0.35 : 0.15 + Math.random() * 0.55;
            // Each grain picks a believable settling spot below wherever it came in.
            grain.settleY = Math.min(h * 0.95, Math.max(grain.y, 0) + h * (0.15 + Math.random() * 0.55));
            grain.restFrames = 0;
            // The first wave arrives all at once. After that, respawns pause only
            // briefly, so there's always a full haze of sand in the air. The calm wind
            // is what keeps it readable, not fewer grains.
            grain.startAt = now + (initial ? 0 : 400 + Math.random() * 1400);
            return grain;
        }

        const grains = [];
        const count = Math.round(rect.width / 0.75);
        const t0 = performance.now();
        for (let i = 0; i < count; i++) {
            grains.push(spawn({}, t0, true));
        }

        function frame(now) {
            if (!canvas.isConnected) {
                return;
            }

            // The wind every grain shares, always blowing the same way: a steady push
            // plus gusts that come and go. Tuned to a gentle sift, not a storm. The
            // sideways pull is what sells it as sand, not raw speed.
            const gust =
                0.5 * Math.sin(now * 0.00055) +
                0.3 * Math.sin(now * 0.0016 + 2.1) +
                0.2 * Math.sin(now * 0.00037 + 4.4);
            const wind = (0.35 + 1.15 * (gust * 0.5 + 0.5)) * dpr;

            ctx.clearRect(0, 0, w, h);
            ctx.lineCap = "round";

            for (const g of grains) {
                if (now < g.startAt) {
                    continue;
                }

                if (g.restFrames === 0 && g.y < g.settleY) {
                    g.px = g.x;
                    g.py = g.y;
                    // A little turbulence, never backwards: the jitter roughens the
                    // path without pushing a grain against the wind.
                    g.x += wind * g.carry + (Math.random() - 0.5) * 0.3 * dpr;
                    g.y += g.vy + (Math.random() - 0.5) * 0.2 * dpr;
                    if (g.x > w + 4 * dpr) {
                        spawn(g, now, false);
                        continue;
                    }
                    if (g.y >= g.settleY) {
                        g.restFrames = 1;
                    }
                } else if (g.restFrames > 0) {
                    g.restFrames++;
                }

                let a = g.alpha;
                if (g.restFrames > 0) {
                    a = g.alpha * Math.max(0, 1 - g.restFrames / 45);
                    if (a <= 0.01) {
                        spawn(g, now, false);
                        continue;
                    }
                }

                ctx.globalAlpha = a;
                if (g.restFrames > 0) {
                    // Settled grains are just dots.
                    ctx.fillStyle = g.color;
                    ctx.fillRect(g.x, g.y, g.size, g.size);
                } else {
                    // Flying grains stretch along their own path, so the faster one
                    // moves the longer its streak. Gusts draw long lines, lulls shrink
                    // back toward dots.
                    ctx.strokeStyle = g.color;
                    ctx.lineWidth = g.size;
                    ctx.beginPath();
                    ctx.moveTo(g.px + (g.px - g.x) * 0.9, g.py + (g.py - g.y) * 0.9);
                    ctx.lineTo(g.x, g.y);
                    ctx.stroke();
                }
            }

            ctx.globalAlpha = 1;
            requestAnimationFrame(frame);
        }

        requestAnimationFrame(frame);
    },

    // The boot storm. Same grains and the same gusting wind as sandSettle above, but it
    // builds instead of drifting: the caller feeds it an intensity from 0 to 1 and the
    // storm answers with more grains, harder wind and longer streaks. Boot progress is
    // what drives it, so the weather IS the loading bar rather than decoration next to
    // one.
    //
    // The choreography is not only for looks. The build-up runs while the runtime is
    // decompressing on the main thread, and slow sparse sand is the one motion that
    // survives being hitched: a dropped frame in a lazy drift reads as a lull in the
    // wind. The dense part and the clear both happen after boot, when the thread is
    // free and every frame is cheap.
    //
    // Returns a handle. Every method on it is safe to call at any time, including after
    // stop, because the page that owns this cannot afford to be careful.
    sandStorm: function (canvas) {
        const inert = {
            setIntensity: function () { },
            clear: function () { return Promise.resolve(); },
            stop: function () { }
        };

        if (!canvas || !canvas.getContext || window.matchMedia("(prefers-reduced-motion: reduce)").matches) {
            return inert;
        }

        const ctx = canvas.getContext("2d");
        if (!ctx) {
            return inert;
        }

        // Capped rather than taken as given. At full device ratio this canvas is five
        // million pixels to clear and composite every frame, and the grains are hairlines:
        // there is nothing in a 1px streak that a third pixel of precision improves. The
        // cap costs no visible quality and buys back close to half the fill cost on a
        // retina screen, which is exactly the budget the decoder is competing for.
        const dpr = Math.min(window.devicePixelRatio || 1, 1.5);
        const w = canvas.width = window.innerWidth * dpr;
        const h = canvas.height = window.innerHeight * dpr;

        const palette = ["#f4c07c", "#e0a458", "#e0a458", "#c97f3d", "#a05c22", "#8a4a1a", "#ffdf9e"];

        const maxGrains = Math.min(900, Math.round(window.innerWidth / 1.6));

        // Grains are sorted into buckets that share a colour, a width and an opacity, so a
        // frame can draw each bucket as one path instead of stroking every grain on its own.
        // Measured on a desktop: 900 individual strokes cost 0.28ms a frame, 63 batched ones
        // cost 0.07ms. Four times cheaper, but both are noise against a 16.7ms budget, so
        // this is insurance for weak hardware rather than the reason the storm ever
        // stuttered. That was the runtime decompressing on the same thread, which is what
        // the delta timing and the budget below actually answer.
        //
        // The quantising is invisible: three widths and three opacities per colour still
        // layers the same way to the eye.
        const SIZE_TIERS = 3;
        const ALPHA_TIERS = 3;
        const bucketCount = palette.length * SIZE_TIERS * ALPHA_TIERS;
        const bucketStyle = [];
        for (let c = 0; c < palette.length; c++) {
            for (let s = 0; s < SIZE_TIERS; s++) {
                for (let a = 0; a < ALPHA_TIERS; a++) {
                    bucketStyle[(c * SIZE_TIERS + s) * ALPHA_TIERS + a] = {
                        color: palette[c],
                        width: (0.5 + s * 0.45) * dpr,
                        alpha: 0.24 + a * 0.26
                    };
                }
            }
        }

        let intensity = 0;
        let clearing = 0;
        let running = true;

        function spawn(g) {
            g.x = Math.random() * w;
            g.y = Math.random() * h;
            g.px = g.x;
            g.py = g.y;
            g.vy = (0.15 + Math.random() * 0.5) * dpr;

            const sizeTier = (Math.random() * SIZE_TIERS) | 0;
            const alphaTier = (Math.random() * ALPHA_TIERS) | 0;
            // The glint colour sits last in the palette and stays rare.
            const colour = Math.random() < 0.05
                ? palette.length - 1
                : (Math.random() * (palette.length - 1)) | 0;
            g.b = (colour * SIZE_TIERS + sizeTier) * ALPHA_TIERS + alphaTier;

            // Light grains ride the wind harder, and the spread is what breaks the
            // population out of travelling as one pack.
            g.carry = (1.55 - sizeTier * 0.3) * (0.55 + Math.random() * 0.9);
            return g;
        }

        const grains = [];
        for (let i = 0; i < maxGrains; i++) {
            grains.push(spawn({}));
        }

        // Which grains belong to which bucket, worked out once. Drawing walks these lists
        // rather than scanning every grain per bucket, so a frame still touches each grain
        // exactly twice: once to move it, once to draw it.
        const members = [];
        for (let b = 0; b < bucketCount; b++) {
            members.push([]);
        }
        for (let i = 0; i < grains.length; i++) {
            members[grains[i].b].push(i);
        }

        // Grain index doubles as the activity switch, so the count can rise and fall with
        // the load. Shuffling first means any prefix of the array is a fair sample of every
        // bucket, instead of the storm gaining colours in the order they were created.
        for (let i = grains.length - 1; i > 0; i--) {
            const j = (Math.random() * (i + 1)) | 0;
            const t = grains[i]; grains[i] = grains[j]; grains[j] = t;
        }
        for (let b = 0; b < bucketCount; b++) {
            members[b].length = 0;
        }
        for (let i = 0; i < grains.length; i++) {
            members[grains[i].b].push(i);
        }

        let last = 0;
        let frameCost = 16.7;
        // Trimmed automatically when frames start running long, which during boot is
        // exactly when the decoder has the thread. Recovers slowly once it lets go.
        let budget = 1;

        function frame(now) {
            if (!running || !canvas.isConnected) {
                return;
            }

            if (!last) {
                last = now;
            }
            const raw = now - last;
            last = now;

            // Movement is measured in time, not in frames. Per-frame steps meant a stall
            // did not merely drop frames, it slowed the whole storm down and sped it back
            // up, and that wobble reads worse than the missing frames ever did. Clamped so
            // a long stall stretches into a gust rather than teleporting the field, which
            // the streaks render as motion blur for free: a bigger step simply draws a
            // longer line.
            const dt = Math.min(raw / 16.667, 4);

            frameCost += (raw - frameCost) * 0.1;
            if (frameCost > 24) {
                budget = Math.max(0.45, budget - 0.02);
            } else if (frameCost < 15) {
                budget = Math.min(1, budget + 0.008);
            }

            const gust =
                0.5 * Math.sin(now * 0.00055) +
                0.3 * Math.sin(now * 0.0016 + 2.1) +
                0.2 * Math.sin(now * 0.00037 + 4.4);

            const shaped = intensity * intensity;
            const base = 0.5 + shaped * 14 + clearing * 30;
            const wind = base * (0.55 + 0.45 * (gust * 0.5 + 0.5)) * dpr;

            const active = Math.max(24, Math.round(maxGrains * (0.12 + shaped * 0.88) * budget));

            for (let i = 0; i < active; i++) {
                const g = grains[i];
                g.px = g.x;
                g.py = g.y;
                g.x += (wind * g.carry + (Math.random() - 0.5) * 0.4 * dpr) * dt;
                g.y += (g.vy * (1 - clearing * 0.8) + (Math.random() - 0.5) * 0.25 * dpr) * dt;

                if (g.x > w + 8 * dpr || g.y > h + 8 * dpr) {
                    if (clearing > 0.35) {
                        g.px = g.x;
                        continue;
                    }
                    // Carried round rather than respawned. Putting every grain back just
                    // off the upwind edge drags the whole population into a band there
                    // within one crossing, however much their speeds vary, and the rest of
                    // the screen empties. Wrapping preserves the spread the field already
                    // has. px follows so the wrap frame does not draw one long streak
                    // straight across the canvas.
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

            for (let b = 0; b < bucketCount; b++) {
                const list = members[b];
                const style = bucketStyle[b];
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
                    ctx.strokeStyle = style.color;
                    ctx.lineWidth = style.width;
                    ctx.globalAlpha = style.alpha * fade;
                    ctx.stroke();
                }
            }

            ctx.globalAlpha = 1;
            requestAnimationFrame(frame);
        }

        requestAnimationFrame(frame);

        return {
            setIntensity: function (value) {
                const n = Number(value);
                intensity = Number.isFinite(n) ? Math.max(0, Math.min(1, n)) : intensity;
            },

            clear: function (ms) {
                const span = Math.max(120, ms || 800);
                return new Promise(function (resolve) {
                    const from = performance.now();
                    (function step(now) {
                        if (!running) {
                            resolve();
                            return;
                        }
                        clearing = Math.min(1, (now - from) / span);
                        if (clearing >= 1) {
                            resolve();
                            return;
                        }
                        requestAnimationFrame(step);
                    })(from);
                });
            },

            stop: function () {
                running = false;
            }
        };
    }
};

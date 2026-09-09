// The hunt. Blazor mounts the stage, imports this once and hands me the element. From
// then on every frame is mine, and nothing crosses back into .NET during a round.

const STORAGE_KEY = "duniverse.desert.v1";

// Retina gets two device pixels per CSS pixel and no more. The board is small, so the
// fill is cheap, and a third pixel of precision buys nothing a ridge can show.
const DPR_CAP = 2;

// Roughly this many cells whatever the screen, so forty segments read as a wall on a
// phone and on a monitor alike.
const TARGET_CELLS = 340;

// Milliseconds per cell. Each meal shaves a little off until the floor, so the early
// desert is lazy and the late coil is urgent.
const TICK_START = 165;
const TICK_STEP = 2.2;
const TICK_FLOOR = 88;
const START_LENGTH = 3;

// The worm's body as a share of a cell, and the pitch of its rings. Two rings a cell
// reads as a segmented hose at every board size I tried.
const TUBE = 0.7;
const RING = 0.5;

const NORTH = { x: 0, y: -1 };
const SOUTH = { x: 0, y: 1 };
const EAST = { x: 1, y: 0 };
const WEST = { x: -1, y: 0 };

// The nav sand's own spice colors, so thrown grains match the rest of the site.
const SAND = ["#f4c07c", "#e0a458", "#e0a458", "#c97f3d", "#a05c22"];
const TAU = Math.PI * 2;

let stage = null;
let canvas = null;
let ctx = null;
let sandBox = null;
let hud = null;
let observer = null;
let rafId = 0;
let running = false;

let dpr = 1;
let viewW = 0;
let viewH = 0;
let cols = 0;
let rows = 0;
let cell = 0;
let ox = 0;
let oy = 0;
let rim = 0;
let terrain = null;
let sprites = null;
let seed = 1;

// intro, hunting, paused, dying, fallen.
let state = "intro";
let snake = [];
let prev = [];
let grew = false;
let dir = EAST;
let queue = [];
let tickMs = TICK_START;
let acc = 0;

// The round's own clock. It only runs while the hunt does, so a pause never lets the
// thopter teleport to its landing.
let clock = 0;
let lastFrame = 0;

let food = null;
let thopters = [];
let launchAt = 0;
let tally = 0;
let best = 0;
let rings = [];
let grains = [];
let fell = null;

// The strike: 0 with the head down and the mouth shut, 1 reared over a soldier with
// the mouth open. slamAt marks the moment it came down.
let strike = 0;
let slamAt = -1e9;

// ---- lifecycle -------------------------------------------------------------------

export function start(el) {
    if (!el) {
        return;
    }
    stage = el;
    canvas = el.querySelector(".desert-canvas");
    sandBox = el.querySelector(".desert-sand");
    if (!canvas || !sandBox) {
        return;
    }
    ctx = canvas.getContext("2d");

    hud = {
        tally: el.querySelector('[data-desert="tally"]'),
        best: el.querySelector('[data-desert="best"]'),
        panels: {
            intro: el.querySelector('[data-desert="intro"]'),
            paused: el.querySelector('[data-desert="paused"]'),
            fallen: el.querySelector('[data-desert="fallen"]')
        },
        cause: el.querySelector('[data-desert="cause"]'),
        fallenTally: el.querySelector('[data-desert="fallen-tally"]'),
        fallenBest: el.querySelector('[data-desert="fallen-best"]'),
        record: el.querySelector('[data-desert="record"]')
    };

    best = loadBest();
    setCount(hud.best, best);

    running = true;
    state = "intro";
    seed = (Date.now() & 0xffff) | 1;
    layout();
    bind();
    lastFrame = performance.now();
    rafId = requestAnimationFrame(frame);
}

export function stop() {
    running = false;
    cancelAnimationFrame(rafId);
    unbind();
    if (state === "hunting" || state === "paused") {
        saveBest();
    }
    stage = null;
    canvas = null;
    ctx = null;
    terrain = null;
    sprites = null;
    hud = null;
}

// ---- input -----------------------------------------------------------------------

let pointerStart = null;

function bind() {
    window.addEventListener("keydown", onKey);
    document.addEventListener("visibilitychange", onVisibility);
    canvas.addEventListener("pointerdown", onPointerDown);
    canvas.addEventListener("pointerup", onPointerUp);
    canvas.addEventListener("pointercancel", onPointerCancel);
    stage.addEventListener("click", onClick);

    // The sand box, not the canvas: the canvas is sized from the box, so watching the
    // canvas itself would report its own resize back to me.
    if (typeof ResizeObserver === "function") {
        observer = new ResizeObserver(() => layout());
        observer.observe(sandBox);
    } else {
        window.addEventListener("resize", layout);
    }
}

function unbind() {
    window.removeEventListener("keydown", onKey);
    document.removeEventListener("visibilitychange", onVisibility);
    window.removeEventListener("resize", layout);
    if (canvas) {
        canvas.removeEventListener("pointerdown", onPointerDown);
        canvas.removeEventListener("pointerup", onPointerUp);
        canvas.removeEventListener("pointercancel", onPointerCancel);
    }
    if (stage) {
        stage.removeEventListener("click", onClick);
    }
    if (observer) {
        observer.disconnect();
        observer = null;
    }
}

function onKey(e) {
    if (!running || e.metaKey || e.ctrlKey || e.altKey) {
        return;
    }
    const turn = keyDirection(e.key);
    if (turn) {
        if (state === "hunting") {
            enqueue(turn);
            e.preventDefault();
        }
        return;
    }
    if (e.key === "Escape") {
        if (state === "hunting") {
            pause();
        } else if (state === "paused") {
            resume();
        }
        return;
    }
    if (e.key === " " || e.key === "Enter") {
        // A key with focus fires its own click on these, and beginning twice would
        // reset a hunt mid-stride.
        if (e.target instanceof HTMLElement && e.target.closest("button, a")) {
            return;
        }
        if (state === "intro" || state === "fallen") {
            begin();
        } else if (state === "paused") {
            resume();
        }
        e.preventDefault();
    }
}

function keyDirection(key) {
    switch (key) {
        case "ArrowUp": case "w": case "W": return NORTH;
        case "ArrowDown": case "s": case "S": return SOUTH;
        case "ArrowLeft": case "a": case "A": return WEST;
        case "ArrowRight": case "d": case "D": return EAST;
        default: return null;
    }
}

function onClick(e) {
    const button = e.target instanceof HTMLElement ? e.target.closest("[data-desert]") : null;
    if (!button) {
        return;
    }
    const action = button.getAttribute("data-desert");
    if (action === "begin" || action === "again") {
        begin();
    } else if (action === "resume") {
        resume();
    }
}

// A swipe on the sand is the whole phone control: the longer axis picks the direction.
function onPointerDown(e) {
    if (!e.isPrimary) {
        return;
    }
    pointerStart = { x: e.clientX, y: e.clientY };
}

function onPointerUp(e) {
    if (!pointerStart || !e.isPrimary) {
        return;
    }
    const dx = e.clientX - pointerStart.x;
    const dy = e.clientY - pointerStart.y;
    pointerStart = null;
    if (state !== "hunting" || Math.max(Math.abs(dx), Math.abs(dy)) < 18) {
        return;
    }
    if (Math.abs(dx) > Math.abs(dy)) {
        enqueue(dx > 0 ? EAST : WEST);
    } else {
        enqueue(dy > 0 ? SOUTH : NORTH);
    }
}

function onPointerCancel() {
    pointerStart = null;
}

function onVisibility() {
    if (document.visibilityState === "hidden" && state === "hunting") {
        pause();
    }
}

// Two turns can wait in the queue, so a quick double turn lands as two bends. Each one
// is checked against the bend before it: no doubling back, no repeats.
function enqueue(turn) {
    const against = queue.length ? queue[queue.length - 1] : dir;
    if (turn.x === -against.x && turn.y === -against.y) {
        return;
    }
    if (turn.x === against.x && turn.y === against.y) {
        return;
    }
    if (queue.length < 2) {
        queue.push(turn);
    }
}

// ---- the board -------------------------------------------------------------------

function layout() {
    if (!running || !measure()) {
        return;
    }

    // The grid only changes size between rounds. Mid-hunt a resize just rescales the
    // cells, so a turned phone never drops the worm outside its own desert.
    if (state === "intro" || state === "fallen") {
        chooseBoard();
    }
    fit();
}

// Reads the sand box fresh. A new round measures again on its own: the observer only
// reports while the page is drawing, and a tab that was hidden may hold a stale size.
function measure() {
    const rect = sandBox.getBoundingClientRect();
    if (rect.width < 10 || rect.height < 10) {
        return false;
    }
    viewW = rect.width;
    viewH = rect.height;
    dpr = Math.min(window.devicePixelRatio || 1, DPR_CAP);
    canvas.width = Math.round(viewW * dpr);
    canvas.height = Math.round(viewH * dpr);
    return true;
}

function chooseBoard() {
    const w = viewW - 28;
    const h = viewH - 28;
    const guess = Math.sqrt(w * h / TARGET_CELLS);
    cols = Math.max(8, Math.floor(w / guess));
    rows = Math.max(8, Math.floor(h / guess));
}

function fit() {
    cell = Math.max(6, Math.floor(Math.min((viewW - 28) / cols, (viewH - 28) / rows)));
    ox = Math.round((viewW - cols * cell) / 2);
    oy = Math.round((viewH - rows * cell) / 2);
    rim = Math.max(10, Math.round(cell * 0.4));
    paintTerrain();
    buildSprites();
}

function cellCenter(c) {
    return { x: ox + (c.x + 0.5) * cell, y: oy + (c.y + 0.5) * cell };
}

// A small seeded generator, so a resize repaints the same dunes instead of a new desert.
function mulberry32(a) {
    return function () {
        a |= 0;
        a = a + 0x6D2B79F5 | 0;
        let t = Math.imul(a ^ a >>> 15, 1 | a);
        t = t + Math.imul(t ^ t >>> 7, 61 | t) ^ t;
        return ((t ^ t >>> 14) >>> 0) / 4294967296;
    };
}

// A canvas in CSS units at the device ratio, so every sprite lands pixel sharp.
function makeCanvas(w, h) {
    const c = document.createElement("canvas");
    c.width = Math.max(1, Math.ceil(w * dpr));
    c.height = Math.max(1, Math.ceil(h * dpr));
    const g = c.getContext("2d");
    g.scale(dpr, dpr);
    return { c, g };
}

// ---- the terrain -----------------------------------------------------------------

// Painted once per fit onto its own canvas. A frame then copies it in one call and
// pays only for what moves, so the dunes can carry as much detail as I like.
function paintTerrain() {
    const rnd = mulberry32(seed);
    terrain = document.createElement("canvas");
    terrain.width = canvas.width;
    terrain.height = canvas.height;
    const t = terrain.getContext("2d");
    t.scale(dpr, dpr);

    const bw = cols * cell;
    const bh = rows * cell;

    // The rock beyond the wall, with a little grain so it reads as stone, not paint.
    t.fillStyle = "#15100c";
    t.fillRect(0, 0, viewW, viewH);
    const cracks = Math.round(viewW * viewH / 900);
    for (let i = 0; i < cracks; i++) {
        const x = rnd() * viewW;
        const y = rnd() * viewH;
        t.fillStyle = rnd() < 0.5 ? "rgba(90,70,50,0.10)" : "rgba(0,0,0,0.25)";
        t.fillRect(x, y, 1 + rnd() * 3, 1);
    }

    drawWall(t, rnd, bw, bh);

    // The sand itself, painted over the wall's inner half so the board edge stays clean.
    const sand = t.createLinearGradient(ox, oy, ox + bw, oy + bh);
    sand.addColorStop(0, "#d4a367");
    sand.addColorStop(0.5, "#c69257");
    sand.addColorStop(1, "#ae7843");
    t.fillStyle = sand;
    t.fillRect(ox, oy, bw, bh);

    t.save();
    t.beginPath();
    t.rect(ox, oy, bw, bh);
    t.clip();
    t.lineCap = "round";
    t.lineJoin = "round";

    // Broad drift first: soft pools of lighter and darker sand, so the ground undulates
    // before any crest is drawn on it.
    const pools = 5 + ((rnd() * 4) | 0);
    for (let i = 0; i < pools; i++) {
        const cx = ox + rnd() * bw;
        const cy = oy + rnd() * bh;
        const r = cell * (3 + rnd() * 5);
        const g = t.createRadialGradient(cx, cy, 0, cx, cy, r);
        g.addColorStop(0, rnd() < 0.5 ? "rgba(255,226,178,0.13)" : "rgba(88,48,18,0.13)");
        g.addColorStop(1, "rgba(0,0,0,0)");
        t.fillStyle = g;
        t.fillRect(cx - r, cy - r, r * 2, r * 2);
    }

    // Dunes: a bright crest, a soft lit windward face up and left of it, and a steeper
    // shadowed slip face down and right, the way they read from the air.
    const crests = Math.max(4, Math.round((bw + bh) / 230));
    for (let i = 0; i < crests; i++) {
        drawCrest(t, crestPath(rnd, i, crests, bw, bh));
    }

    drawRipples(t, rnd, bw, bh);

    // Melange on the sand: rust streaks where a spice blow has come through.
    const veins = 3 + ((rnd() * 3) | 0);
    for (let i = 0; i < veins; i++) {
        drawSpiceVein(t, rnd, bw, bh);
    }

    // Speckle for grain, and a dot at every cell corner faint enough to pass as texture.
    // The dots are what let a player judge one bend from the next.
    const specks = Math.round(bw * bh / 30);
    for (let i = 0; i < specks; i++) {
        t.fillStyle = rnd() < 0.5 ? "rgba(255,228,176,0.12)" : "rgba(80,45,15,0.12)";
        t.fillRect(ox + rnd() * bw, oy + rnd() * bh, 1, 1);
    }
    t.fillStyle = "rgba(60,35,12,0.17)";
    for (let cx = 1; cx < cols; cx++) {
        for (let cy = 1; cy < rows; cy++) {
            t.fillRect(ox + cx * cell - 0.5, oy + cy * cell - 0.5, 1, 1);
        }
    }

    // Shade against the wall's foot on every side, then a dark line where sand meets rock.
    const foot = cell * 0.7;
    const sides = [
        [ox, oy, ox + foot, oy], [ox + bw, oy, ox + bw - foot, oy],
        [ox, oy, ox, oy + foot], [ox, oy + bh, ox, oy + bh - foot]
    ];
    for (const [x0, y0, x1, y1] of sides) {
        const g = t.createLinearGradient(x0, y0, x1, y1);
        g.addColorStop(0, "rgba(30,16,6,0.45)");
        g.addColorStop(1, "rgba(30,16,6,0)");
        t.fillStyle = g;
        t.fillRect(ox, oy, bw, bh);
    }
    const vignette = t.createRadialGradient(ox + bw / 2, oy + bh / 2, Math.min(bw, bh) * 0.3,
        ox + bw / 2, oy + bh / 2, Math.max(bw, bh) * 0.7);
    vignette.addColorStop(0, "rgba(40,22,8,0)");
    vignette.addColorStop(1, "rgba(40,22,8,0.28)");
    t.fillStyle = vignette;
    t.fillRect(ox, oy, bw, bh);
    t.restore();

    t.strokeStyle = "rgba(20,12,6,0.7)";
    t.lineWidth = 2;
    t.strokeRect(ox + 1, oy + 1, bw - 2, bh - 2);
}

// A crest line across the board: a long swell with a shorter ripple riding on it and a
// slight tilt, so no two run parallel.
function crestPath(rnd, i, n, bw, bh) {
    const y0 = oy + (i + 0.5) / n * bh + (rnd() - 0.5) * cell * 1.2;
    const a1 = cell * (0.8 + rnd() * 1.8);
    const f1 = (0.4 + rnd() * 0.7) * TAU / bw;
    const p1 = rnd() * TAU;
    const a2 = cell * (0.2 + rnd() * 0.6);
    const f2 = (1.2 + rnd() * 1.6) * TAU / bw;
    const p2 = rnd() * TAU;
    const tilt = (rnd() - 0.5) * 0.25;
    const pts = [];
    for (let x = ox - cell; x <= ox + bw + cell; x += 8) {
        pts.push([x, y0 + Math.sin(x * f1 + p1) * a1 + Math.sin(x * f2 + p2) * a2 + (x - ox) * tilt]);
    }
    return pts;
}

// A gradient across a stroke is not a thing canvas can do, so each face is a stack of
// strokes stepped away from the crest, each fainter than the last.
function drawCrest(t, pts) {
    const steps = 6;
    const slip = cell * 1.15;
    for (let k = 0; k < steps; k++) {
        const f = k / steps;
        t.strokeStyle = "rgba(66,36,12," + (0.075 * (1 - f)) + ")";
        t.lineWidth = slip / steps * 2;
        tracePoints(t, pts, slip * f * 0.28, slip * f * 0.96);
        t.stroke();
    }
    const wind = cell * 0.8;
    for (let k = 0; k < steps; k++) {
        const f = k / steps;
        t.strokeStyle = "rgba(255,236,196," + (0.06 * (1 - f)) + ")";
        t.lineWidth = wind / steps * 2;
        tracePoints(t, pts, -wind * f * 0.28, -wind * f * 0.96);
        t.stroke();
    }
    t.lineWidth = Math.max(1, cell * 0.03);
    t.strokeStyle = "rgba(255,238,200,0.5)";
    tracePoints(t, pts, 0, 0);
    t.stroke();
    t.lineWidth = Math.max(1, cell * 0.02);
    t.strokeStyle = "rgba(60,32,12,0.4)";
    tracePoints(t, pts, cell * 0.02, cell * 0.06);
    t.stroke();
}

// Wind ripples over everything: a line every fifth of a cell, each with its own small
// wobble, a shadow stroke with a lit one a pixel under it.
function drawRipples(t, rnd, bw, bh) {
    const gap = Math.max(4, cell * 0.2);
    const f = (1.5 + rnd()) * TAU / bw;
    const ph = rnd() * TAU;
    t.lineWidth = 1;
    for (let y = oy + gap * (0.5 + rnd()); y < oy + bh; y += gap) {
        const amp = cell * (0.1 + rnd() * 0.08);
        const local = ph + y * 0.05;
        const pts = [];
        for (let x = ox; x <= ox + bw; x += 6) {
            pts.push([x, y + Math.sin(x * f + local) * amp + Math.sin(x * f * 3.1 + local * 1.7) * amp * 0.3]);
        }
        t.strokeStyle = "rgba(80,45,15,0.07)";
        tracePoints(t, pts, 0, 0);
        t.stroke();
        t.strokeStyle = "rgba(255,232,190,0.06)";
        tracePoints(t, pts, 0, 1);
        t.stroke();
    }
}

function drawSpiceVein(t, rnd, bw, bh) {
    const x0 = ox + rnd() * bw;
    const y0 = oy + rnd() * bh;
    const pts = [];
    let x = x0;
    let y = y0;
    let a = rnd() * TAU;
    const steps = 6 + ((rnd() * 8) | 0);
    for (let i = 0; i < steps; i++) {
        pts.push([x, y]);
        a += (rnd() - 0.5) * 1.2;
        x += Math.cos(a) * cell * 0.7;
        y += Math.sin(a) * cell * 0.7;
    }
    t.strokeStyle = "rgba(170,78,28,0.12)";
    t.lineWidth = cell * 0.55;
    tracePoints(t, pts, 0, 0);
    t.stroke();
    t.strokeStyle = "rgba(140,58,20,0.14)";
    t.lineWidth = cell * 0.16;
    tracePoints(t, pts, 0, 0);
    t.stroke();
    for (let i = 0; i < steps * 4; i++) {
        const p = pts[(rnd() * pts.length) | 0];
        t.fillStyle = rnd() < 0.5 ? "rgba(190,90,30,0.35)" : "rgba(120,45,15,0.35)";
        t.fillRect(p[0] + (rnd() - 0.5) * cell * 0.8, p[1] + (rnd() - 0.5) * cell * 0.8, 1.5, 1.5);
    }
}

// The Shield Wall: a jagged band of paler rock hugging the board, cracked and edge lit.
function drawWall(t, rnd, bw, bh) {
    const band = Math.min(rim, ox, oy);
    const step = Math.max(9, cell * 0.45);
    const pts = [];
    function edge(x0, y0, x1, y1, nx, ny) {
        const len = Math.hypot(x1 - x0, y1 - y0);
        const n = Math.max(2, Math.round(len / step));
        for (let i = 0; i < n; i++) {
            const f = i / n;
            const out = (0.35 + rnd() * 0.65) * band;
            pts.push([x0 + (x1 - x0) * f + nx * out, y0 + (y1 - y0) * f + ny * out]);
        }
    }
    edge(ox, oy, ox + bw, oy, 0, -1);
    edge(ox + bw, oy, ox + bw, oy + bh, 1, 0);
    edge(ox + bw, oy + bh, ox, oy + bh, 0, 1);
    edge(ox, oy + bh, ox, oy, -1, 0);

    t.beginPath();
    pts.forEach(([x, y], i) => i ? t.lineTo(x, y) : t.moveTo(x, y));
    t.closePath();
    t.fillStyle = "#2b211a";
    t.fill();
    t.strokeStyle = "rgba(244,192,124,0.14)";
    t.lineWidth = 1;
    t.stroke();

    const cracks = Math.round((bw + bh) / 6);
    for (let i = 0; i < cracks; i++) {
        const along = rnd();
        const side = (rnd() * 4) | 0;
        const depth = rnd() * band;
        let x, y;
        if (side === 0) { x = ox + along * bw; y = oy - depth; }
        else if (side === 1) { x = ox + bw + depth; y = oy + along * bh; }
        else if (side === 2) { x = ox + along * bw; y = oy + bh + depth; }
        else { x = ox - depth; y = oy + along * bh; }
        t.fillStyle = rnd() < 0.5 ? "rgba(0,0,0,0.35)" : "rgba(160,120,80,0.12)";
        t.fillRect(x, y, 1 + rnd() * 4, 1);
    }
}

function tracePoints(c, pts, dx, dy) {
    c.beginPath();
    for (let i = 0; i < pts.length; i++) {
        const [x, y] = pts[i];
        if (i === 0) {
            c.moveTo(x + dx, y + dy);
        } else {
            c.lineTo(x + dx, y + dy);
        }
    }
}

// ---- the sprites -----------------------------------------------------------------

// Everything with detail is baked once per board size and stamped each frame: the seam
// tiles that make the body a segmented hose, and the head with its mouth shut and open.
function buildSprites() {
    const w = cell * TUBE;
    const pitch = cell * RING;
    sprites = {
        w: w,
        pitch: pitch,
        rings: [makeRingTile(w, pitch, 0), makeRingTile(w, pitch, 1), makeRingTile(w, pitch, 2)],
        shut: makeHead(w, false),
        open: makeHead(w, true)
    };
}

// One segment of hide, head to the right: mottled pale gray, flanks darkening, a few
// grooves, and the seam at the leading edge, a dark fold with a thread of paler tissue
// behind it. The flanks fade out so the tile follows a round body.
function makeRingTile(w, d, variant) {
    const { c, g } = makeCanvas(d, w);
    const rnd = mulberry32(seed * 3 + variant * 101 + 7);

    const lateral = g.createLinearGradient(0, 0, 0, w);
    lateral.addColorStop(0, "rgba(40,38,34,0.5)");
    lateral.addColorStop(0.22, "rgba(40,38,34,0.06)");
    lateral.addColorStop(0.45, "rgba(255,253,248,0.07)");
    lateral.addColorStop(0.72, "rgba(40,38,34,0.04)");
    lateral.addColorStop(1, "rgba(40,38,34,0.55)");
    g.fillStyle = lateral;
    g.fillRect(0, 0, d, w);

    for (let i = 0; i < 10; i++) {
        g.fillStyle = rnd() < 0.55 ? "rgba(30,28,25,0.07)" : "rgba(255,255,255,0.06)";
        disc(g, d * rnd(), w * (0.1 + rnd() * 0.8), w * (0.04 + rnd() * 0.09));
        g.fill();
    }
    for (let i = 0; i < 6; i++) {
        const y = w * (0.1 + rnd() * 0.8);
        const x0 = d * rnd() * 0.6;
        const len = d * (0.1 + rnd() * 0.3);
        g.strokeStyle = rnd() < 0.6 ? "rgba(30,28,25,0.22)" : "rgba(255,255,255,0.14)";
        g.lineWidth = Math.max(0.6, w * 0.016);
        g.beginPath();
        g.moveTo(x0, y);
        g.lineTo(x0 + len, y + (rnd() - 0.5) * w * 0.04);
        g.stroke();
    }

    const fold = g.createLinearGradient(d * 0.66, 0, d * 0.9, 0);
    fold.addColorStop(0, "rgba(35,33,30,0)");
    fold.addColorStop(1, "rgba(35,33,30,0.38)");
    g.fillStyle = fold;
    g.fillRect(d * 0.66, 0, d * 0.24, w);
    g.fillStyle = "rgba(236,232,224,0.3)";
    g.fillRect(d * 0.86, 0, Math.max(0.6, d * 0.03), w);
    g.fillStyle = "rgba(45,43,39,0.6)";
    g.fillRect(d * 0.9, 0, Math.max(1, d * 0.05), w);
    g.fillStyle = "rgba(255,255,255,0.12)";
    g.fillRect(d * 0.96, 0, Math.max(0.6, d * 0.03), w);

    g.globalCompositeOperation = "destination-in";
    const taper = g.createLinearGradient(0, 0, 0, w);
    taper.addColorStop(0, "rgba(0,0,0,0)");
    taper.addColorStop(0.1, "rgba(0,0,0,1)");
    taper.addColorStop(0.9, "rgba(0,0,0,1)");
    taper.addColorStop(1, "rgba(0,0,0,0)");
    g.fillStyle = taper;
    g.fillRect(0, 0, d, w);
    g.globalCompositeOperation = "source-over";
    return c;
}

// The head, facing right: the cut end of the tube, not a ball. The flanks flare a
// little to the rim, the corners are chamfered back and the nose is nearly flat, so
// it reads as planes meeting at angles. Shut, the mouth is a ragged red crescent along
// the nose. Reared, the same cornered plate faces the eye with the cavern open in it.
function makeHead(w, open) {
    const size = w * 2.6;
    const { c, g } = makeCanvas(size, size);
    g.translate(size / 2, size / 2);
    const rnd = mulberry32(seed + (open ? 5 : 3));

    const L = open ? w * 1.3 : w * 1.25;
    const B = open ? w * 1.4 : w;
    const F = open ? w * 1.4 : w * 1.14;
    const hull = open
        ? [[-0.5, -0.36], [-0.32, -0.5], [0.32, -0.5], [0.5, -0.36], [0.5, 0.36], [0.32, 0.5], [-0.32, 0.5], [-0.5, 0.36]]
        : [[-0.5, -0.5 * B / F], [0.12, -0.5], [0.4, -0.36], [0.5, -0.12], [0.5, 0.12], [0.4, 0.36], [0.12, 0.5], [-0.5, 0.5 * B / F]];
    const shape = new Path2D();
    hull.forEach(([hx, hy], i) => {
        if (i === 0) {
            shape.moveTo(hx * L, hy * F);
        } else {
            shape.lineTo(hx * L, hy * F);
        }
    });
    shape.closePath();

    const hide = g.createRadialGradient(-L * 0.3, -F * 0.4, L * 0.1, 0, 0, L * 0.9);
    hide.addColorStop(0, "#d2cfc5");
    hide.addColorStop(0.55, "#a6a399");
    hide.addColorStop(1, "#5f5c54");
    g.fillStyle = hide;
    g.fill(shape);

    g.save();
    g.clip(shape);

    // Round it across the width like the body, then cut the planes: the near flank and
    // the lower chamfer fall into shade, the upper chamfer and the nose catch the light.
    const lateral = g.createLinearGradient(0, -F / 2, 0, F / 2);
    lateral.addColorStop(0, "rgba(35,33,30,0.5)");
    lateral.addColorStop(0.2, "rgba(35,33,30,0.06)");
    lateral.addColorStop(0.42, "rgba(255,253,248,0.1)");
    lateral.addColorStop(0.7, "rgba(35,33,30,0.05)");
    lateral.addColorStop(1, "rgba(35,33,30,0.55)");
    g.fillStyle = lateral;
    g.fillRect(-L, -F, L * 2, F * 2);

    if (!open) {
        g.fillStyle = "rgba(255,255,255,0.13)";
        g.beginPath();
        g.moveTo(L * 0.12, -F * 0.5);
        g.lineTo(L * 0.4, -F * 0.36);
        g.lineTo(L * 0.5, -F * 0.12);
        g.lineTo(L * 0.22, -F * 0.16);
        g.closePath();
        g.fill();
        g.fillStyle = "rgba(0,0,0,0.2)";
        g.beginPath();
        g.moveTo(L * 0.12, F * 0.5);
        g.lineTo(L * 0.4, F * 0.36);
        g.lineTo(L * 0.5, F * 0.12);
        g.lineTo(L * 0.22, F * 0.16);
        g.closePath();
        g.fill();
        g.fillStyle = "rgba(0,0,0,0.1)";
        g.fillRect(L * 0.4, -F, L * 0.2, F * 2);
        g.strokeStyle = "rgba(0,0,0,0.22)";
        g.lineWidth = Math.max(1, w * 0.02);
        g.beginPath();
        g.moveTo(L * 0.12, -F * 0.5);
        g.lineTo(L * 0.22, -F * 0.16);
        g.lineTo(L * 0.22, F * 0.16);
        g.lineTo(L * 0.12, F * 0.5);
        g.stroke();
    } else {
        g.fillStyle = "rgba(255,255,255,0.1)";
        g.beginPath();
        g.moveTo(-L * 0.5, -F * 0.36);
        g.lineTo(-L * 0.32, -F * 0.5);
        g.lineTo(L * 0.32, -F * 0.5);
        g.lineTo(L * 0.2, -F * 0.34);
        g.lineTo(-L * 0.2, -F * 0.34);
        g.lineTo(-L * 0.36, -F * 0.24);
        g.closePath();
        g.fill();
        g.fillStyle = "rgba(0,0,0,0.2)";
        g.beginPath();
        g.moveTo(L * 0.5, F * 0.36);
        g.lineTo(L * 0.32, F * 0.5);
        g.lineTo(-L * 0.32, F * 0.5);
        g.lineTo(-L * 0.2, F * 0.34);
        g.lineTo(L * 0.2, F * 0.34);
        g.lineTo(L * 0.36, F * 0.24);
        g.closePath();
        g.fill();
    }

    for (let i = 0; i < 30; i++) {
        g.fillStyle = rnd() < 0.5 ? "rgba(30,28,25,0.07)" : "rgba(255,255,255,0.06)";
        disc(g, (rnd() - 0.5) * L, (rnd() - 0.5) * F, w * (0.04 + rnd() * 0.1));
        g.fill();
    }
    if (!open) {
        // Seams across the top, the body's rings carrying on to the rim.
        g.strokeStyle = "rgba(40,38,34,0.3)";
        g.lineWidth = Math.max(1, w * 0.02);
        for (let k = 0; k < 3; k++) {
            const x = -L * (0.4 - k * 0.17);
            g.beginPath();
            g.moveTo(x, -F);
            g.quadraticCurveTo(x + L * 0.05, 0, x, F);
            g.stroke();
        }
    }
    g.restore();

    if (!open) {
        // The nose as a polyline from one chamfer to the other; the crescent hangs off it.
        const nose = [[0.12, -0.5], [0.4, -0.36], [0.5, -0.12], [0.5, 0.12], [0.4, 0.36], [0.12, 0.5]]
            .map(([hx, hy]) => [hx * L, hy * F]);
        const along = t => {
            const seg = Math.min(nose.length - 2, Math.floor(t * (nose.length - 1)));
            const f = t * (nose.length - 1) - seg;
            return [nose[seg][0] + (nose[seg + 1][0] - nose[seg][0]) * f, nose[seg][1] + (nose[seg + 1][1] - nose[seg][1]) * f];
        };
        const cx = L * 0.08;
        const steps = 16;
        const mouth = new Path2D();
        for (let i = 0; i <= steps; i++) {
            const [x, y] = along(0.08 + 0.84 * i / steps);
            const px = cx + (x - cx) * 0.95;
            const py = y * 0.95;
            if (i === 0) {
                mouth.moveTo(px, py);
            } else {
                mouth.lineTo(px, py);
            }
        }
        for (let i = steps; i >= 0; i--) {
            const t = i / steps;
            const [x, y] = along(0.08 + 0.84 * t);
            const f = 0.52 - 0.14 * (1 - Math.abs(2 * t - 1)) + rnd() * 0.08;
            mouth.lineTo(cx + (x - cx) * f, y * f);
        }
        mouth.closePath();
        const cavern = g.createRadialGradient(L * 0.35, 0, 0, L * 0.35, 0, L * 0.4);
        cavern.addColorStop(0, "#7a2a15");
        cavern.addColorStop(0.45, "#4a170d");
        cavern.addColorStop(1, "#22090a");
        g.fillStyle = cavern;
        g.fill(mouth);
        g.save();
        g.clip(mouth);
        const glow = g.createRadialGradient(L * 0.4, 0, 0, L * 0.4, 0, L * 0.22);
        glow.addColorStop(0, "rgba(230,115,45,0.42)");
        glow.addColorStop(1, "rgba(230,115,45,0)");
        g.fillStyle = glow;
        g.fillRect(-L, -F, L * 2, F * 2);
        g.strokeStyle = "rgba(238,232,220,0.75)";
        g.lineWidth = Math.max(0.6, w * 0.018);
        for (let k = 0; k < 16; k++) {
            const [x, y] = along(0.1 + 0.8 * (k + 0.5) / 16);
            const dx = cx - x;
            const dy = -y;
            const len = Math.hypot(dx, dy) || 1;
            const reach = w * (0.08 + rnd() * 0.07);
            g.beginPath();
            g.moveTo(cx + (x - cx) * 0.95, y * 0.95);
            g.lineTo(cx + (x - cx) * 0.95 + dx / len * reach, y * 0.95 + dy / len * reach);
            g.stroke();
        }
        g.restore();
        g.strokeStyle = "rgba(220,216,206,0.8)";
        g.lineWidth = Math.max(1, w * 0.03);
        g.beginPath();
        for (let i = 0; i <= steps; i++) {
            const [x, y] = along(0.08 + 0.84 * i / steps);
            if (i === 0) {
                g.moveTo(cx + (x - cx) * 0.95, y * 0.95);
            } else {
                g.lineTo(cx + (x - cx) * 0.95, y * 0.95);
            }
        }
        g.stroke();
    } else {
        const cx = L * 0.02;
        const mrx = L * 0.38;
        const mry = F * 0.36;
        const steps = 30;
        const mouth = new Path2D();
        for (let i = 0; i < steps; i++) {
            const a = i / steps * TAU;
            const j = 0.94 + rnd() * 0.1;
            const x = cx + Math.cos(a) * mrx * j;
            const y = Math.sin(a) * mry * j;
            if (i === 0) {
                mouth.moveTo(x, y);
            } else {
                mouth.lineTo(x, y);
            }
        }
        mouth.closePath();
        const cavern = g.createRadialGradient(cx, 0, 0, cx, 0, mrx);
        cavern.addColorStop(0, "#3a0f08");
        cavern.addColorStop(0.5, "#8a2c14");
        cavern.addColorStop(0.85, "#4a1a10");
        cavern.addColorStop(1, "#22090a");
        g.fillStyle = cavern;
        g.fill(mouth);
        g.save();
        g.clip(mouth);
        // The chemical furnace behind the teeth: a warm ring of breath.
        const glow = g.createRadialGradient(cx, 0, mrx * 0.25, cx, 0, mrx * 0.6);
        glow.addColorStop(0, "rgba(240,130,50,0)");
        glow.addColorStop(0.5, "rgba(240,130,50,0.38)");
        glow.addColorStop(1, "rgba(240,130,50,0)");
        g.fillStyle = glow;
        g.fillRect(-L, -F, L * 2, F * 2);
        g.strokeStyle = "rgba(0,0,0,0.28)";
        g.lineWidth = Math.max(1, w * 0.02);
        for (let k = 0; k < 26; k++) {
            const a = k / 26 * TAU;
            g.beginPath();
            g.moveTo(cx + Math.cos(a) * mrx * 0.98, Math.sin(a) * mry * 0.98);
            g.lineTo(cx + Math.cos(a) * mrx * 0.55, Math.sin(a) * mry * 0.55);
            g.stroke();
        }
        teeth(g, rnd, cx, mrx * 0.96, mry * 0.96, w * 0.2, 26, "rgba(236,230,218,0.85)");
        teeth(g, rnd, cx, mrx * 0.62, mry * 0.62, w * 0.12, 18, "rgba(226,218,204,0.7)");
        g.restore();
        g.strokeStyle = "rgba(222,218,208,0.85)";
        g.lineWidth = Math.max(1, w * 0.035);
        g.stroke(mouth);
    }

    // The edges: a dark line all round, and light along the top and the rim.
    g.strokeStyle = "rgba(30,28,25,0.45)";
    g.lineWidth = Math.max(1, w * 0.035);
    g.stroke(shape);
    g.strokeStyle = "rgba(255,255,255,0.22)";
    g.lineWidth = Math.max(1, w * 0.025);
    g.beginPath();
    g.moveTo(hull[0][0] * L, hull[0][1] * F);
    for (let i = 1; i <= 3; i++) {
        g.lineTo(hull[i][0] * L, hull[i][1] * F);
    }
    g.stroke();
    return { c: c, size: size };
}

// Crystalline teeth around an oval rim: milky wedges pointing into the throat, each with
// a translucent core, and a third of them throwing a glint from the tip.
function teeth(g, rnd, cx, mrx, mry, len, count, color) {
    for (let k = 0; k < count; k++) {
        const a = (k / count) * TAU + rnd() * 0.1;
        const bx = cx + Math.cos(a) * mrx;
        const by = Math.sin(a) * mry;
        const reach = len * (0.8 + rnd() * 0.4);
        const tx = bx - Math.cos(a) * reach;
        const ty = by - Math.sin(a) * reach;
        const hw = len * 0.2;
        const px = -Math.sin(a) * hw;
        const py = Math.cos(a) * hw;
        g.fillStyle = color;
        g.beginPath();
        g.moveTo(bx + px, by + py);
        g.lineTo(tx, ty);
        g.lineTo(bx - px, by - py);
        g.closePath();
        g.fill();
        g.strokeStyle = "rgba(255,255,255,0.3)";
        g.lineWidth = Math.max(0.5, len * 0.07);
        g.beginPath();
        g.moveTo(bx, by);
        g.lineTo(tx, ty);
        g.stroke();
        if (rnd() < 0.3) {
            g.fillStyle = "rgba(255,255,255,0.9)";
            disc(g, tx, ty, Math.max(0.5, len * 0.07));
            g.fill();
        }
    }
}

function disc(g, x, y, r) {
    g.beginPath();
    g.arc(x, y, r, 0, TAU);
}

// ---- the round -------------------------------------------------------------------

function begin() {
    if (state === "hunting" || state === "dying") {
        return;
    }
    seed = (Date.now() & 0xffff) | 1;
    measure();
    chooseBoard();
    fit();

    // Off along the board's long side, with a breath before the first tick, so the
    // wall is a few seconds away and there is time to see the sand before it moves.
    dir = cols >= rows ? EAST : NORTH;
    const hx = Math.floor(cols / 2) + dir.x;
    const hy = Math.floor(rows / 2) + dir.y;
    snake = [];
    for (let i = 0; i < START_LENGTH; i++) {
        snake.push({ x: hx - dir.x * i, y: hy - dir.y * i });
    }
    prev = snake.slice();
    grew = false;
    queue = [];
    tickMs = TICK_START;
    acc = -900;
    clock = 0;
    food = null;
    thopters = [];
    launchAt = 350;
    rings = [];
    grains = [];
    fell = null;
    strike = 0;
    slamAt = -1e9;
    tally = 0;
    setCount(hud.tally, 0);

    state = "hunting";
    showPanel(null);
    lastFrame = performance.now();
}

function pause() {
    if (state !== "hunting") {
        return;
    }
    state = "paused";
    showPanel("paused");
}

function resume() {
    if (state !== "paused") {
        return;
    }
    state = "hunting";
    showPanel(null);
    lastFrame = performance.now();
    const key = hud.panels.paused.querySelector("button");
    if (key) {
        key.blur();
    }
}

function tick() {
    while (queue.length) {
        const turn = queue.shift();
        if (turn.x !== -dir.x || turn.y !== -dir.y) {
            dir = turn;
            break;
        }
    }

    const head = snake[0];
    const nx = head.x + dir.x;
    const ny = head.y + dir.y;
    prev = snake.slice();

    if (nx < 0 || ny < 0 || nx >= cols || ny >= rows) {
        die("rock");
        return;
    }

    const eats = food !== null && food.x === nx && food.y === ny;

    // The tail leaves its cell this same tick, so moving into it is safe. On a meal the
    // tail stays put and the cell counts.
    const last = snake.length - 1;
    for (let i = 0; i < snake.length; i++) {
        if (i === last && !eats) {
            continue;
        }
        if (snake[i].x === nx && snake[i].y === ny) {
            die("coils");
            return;
        }
    }

    snake.unshift({ x: nx, y: ny });
    grew = eats;
    if (eats) {
        swallow();
    } else {
        snake.pop();
    }
}

function swallow() {
    const c = cellCenter(food);
    rings.push({ x: c.x, y: c.y, at: clock, span: 560, size: cell * 1.5, color: "244,192,124" });
    puff(c.x, c.y, 42, cell * 0.14, SAND);
    slamAt = clock;
    food = null;
    tally++;
    setCount(hud.tally, tally);
    if (tally > best) {
        best = tally;
        setCount(hud.best, best);
        saveBest();
    }
    tickMs = Math.max(TICK_FLOOR, tickMs - TICK_STEP);
    launchAt = clock + 280;
}

function die(cause) {
    state = "dying";
    fell = { at: clock, cause: cause, sunk: 0 };
    thopters = [];
    food = null;
    queue = [];
    strike = 0;
    saveBest();
}

function fall() {
    state = "fallen";
    hud.cause.textContent = fell.cause === "rock"
        ? "The ridge struck the rock of the Shield Wall."
        : "The ridge folded back into its own coils.";
    setCount(hud.fallenTally, tally);
    setCount(hud.fallenBest, best);
    hud.record.hidden = !(tally > 0 && tally === best);
    showPanel("fallen");
}

// ---- the ornithopter -------------------------------------------------------------

function launchThopter() {
    const target = freeCell();
    if (!target) {
        return;
    }
    const tc = cellCenter(target);
    const rnd = Math.random;
    const side = (rnd() * 4) | 0;
    const margin = cell * 2;
    let sx, sy;
    if (side === 0) { sx = rnd() * viewW; sy = -margin; }
    else if (side === 1) { sx = viewW + margin; sy = rnd() * viewH; }
    else if (side === 2) { sx = rnd() * viewW; sy = viewH + margin; }
    else { sx = -margin; sy = rnd() * viewH; }

    // It leaves the way it did not come, banking off toward another edge.
    const exitSide = (side + 1 + ((rnd() * 3) | 0)) % 4;
    let ex, ey;
    if (exitSide === 0) { ex = rnd() * viewW; ey = -margin; }
    else if (exitSide === 1) { ex = viewW + margin; ey = rnd() * viewH; }
    else if (exitSide === 2) { ex = rnd() * viewW; ey = viewH + margin; }
    else { ex = -margin; ey = rnd() * viewH; }

    const inDur = clamp(Math.hypot(tc.x - sx, tc.y - sy) * 1.6, 1200, 2100);
    thopters.push({
        cell: target,
        sx, sy, tx: tc.x, ty: tc.y, ex, ey,
        at: clock,
        inDur: inDur,
        hover: 420,
        outDur: 1300,
        curve: (rnd() - 0.5) * cell * 4,
        dropped: false,
        done: false,
        pose: { x: sx, y: sy, alt: 1, angle: Math.atan2(tc.y - sy, tc.x - sx) }
    });
}

// One craft may still be banking away when the next is called, so each flies its own
// clock and drops out of the list once it has left the screen.
function updateThopters() {
    let keep = 0;
    for (let i = 0; i < thopters.length; i++) {
        const th = thopters[i];
        updateThopter(th);
        if (!th.done) {
            thopters[keep++] = th;
        }
    }
    thopters.length = keep;
}

function updateThopter(th) {
    const t = clock - th.at;
    const p = th.pose;

    if (t < th.inDur) {
        const f = easeInOut(t / th.inDur);
        const nx = -(th.ty - th.sy);
        const ny = th.tx - th.sx;
        const len = Math.hypot(nx, ny) || 1;
        const bow = Math.sin(f * Math.PI) * th.curve;
        p.x = th.sx + (th.tx - th.sx) * f + nx / len * bow;
        p.y = th.sy + (th.ty - th.sy) * f + ny / len * bow;
        p.alt = 1 - 0.72 * easeOut(t / th.inDur);
        p.angle = Math.atan2(th.ty - th.sy, th.tx - th.sx);
        return;
    }

    if (t < th.inDur + th.hover) {
        const f = (t - th.inDur) / th.hover;
        p.x = th.tx;
        p.y = th.ty;
        p.alt = 0.28 - 0.08 * f;
        return;
    }

    if (!th.dropped) {
        th.dropped = true;
        dropSoldier(th);
    }

    const f = (t - th.inDur - th.hover) / th.outDur;
    if (f >= 1) {
        th.done = true;
        return;
    }
    const g = easeInOut(f);
    p.x = th.tx + (th.ex - th.tx) * g;
    p.y = th.ty + (th.ey - th.ty) * g;
    p.alt = 0.2 + 0.8 * easeIn(f);
    p.angle = Math.atan2(th.ey - th.ty, th.ex - th.tx);
}

// The worm may have crossed the chosen cell in the seconds since launch. If it has, the
// soldier lands on the nearest open sand and the thopter shifts a cell to match.
function dropSoldier(th) {
    let target = th.cell;
    if (occupied(target.x, target.y)) {
        target = nearestFree(target.x, target.y) || target;
        const tc = cellCenter(target);
        th.tx = tc.x;
        th.ty = tc.y;
    }
    food = { x: target.x, y: target.y, at: clock };
    const c = cellCenter(target);
    rings.push({ x: c.x, y: c.y, at: clock, span: 420, size: cell * 0.9, color: "200,180,150" });
    puff(c.x, c.y, 10, cell * 0.06, ["#d9c9a8", "#b9a98a", "#e0a458"]);
}

function occupied(x, y) {
    for (const s of snake) {
        if (s.x === x && s.y === y) {
            return true;
        }
    }
    return false;
}

function freeCell() {
    const open = [];
    const head = snake[0];
    for (let x = 0; x < cols; x++) {
        for (let y = 0; y < rows; y++) {
            // Not under the worm, and not right under its jaw either: a meal it cannot
            // miss is no hunt.
            if (!occupied(x, y) && Math.abs(x - head.x) + Math.abs(y - head.y) > 2) {
                open.push({ x, y });
            }
        }
    }
    if (!open.length) {
        return null;
    }
    return open[(Math.random() * open.length) | 0];
}

function nearestFree(x, y) {
    let bestCell = null;
    let bestDist = Infinity;
    for (let cx = 0; cx < cols; cx++) {
        for (let cy = 0; cy < rows; cy++) {
            if (occupied(cx, cy)) {
                continue;
            }
            const d = Math.abs(cx - x) + Math.abs(cy - y);
            if (d < bestDist) {
                bestDist = d;
                bestCell = { x: cx, y: cy };
            }
        }
    }
    return bestCell;
}

// ---- the frame -------------------------------------------------------------------

function frame(now) {
    if (!running) {
        return;
    }
    rafId = requestAnimationFrame(frame);

    // Clamped, so a long gap becomes one long step instead of a burst of catch-up ticks.
    const dt = Math.min(now - lastFrame, 120);
    lastFrame = now;

    if (state === "hunting") {
        clock += dt;
        acc += dt;
        while (acc >= tickMs && state === "hunting") {
            acc -= tickMs;
            tick();
        }
        if (state === "hunting") {
            if (!food && clock >= launchAt && !thopters.some(th => !th.dropped)) {
                launchThopter();
            }
            updateThopters();
            spray();
        }
    } else if (state === "dying") {
        clock += dt;
        rupture();
    }

    updateStrike(dt);
    ageGrains(dt);
    render(now);
}

function render(now) {
    if (!terrain) {
        return;
    }
    ctx.setTransform(1, 0, 0, 1, 0, 0);
    ctx.drawImage(terrain, 0, 0);
    ctx.setTransform(dpr, 0, 0, dpr, 0, 0);

    for (const th of thopters) {
        drawThopterShadow(th);
    }
    drawRings();
    if (food) {
        drawSoldier(now);
    }
    if (state === "hunting" || state === "paused") {
        drawWorm(clamp(acc / tickMs, 0, 1));
    } else if (state === "dying" || state === "fallen") {
        drawRupture();
    }
    drawGrains();
    for (const th of thopters) {
        drawThopter(th, now);
    }
}

// ---- the worm --------------------------------------------------------------------

// The body as one line through the cells, head and tail eased by how far the tick has
// come. Between ticks the body holds still: the head mounds forward, the tail sinks.
function wormPoints(alpha) {
    const n = snake.length;
    const pts = [];
    const from = prev[0] || snake[0];
    pts.push(lerpCell(from, snake[0], alpha));
    for (let i = 1; i < n; i++) {
        pts.push(cellCenter(snake[i]));
    }
    if (!grew && prev.length === n) {
        pts.push(lerpCell(prev[n - 1], snake[n - 1], alpha));
    }
    return pts;
}

function lerpCell(a, b, f) {
    const ca = cellCenter(a);
    const cb = cellCenter(b);
    return { x: ca.x + (cb.x - ca.x) * f, y: ca.y + (cb.y - ca.y) * f };
}

function headPoint() {
    return lerpCell(prev[0] || snake[0], snake[0], clamp(acc / tickMs, 0, 1));
}

// The smoothed body curve, flattened to points so the outline and the seams can be
// placed by distance along it. Head first, so distances count back from the mouth.
const flat = [];
function flattenCurve(pts) {
    flat.length = 0;
    if (!pts.length) {
        return flat;
    }
    let px = pts[0].x;
    let py = pts[0].y;
    flat.push(px, py);
    for (let i = 1; i < pts.length - 1; i++) {
        const cx = pts[i].x;
        const cy = pts[i].y;
        const ex = (pts[i].x + pts[i + 1].x) / 2;
        const ey = (pts[i].y + pts[i + 1].y) / 2;
        for (let k = 1; k <= 5; k++) {
            const t = k / 5;
            const u = 1 - t;
            flat.push(u * u * px + 2 * u * t * cx + t * t * ex, u * u * py + 2 * u * t * cy + t * t * ey);
        }
        px = ex;
        py = ey;
    }
    const last = pts[pts.length - 1];
    flat.push(last.x, last.y);
    return flat;
}

// The body's outline: the flattened curve walked at a fine step, each stop keeping its
// position, its normal, its distance from the mouth and the body's width there. The
// arrays are reused frame to frame so nothing piles up for the GC.
const outline = { n: 0, L: 0, x: [], y: [], nx: [], ny: [], s: [], w: [] };

function buildOutline() {
    let L = 0;
    for (let i = 2; i < flat.length; i += 2) {
        L += Math.hypot(flat[i] - flat[i - 2], flat[i + 1] - flat[i - 1]);
    }
    const step = Math.max(2, cell * 0.15);
    let n = 0;
    let next = 0;
    let dist = 0;
    let lnx = 0;
    let lny = 1;
    for (let i = 2; i < flat.length; i += 2) {
        const x0 = flat[i - 2];
        const y0 = flat[i - 1];
        const dx = flat[i] - x0;
        const dy = flat[i + 1] - y0;
        const len = Math.hypot(dx, dy);
        if (len === 0) {
            continue;
        }
        lnx = -dy / len;
        lny = dx / len;
        while (next <= dist + len) {
            const f = (next - dist) / len;
            outline.x[n] = x0 + dx * f;
            outline.y[n] = y0 + dy * f;
            outline.nx[n] = lnx;
            outline.ny[n] = lny;
            outline.s[n] = next;
            outline.w[n] = widthAt(next, L);
            n++;
            next += step;
        }
        dist += len;
    }
    // The tip itself, so the tail always reaches the end of its cell.
    outline.x[n] = flat[flat.length - 2];
    outline.y[n] = flat[flat.length - 1];
    outline.nx[n] = lnx;
    outline.ny[n] = lny;
    outline.s[n] = L;
    outline.w[n] = widthAt(L, L);
    n++;
    outline.n = n;
    outline.L = L;
}

// The width along the body: near full behind the head, thinning a little down the
// length, then drawing in over the last third to a blunt tail. A faint swell every
// ring keeps it a hose rather than a pipe.
function widthAt(s, L) {
    const W = sprites.w;
    let w = W * (1 - 0.1 * s / Math.max(L, 1));
    const tailStart = Math.max(0, L - Math.max(cell * 1.6, L * 0.3));
    if (s > tailStart && L > tailStart) {
        const f = (s - tailStart) / (L - tailStart);
        w *= 1 - 0.72 * Math.pow(f, 1.4);
    }
    w *= 1 + 0.04 * Math.sin(s / (cell * RING) * Math.PI);
    return Math.max(w, cell * 0.12);
}

// One closed path around the outline, the width scaled and the whole thing shifted.
// The body is the plain one; the bands of shade, light and sand are the rest.
function bandPath(dx, dy, scale) {
    const p = new Path2D();
    const n = outline.n;
    for (let i = 0; i < n; i++) {
        const hw = outline.w[i] * scale / 2;
        const x = outline.x[i] + dx + outline.nx[i] * hw;
        const y = outline.y[i] + dy + outline.ny[i] * hw;
        if (i === 0) {
            p.moveTo(x, y);
        } else {
            p.lineTo(x, y);
        }
    }
    for (let i = n - 1; i >= 0; i--) {
        const hw = outline.w[i] * scale / 2;
        p.lineTo(outline.x[i] + dx - outline.nx[i] * hw, outline.y[i] + dy - outline.ny[i] * hw);
    }
    p.closePath();
    return p;
}

// The body. Sand banked along the flanks, a cast shadow, the pale hide, then a shaded
// flank and a lit one clipped inside it to round it, and the seam tiles stamped along
// it, each turned to the body and scaled to the width where it sits.
function drawTube(pts) {
    const W = sprites.w;
    flattenCurve(pts);
    buildOutline();

    ctx.fillStyle = "rgba(240,212,166,0.12)";
    ctx.fill(bandPath(-cell * 0.03, -cell * 0.03, 1.7));
    ctx.fillStyle = "rgba(240,212,166,0.14)";
    ctx.fill(bandPath(-cell * 0.02, -cell * 0.02, 1.4));
    ctx.fillStyle = "rgba(110,70,30,0.1)";
    ctx.fill(bandPath(cell * 0.08, cell * 0.12, 1.55));
    ctx.fillStyle = "rgba(45,30,15,0.45)";
    ctx.fill(bandPath(cell * 0.09, cell * 0.13, 1.06));

    const body = bandPath(0, 0, 1);
    ctx.fillStyle = "#aeaba2";
    ctx.fill(body);

    ctx.save();
    ctx.clip(body);
    ctx.fillStyle = "rgba(60,58,52,0.5)";
    ctx.fill(bandPath(W * 0.2, W * 0.24, 0.7));
    ctx.fillStyle = "rgba(242,240,234,0.42)";
    ctx.fill(bandPath(-W * 0.16, -W * 0.19, 0.62));
    ctx.fillStyle = "rgba(255,255,255,0.22)";
    ctx.fill(bandPath(-W * 0.09, -W * 0.11, 0.2));

    const pitch = sprites.pitch;
    const step = Math.max(2, cell * 0.15);
    let k = 0;
    for (let s = pitch * 0.9; s < outline.L; s += pitch) {
        const i = Math.min(outline.n - 1, Math.round(s / step));
        const tile = sprites.rings[k++ % 3];
        const w = outline.w[i];
        // The tile's own x axis points at the head, so the normal turns it the other way.
        ctx.setTransform(-dpr * outline.ny[i], dpr * outline.nx[i], -dpr * outline.nx[i], -dpr * outline.ny[i],
            dpr * outline.x[i], dpr * outline.y[i]);
        ctx.drawImage(tile, -pitch / 2, -w / 2, pitch, w);
    }
    ctx.setTransform(dpr, 0, 0, dpr, 0, 0);
    ctx.restore();
}

function headAngle() {
    if (flat.length >= 4) {
        return Math.atan2(flat[1] - flat[3], flat[0] - flat[2]);
    }
    return Math.atan2(dir.y, dir.x);
}

function drawWorm(alpha) {
    if (!sprites) {
        return;
    }
    const pts = wormPoints(alpha);
    drawTube(pts);

    const since = clock - slamAt;
    const slam = since < 160 ? 0.22 * (1 - since / 160) : 0;
    drawHead(pts[0], headAngle(), 1 + 0.5 * strike - slam, strike);
}

// The head stamped over the front of the body. Reared, it rises toward the eye: the
// shadow slides out from under it and the open mouth fades in over the shut dome.
function drawHead(p, angle, scale, open) {
    const W = sprites.w;
    ctx.save();
    ctx.translate(p.x + cell * 0.1 + open * cell * 0.4, p.y + cell * 0.13 + open * cell * 0.45);
    ctx.rotate(angle);
    ctx.fillStyle = "rgba(45,30,15,0.42)";
    ctx.beginPath();
    ctx.ellipse(0, 0, W * 0.7 * scale, W * 0.62 * scale, 0, 0, TAU);
    ctx.fill();
    ctx.restore();

    ctx.save();
    ctx.translate(p.x, p.y);
    ctx.rotate(angle);
    ctx.scale(scale, scale);
    const shut = sprites.shut;
    const opened = sprites.open;
    if (open < 1) {
        ctx.globalAlpha = 1 - open;
        ctx.drawImage(shut.c, -shut.size / 2, -shut.size / 2, shut.size, shut.size);
    }
    if (open > 0) {
        ctx.globalAlpha = open;
        ctx.drawImage(opened.c, -opened.size / 2, -opened.size / 2, opened.size, opened.size);
    }
    ctx.globalAlpha = 1;
    ctx.restore();
}

// A soldier straight ahead draws the strike: the head rears over the next two cells
// and comes down as it takes him. Turning away lets it sink back.
function foodAhead() {
    if (!food || !snake.length) {
        return 0;
    }
    const h = snake[0];
    for (let k = 1; k <= 2; k++) {
        if (food.x === h.x + dir.x * k && food.y === h.y + dir.y * k) {
            return 1;
        }
    }
    return 0;
}

function updateStrike(dt) {
    // A pause holds the pose it froze in; only the sand stops pouring.
    const target = state === "hunting" || state === "paused" ? foodAhead() : 0;
    const rate = target > strike ? 0.16 : 0.09;
    strike += (target - strike) * Math.min(1, rate * dt / 16.7);
    if (strike < 0.002) {
        strike = 0;
    }
    // Sand pouring off the reared head.
    if (strike > 0.35 && state === "hunting" && sprites) {
        const p = headPoint();
        const radius = sprites.w * 0.6 * (1 + 0.55 * strike);
        for (let i = 0; i < 2; i++) {
            const a = Math.random() * TAU;
            addGrain(p.x + Math.cos(a) * radius, p.y + Math.sin(a) * radius,
                Math.cos(a) * cell * 0.05, Math.sin(a) * cell * 0.05 + cell * 0.03,
                300 + Math.random() * 250, SAND[(Math.random() * SAND.length) | 0]);
        }
    }
}

// Grains flung off the head every frame, the wake of a ridge pushing through sand.
function spray() {
    if (!snake.length || acc < 0) {
        return;
    }
    const p = headPoint();
    for (let i = 0; i < 2; i++) {
        const side = i === 0 ? 1 : -1;
        const vx = -dir.y * side * (0.4 + Math.random() * 0.9) + dir.x * 0.3;
        const vy = dir.x * side * (0.4 + Math.random() * 0.9) + dir.y * 0.3;
        addGrain(p.x + (Math.random() - 0.5) * cell * 0.4, p.y + (Math.random() - 0.5) * cell * 0.4,
            vx * cell * 0.06, vy * cell * 0.06, 320 + Math.random() * 260, SAND[(Math.random() * SAND.length) | 0]);
    }
}

// The death: the sand gives way segment by segment from the head back, each cell
// sinking into a dark hollow with a burst of grains as it goes.
function rupture() {
    const t = clock - fell.at;
    const n = snake.length;
    const perCell = Math.min(60, 700 / n);
    const should = Math.min(n, Math.floor(t / perCell) + 1);
    while (fell.sunk < should) {
        const c = cellCenter(snake[fell.sunk]);
        puff(c.x, c.y, 14, cell * 0.09, SAND);
        fell.sunk++;
    }
    if (fell.sunk >= n && t > perCell * n + 900) {
        fall();
    }
}

function drawRupture() {
    if (!sprites) {
        return;
    }
    const n = snake.length;
    if (fell.sunk < n) {
        const pts = snake.slice(fell.sunk).map(cellCenter);
        drawTube(pts);
        if (fell.sunk === 0) {
            drawHead(pts[0], headAngle(), 1, 0);
        }
    }
    for (let i = 0; i < fell.sunk; i++) {
        const c = cellCenter(snake[i]);
        const g = ctx.createRadialGradient(c.x, c.y, 0, c.x, c.y, cell * 0.5);
        g.addColorStop(0, "rgba(40,20,6,0.55)");
        g.addColorStop(1, "rgba(40,20,6,0)");
        ctx.fillStyle = g;
        ctx.beginPath();
        ctx.arc(c.x, c.y, cell * 0.5, 0, TAU);
        ctx.fill();
    }
}

// ---- soldiers and thopters -------------------------------------------------------

// A Sardaukar from above: helmet, shoulders in gray plate, boots, and the drawn blade
// catching the light. He is small against the worm, which is the point.
function drawSoldier(now) {
    const c = cellCenter(food);
    const s = cell;
    const land = easeOut(clamp((clock - food.at) / 260, 0, 1));
    ctx.save();
    ctx.translate(c.x, c.y);
    ctx.scale(land, land);

    ctx.fillStyle = "rgba(25,12,4,0.38)";
    ctx.beginPath();
    ctx.ellipse(s * 0.05, s * 0.06, s * 0.21, s * 0.13, 0, 0, TAU);
    ctx.fill();

    ctx.fillStyle = "#26262a";
    ctx.beginPath();
    ctx.ellipse(-s * 0.06, s * 0.1, s * 0.04, s * 0.03, 0, 0, TAU);
    ctx.ellipse(s * 0.06, s * 0.1, s * 0.04, s * 0.03, 0, 0, TAU);
    ctx.fill();

    ctx.fillStyle = "#3a3a3e";
    ctx.beginPath();
    ctx.ellipse(0, 0, s * 0.19, s * 0.12, 0, 0, TAU);
    ctx.fill();
    ctx.fillStyle = "#5c5c62";
    ctx.beginPath();
    ctx.ellipse(-s * 0.15, 0, s * 0.06, s * 0.05, 0, 0, TAU);
    ctx.ellipse(s * 0.15, 0, s * 0.06, s * 0.05, 0, 0, TAU);
    ctx.fill();
    ctx.strokeStyle = "rgba(255,255,255,0.09)";
    ctx.lineWidth = Math.max(1, s * 0.02);
    ctx.beginPath();
    ctx.moveTo(-s * 0.12, -s * 0.03);
    ctx.lineTo(s * 0.12, -s * 0.03);
    ctx.stroke();

    ctx.fillStyle = "#4e4e54";
    ctx.beginPath();
    ctx.arc(0, -s * 0.02, s * 0.085, 0, TAU);
    ctx.fill();
    ctx.fillStyle = "rgba(255,255,255,0.18)";
    ctx.beginPath();
    ctx.arc(-s * 0.025, -s * 0.05, s * 0.03, 0, TAU);
    ctx.fill();

    const glint = 0.5 + 0.5 * Math.sin(now * 0.006 + food.x);
    ctx.strokeStyle = "rgba(236,230,214," + (0.5 + 0.5 * glint) + ")";
    ctx.lineWidth = Math.max(1, s * 0.03);
    ctx.lineCap = "round";
    ctx.beginPath();
    ctx.moveTo(s * 0.14, s * 0.03);
    ctx.lineTo(s * 0.34, -s * 0.2);
    ctx.stroke();
    ctx.fillStyle = "rgba(255,255,255," + (0.9 * glint) + ")";
    ctx.beginPath();
    ctx.arc(s * 0.3, -s * 0.16, Math.max(1, s * 0.02), 0, TAU);
    ctx.fill();
    ctx.restore();
}

function drawThopterShadow(th) {
    const p = th.pose;
    ctx.save();
    ctx.translate(p.x + p.alt * cell * 0.9, p.y + p.alt * cell * 1.2);
    ctx.rotate(p.angle);
    ctx.globalAlpha = 0.34 * (1 - p.alt * 0.55);
    ctx.fillStyle = "#1a1008";
    ctx.beginPath();
    ctx.ellipse(0, 0, cell * 0.34 * (1 + p.alt * 0.6), cell * 0.13 * (1 + p.alt * 0.6), 0, 0, TAU);
    ctx.fill();
    ctx.restore();
}

// The ornithopter: four beating wings with a translucent membrane behind each leading
// edge, a tapered hull, a tail fin, and a glint off the canopy.
function drawThopter(th, now) {
    const p = th.pose;
    const s = cell * (0.95 - p.alt * 0.25);
    const beat = Math.sin(now * 0.05);
    ctx.save();
    ctx.translate(p.x, p.y);
    ctx.rotate(p.angle);
    ctx.lineCap = "round";

    // Each wing drawn twice, where it is and where it just was, so the beat blurs.
    for (const side of [-1, 1]) {
        for (const pair of [0, 1]) {
            for (const ghost of [0, 1]) {
                const flap = (ghost ? -beat : beat) * 0.16 * side;
                const a = side * (2.45 - pair * 0.5) + flap;
                const rootX = -s * 0.05 + pair * s * 0.06;
                const len = s * 0.55;
                ctx.save();
                ctx.translate(rootX, 0);
                ctx.rotate(a);
                ctx.globalAlpha = ghost ? 0.1 : 0.26;
                ctx.fillStyle = "#c9b898";
                ctx.beginPath();
                ctx.ellipse(len / 2, 0, len / 2, s * 0.05, 0, 0, TAU);
                ctx.fill();
                ctx.globalAlpha = ghost ? 0.25 : 0.7;
                ctx.strokeStyle = "#463a2e";
                ctx.lineWidth = Math.max(1, s * 0.05);
                ctx.beginPath();
                ctx.moveTo(0, 0);
                ctx.lineTo(len, 0);
                ctx.stroke();
                ctx.restore();
            }
        }
    }
    ctx.globalAlpha = 1;

    ctx.fillStyle = "#2a221b";
    ctx.beginPath();
    ctx.moveTo(s * 0.32, 0);
    ctx.quadraticCurveTo(s * 0.1, -s * 0.11, -s * 0.26, -s * 0.06);
    ctx.lineTo(-s * 0.32, 0);
    ctx.lineTo(-s * 0.26, s * 0.06);
    ctx.quadraticCurveTo(s * 0.1, s * 0.11, s * 0.32, 0);
    ctx.closePath();
    ctx.fill();
    ctx.strokeStyle = "rgba(244,192,124,0.3)";
    ctx.lineWidth = 1;
    ctx.stroke();

    ctx.fillStyle = "#3a2f26";
    ctx.beginPath();
    ctx.moveTo(-s * 0.2, 0);
    ctx.lineTo(-s * 0.34, -s * 0.12);
    ctx.lineTo(-s * 0.3, 0);
    ctx.closePath();
    ctx.fill();

    ctx.fillStyle = "rgba(244,222,180,0.55)";
    ctx.beginPath();
    ctx.ellipse(s * 0.12, -s * 0.01, s * 0.06, s * 0.035, 0, 0, TAU);
    ctx.fill();
    ctx.restore();
}

// ---- grains and rings ------------------------------------------------------------

function addGrain(x, y, vx, vy, life, color) {
    if (grains.length >= 320) {
        grains.shift();
    }
    grains.push({ x, y, vx, vy, life, age: 0, color, size: 0.8 + Math.random() * 1.4 });
}

function puff(x, y, count, speed, palette) {
    for (let i = 0; i < count; i++) {
        const a = Math.random() * TAU;
        const v = speed * (0.3 + Math.random());
        addGrain(x, y, Math.cos(a) * v, Math.sin(a) * v, 380 + Math.random() * 420,
            palette[(Math.random() * palette.length) | 0]);
    }
}

function ageGrains(dt) {
    let keep = 0;
    for (let i = 0; i < grains.length; i++) {
        const g = grains[i];
        g.age += dt;
        if (g.age >= g.life) {
            continue;
        }
        g.x += g.vx * dt * 0.06;
        g.y += g.vy * dt * 0.06;
        g.vx *= 0.96;
        g.vy *= 0.96;
        grains[keep++] = g;
    }
    grains.length = keep;
}

function drawGrains() {
    for (const g of grains) {
        ctx.globalAlpha = 0.75 * (1 - g.age / g.life);
        ctx.fillStyle = g.color;
        ctx.fillRect(g.x, g.y, g.size, g.size);
    }
    ctx.globalAlpha = 1;
}

function drawRings() {
    let keep = 0;
    for (let i = 0; i < rings.length; i++) {
        const r = rings[i];
        const p = (clock - r.at) / r.span;
        if (p >= 1) {
            continue;
        }
        rings[keep++] = r;
        ctx.strokeStyle = "rgba(" + r.color + "," + (0.6 * (1 - p)) + ")";
        ctx.lineWidth = Math.max(1, cell * 0.06 * (1 - p));
        ctx.beginPath();
        ctx.arc(r.x, r.y, r.size * easeOut(p), 0, TAU);
        ctx.stroke();
    }
    rings.length = keep;
}

// ---- hud and storage -------------------------------------------------------------

function showPanel(name) {
    for (const key of Object.keys(hud.panels)) {
        const panel = hud.panels[key];
        if (panel) {
            panel.hidden = key !== name;
        }
    }
    if (name) {
        const heading = hud.panels[name].querySelector("h1, h2");
        if (heading) {
            if (!heading.hasAttribute("tabindex")) {
                heading.setAttribute("tabindex", "-1");
            }
            heading.focus({ preventScroll: true });
        }
    }
}

function setCount(el, n) {
    if (el) {
        el.textContent = String(n);
    }
}

function loadBest() {
    try {
        const raw = localStorage.getItem(STORAGE_KEY);
        const n = raw ? Number(JSON.parse(raw).best) : 0;
        return Number.isFinite(n) && n > 0 ? Math.floor(n) : 0;
    } catch {
        return 0;
    }
}

function saveBest() {
    try {
        localStorage.setItem(STORAGE_KEY, JSON.stringify({ best: best }));
    } catch {
        // Storage that will not answer just means the tally lives for the visit.
    }
}

// ---- small maths -----------------------------------------------------------------

function clamp(v, lo, hi) {
    return v < lo ? lo : v > hi ? hi : v;
}

function easeInOut(t) {
    t = clamp(t, 0, 1);
    return t < 0.5 ? 2 * t * t : 1 - Math.pow(-2 * t + 2, 2) / 2;
}

function easeOut(t) {
    t = clamp(t, 0, 1);
    return 1 - (1 - t) * (1 - t);
}

function easeIn(t) {
    t = clamp(t, 0, 1);
    return t * t;
}

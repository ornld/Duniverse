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

// Painted once per fit onto its own canvas. A frame then copies it in one call and
// pays only for what moves.
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
    sand.addColorStop(0, "#cf9c5f");
    sand.addColorStop(0.5, "#c48f52");
    sand.addColorStop(1, "#ad7843");
    t.fillStyle = sand;
    t.fillRect(ox, oy, bw, bh);

    t.save();
    t.beginPath();
    t.rect(ox, oy, bw, bh);
    t.clip();

    // Dunes: long soft ridges, each lit up-left and shaded down-right like the worm.
    const ridges = Math.max(4, Math.round((bw + bh) / 240));
    for (let i = 0; i < ridges; i++) {
        const y0 = oy + (i + 0.5) / ridges * bh + (rnd() - 0.5) * cell * 1.5;
        const amp = cell * (0.8 + rnd() * 1.6);
        const freq = (0.5 + rnd() * 0.9) * TAU / bw;
        const phase = rnd() * TAU;
        const tilt = (rnd() - 0.5) * 0.18;
        const pts = [];
        for (let x = ox - 20; x <= ox + bw + 20; x += 10) {
            pts.push([x, y0 + Math.sin(x * freq + phase) * amp + (x - ox) * tilt]);
        }
        t.lineCap = "round";
        t.lineJoin = "round";
        t.strokeStyle = "rgba(236,190,128,0.16)";
        t.lineWidth = cell * 1.5;
        tracePoints(t, pts, 0, 0);
        t.stroke();
        t.strokeStyle = "rgba(98,58,26,0.26)";
        t.lineWidth = cell * 0.5;
        tracePoints(t, pts, cell * 0.12, cell * 0.28);
        t.stroke();
        t.strokeStyle = "rgba(250,212,152,0.34)";
        t.lineWidth = cell * 0.16;
        tracePoints(t, pts, -cell * 0.1, -cell * 0.1);
        t.stroke();
    }

    // Speckle for grain, and a dot at every cell corner faint enough to pass as texture.
    // The dots are what let a player judge one bend from the next.
    const specks = Math.round(bw * bh / 34);
    for (let i = 0; i < specks; i++) {
        t.fillStyle = rnd() < 0.5 ? "rgba(255,226,172,0.11)" : "rgba(80,45,15,0.11)";
        t.fillRect(ox + rnd() * bw, oy + rnd() * bh, 1, 1);
    }
    t.fillStyle = "rgba(60,35,12,0.20)";
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
    rings.push({ x: c.x, y: c.y, at: clock, span: 520, size: cell * 1.3, color: "244,192,124" });
    puff(c.x, c.y, 26, cell * 0.11, SAND);
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

// The ridge as one line through the cells, head and tail eased by how far the tick has
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

function curveThrough(pts, dx, dy) {
    ctx.beginPath();
    if (pts.length === 1) {
        ctx.moveTo(pts[0].x + dx, pts[0].y + dy);
        return;
    }
    ctx.moveTo(pts[0].x + dx, pts[0].y + dy);
    for (let i = 1; i < pts.length - 1; i++) {
        const mx = (pts[i].x + pts[i + 1].x) / 2 + dx;
        const my = (pts[i].y + pts[i + 1].y) / 2 + dy;
        ctx.quadraticCurveTo(pts[i].x + dx, pts[i].y + dy, mx, my);
    }
    const end = pts[pts.length - 1];
    ctx.lineTo(end.x + dx, end.y + dy);
}

function drawWorm(alpha) {
    const pts = wormPoints(alpha);
    const w = cell * 0.62;
    ctx.lineCap = "round";
    ctx.lineJoin = "round";

    ctx.strokeStyle = "rgba(60,34,12,0.45)";
    ctx.lineWidth = w + cell * 0.16;
    curveThrough(pts, cell * 0.1, cell * 0.13);
    ctx.stroke();

    ctx.strokeStyle = "#dcae70";
    ctx.lineWidth = w;
    curveThrough(pts, 0, 0);
    ctx.stroke();

    ctx.strokeStyle = "rgba(255,232,190,0.55)";
    ctx.lineWidth = w * 0.26;
    curveThrough(pts, -cell * 0.09, -cell * 0.1);
    ctx.stroke();

    // Ribs ride forward one cell per tick, which is what makes the ridge look like it
    // is moving rather than growing at one end and shrinking at the other.
    ctx.strokeStyle = "rgba(90,55,25,0.38)";
    ctx.lineWidth = Math.max(1, cell * 0.05);
    ctx.beginPath();
    for (let i = 2; i < snake.length; i++) {
        const p = lerpCell(snake[i], snake[i - 1], alpha);
        const a = cellCenter(snake[i - 1]);
        const b = cellCenter(snake[i]);
        const dx = a.x - b.x;
        const dy = a.y - b.y;
        const len = Math.hypot(dx, dy) || 1;
        const px = -dy / len * w * 0.36;
        const py = dx / len * w * 0.36;
        ctx.moveTo(p.x - px, p.y - py);
        ctx.lineTo(p.x + px, p.y + py);
    }
    ctx.stroke();

    drawHead(pts[0]);
}

function drawHead(p) {
    const r = cell * 0.42;
    ctx.fillStyle = "rgba(60,34,12,0.45)";
    ctx.beginPath();
    ctx.arc(p.x + cell * 0.1, p.y + cell * 0.13, r + cell * 0.06, 0, TAU);
    ctx.fill();
    ctx.fillStyle = "#e2b579";
    ctx.beginPath();
    ctx.arc(p.x, p.y, r, 0, TAU);
    ctx.fill();
    ctx.fillStyle = "rgba(255,236,200,0.55)";
    ctx.beginPath();
    ctx.arc(p.x - cell * 0.1, p.y - cell * 0.11, r * 0.45, 0, TAU);
    ctx.fill();
    ctx.strokeStyle = "rgba(90,55,25,0.35)";
    ctx.lineWidth = Math.max(1, cell * 0.04);
    ctx.beginPath();
    ctx.arc(p.x, p.y, r * 0.72, 0, TAU);
    ctx.stroke();
}

// Grains flung off the head every frame, the wake of a ridge pushing through sand.
function spray() {
    if (!snake.length || acc < 0) {
        return;
    }
    const p = lerpCell(prev[0] || snake[0], snake[0], acc / tickMs);
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
    const n = snake.length;
    if (fell.sunk < n) {
        const remaining = snake.slice(fell.sunk);
        const pts = remaining.map(cellCenter);
        const w = cell * 0.62;
        ctx.lineCap = "round";
        ctx.lineJoin = "round";
        ctx.strokeStyle = "rgba(60,34,12,0.45)";
        ctx.lineWidth = w + cell * 0.16;
        curveThrough(pts, cell * 0.1, cell * 0.13);
        ctx.stroke();
        ctx.strokeStyle = "#dcae70";
        ctx.lineWidth = w;
        curveThrough(pts, 0, 0);
        ctx.stroke();
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

function drawSoldier(now) {
    const c = cellCenter(food);
    const s = cell;
    const land = easeOut(clamp((clock - food.at) / 260, 0, 1));
    ctx.save();
    ctx.translate(c.x, c.y);
    ctx.scale(land, land);

    ctx.fillStyle = "rgba(20,10,4,0.35)";
    ctx.beginPath();
    ctx.ellipse(s * 0.06, s * 0.3, s * 0.2, s * 0.07, 0, 0, TAU);
    ctx.fill();

    ctx.strokeStyle = "#5c5a55";
    ctx.lineWidth = s * 0.07;
    ctx.lineCap = "round";
    ctx.beginPath();
    ctx.moveTo(-s * 0.07, s * 0.1);
    ctx.lineTo(-s * 0.1, s * 0.3);
    ctx.moveTo(s * 0.07, s * 0.1);
    ctx.lineTo(s * 0.1, s * 0.3);
    ctx.stroke();

    ctx.fillStyle = "#8b8a84";
    ctx.fillRect(-s * 0.13, -s * 0.16, s * 0.26, s * 0.3);
    ctx.strokeStyle = "#3d3c39";
    ctx.lineWidth = 1;
    ctx.strokeRect(-s * 0.13, -s * 0.16, s * 0.26, s * 0.3);
    ctx.fillStyle = "#65645f";
    ctx.fillRect(-s * 0.15, -s * 0.16, s * 0.3, s * 0.06);

    ctx.fillStyle = "#47464a";
    ctx.beginPath();
    ctx.arc(0, -s * 0.25, s * 0.09, 0, TAU);
    ctx.fill();

    const glint = 0.5 + 0.5 * Math.sin(now * 0.006 + food.x);
    ctx.strokeStyle = "rgba(240,232,214," + (0.45 + 0.55 * glint) + ")";
    ctx.lineWidth = Math.max(1, s * 0.035);
    ctx.beginPath();
    ctx.moveTo(s * 0.14, s * 0.02);
    ctx.lineTo(s * 0.3, -s * 0.3);
    ctx.stroke();
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

function drawThopter(th, now) {
    const p = th.pose;
    const s = cell * (0.95 - p.alt * 0.25);
    const beat = Math.sin(now * 0.05);
    ctx.save();
    ctx.translate(p.x, p.y);
    ctx.rotate(p.angle);
    ctx.lineCap = "round";

    // Four wings, each drawn twice: where it is and where it just was, so the beat
    // blurs the way a real one does at this distance.
    for (const side of [-1, 1]) {
        for (const pair of [0, 1]) {
            for (const ghost of [0, 1]) {
                const flap = (ghost ? -beat : beat) * 0.16 * side;
                const a = side * (2.45 - pair * 0.5) + flap;
                ctx.strokeStyle = ghost ? "rgba(70,56,42,0.25)" : "rgba(70,56,42,0.7)";
                ctx.lineWidth = Math.max(1, s * 0.06);
                ctx.beginPath();
                ctx.moveTo(-s * 0.05 + pair * s * 0.06, 0);
                ctx.lineTo(Math.cos(a) * s * 0.55 - s * 0.05, Math.sin(a) * s * 0.55);
                ctx.stroke();
            }
        }
    }

    ctx.fillStyle = "#2c231b";
    ctx.beginPath();
    ctx.ellipse(0, 0, s * 0.24, s * 0.09, 0, 0, TAU);
    ctx.fill();
    ctx.strokeStyle = "rgba(244,192,124,0.3)";
    ctx.lineWidth = 1;
    ctx.stroke();
    ctx.fillStyle = "rgba(244,192,124,0.5)";
    ctx.beginPath();
    ctx.arc(s * 0.13, 0, s * 0.035, 0, TAU);
    ctx.fill();
    ctx.restore();
}

// ---- grains and rings ------------------------------------------------------------

function addGrain(x, y, vx, vy, life, color) {
    if (grains.length >= 260) {
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

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
    }
};

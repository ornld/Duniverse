// Melange sand for the Index dropdown and the clearance ritual. Snow falls; sand
// blows. Grains enter high on the windward side and are carried across the panel by
// a shared wind that surges and lulls (three offset sine waves at unrelated periods,
// so the gusts never quite repeat), sinking slowly as they go until they settle at
// scattered depths and dissolve. A grain in flight is drawn as a streak along its own
// motion, so a gust reads as driven sand rather than drifting flakes; a settled grain
// is a resting dot. The smallest grains ride the wind hardest while the heavy ones
// sag out of it early, and a rare glint grain catches the light for the spice. Faded
// and blown-out grains respawn upwind after a random pause, so the opening gust
// relaxes into a steady sift that lasts as long as the panel is open. The loop keys
// off canvas.isConnected: when Blazor removes the panel, the canvas leaves the
// document and the animation stops itself. The canvas is sized against
// devicePixelRatio so grains stay single-pixel sharp on retina screens, and the whole
// effect skips itself for readers who ask the OS for reduced motion.
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

        // Spice palette, bright grains rarer than dark ones so the drift reads as depth.
        const palette = ["#f4c07c", "#e0a458", "#e0a458", "#c97f3d", "#a05c22", "#8a4a1a"];

        function spawn(grain, now, initial) {
            // Two ways into the panel: over the top rim, biased upwind, or straight
            // through the upwind edge at any height, like a cross-section of a sand
            // sheet. Without the edge entries the wind carries everything out the far
            // side before it can sink, and the lower panel never sees a grain.
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
            // Lighter grains ride the wind harder than heavy ones, which spreads one
            // shared gust into layers of different speeds.
            grain.carry = 1.55 - (grain.size / dpr - 0.6) * 0.7;
            const glint = Math.random() < 0.05;
            grain.color = glint ? "#ffdf9e" : palette[(Math.random() * palette.length) | 0];
            grain.alpha = glint ? 0.5 + Math.random() * 0.35 : 0.15 + Math.random() * 0.55;
            // Every grain settles a plausible sink below wherever it entered.
            grain.settleY = Math.min(h * 0.95, Math.max(grain.y, 0) + h * (0.15 + Math.random() * 0.55));
            grain.restFrames = 0;
            // The first wave blows in at once; respawns pause only briefly, so the
            // steady state holds a full airborne haze: a window onto Arrakis, kept
            // legible by the calm wind rather than by thinning the sand.
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

            // The shared wind, always blowing one way: a steady push plus gusts that
            // swell and die on their own rhythm. Tuned to a sift, not a storm; the
            // directional pull, not raw speed, is what keeps it reading as sand.
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
                    // Directional turbulence, not sway: the jitter roughens the path
                    // but never pushes a grain back against the wind.
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
                    // At rest: a grain of settled sand, not a streak.
                    ctx.fillStyle = g.color;
                    ctx.fillRect(g.x, g.y, g.size, g.size);
                } else {
                    // In flight: stretched along the last stretch of its own path, so
                    // speed itself is what the eye reads. Gusts draw long streaks,
                    // lulls relax back toward dots.
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

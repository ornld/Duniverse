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

        const dpr = window.devicePixelRatio || 1;
        const w = canvas.width = window.innerWidth * dpr;
        const h = canvas.height = window.innerHeight * dpr;

        const palette = ["#f4c07c", "#e0a458", "#e0a458", "#c97f3d", "#a05c22", "#8a4a1a"];

        // Below the 404 page's density, which stripes a whole column at roughly one grain
        // per 0.75px of width. A storm reads through speed and streak length more than
        // through count, and this one runs while the main thread has real work to do, so
        // it buys its haze with long strokes rather than population.
        const maxGrains = Math.min(900, Math.round(window.innerWidth / 1.6));

        let intensity = 0;
        let clearing = 0;      // 0 until the whoosh starts, then climbs 0 -> 1
        let running = true;

        // Only ever used to lay down the starting field. Grains are not respawned after
        // that, they are wrapped, which is what keeps the sand evenly spread. Scattering
        // them across the whole canvas here is the other half of that: the field starts
        // uniform and the wrap preserves it.
        function spawn(g) {
            g.x = Math.random() * w;
            g.y = Math.random() * h;
            g.px = g.x;
            g.py = g.y;
            g.vy = (0.15 + Math.random() * 0.5) * dpr;
            g.size = (0.5 + Math.random() * 1.3) * dpr;
            // Wider spread than the settle version uses. Grains that all travel at one
            // speed stay a pack however they started; varied ones fan out on their own.
            g.carry = (1.55 - (g.size / dpr - 0.5) * 0.7) * (0.55 + Math.random() * 0.9);
            const glint = Math.random() < 0.05;
            g.color = glint ? "#ffdf9e" : palette[(Math.random() * palette.length) | 0];
            g.alpha = glint ? 0.55 + Math.random() * 0.35 : 0.2 + Math.random() * 0.55;
            return g;
        }

        const grains = [];
        for (let i = 0; i < maxGrains; i++) {
            grains.push(spawn({}));
        }

        function frame(now) {
            if (!running || !canvas.isConnected) {
                return;
            }

            // The same three-sine gust as the settle version, so the boot storm and the
            // sand elsewhere on the site are recognisably the same weather.
            const gust =
                0.5 * Math.sin(now * 0.00055) +
                0.3 * Math.sin(now * 0.0016 + 2.1) +
                0.2 * Math.sin(now * 0.00037 + 4.4);

            // Intensity curved rather than linear: the first half of a load should still
            // look like calm air, so the build is felt late and arrives as a rise.
            const shaped = intensity * intensity;
            // Tuned so a grain crosses the screen in a second or two at full storm. Slower
            // than this and the streaks sit there looking like scratches rather than blowing.
            const base = 0.5 + shaped * 14 + clearing * 30;
            const wind = base * (0.55 + 0.45 * (gust * 0.5 + 0.5)) * dpr;

            // Grains join the storm as it builds, so early frames are cheap in every
            // sense: fewer to move, fewer to draw, while the thread is busiest.
            const active = Math.max(24, Math.round(maxGrains * (0.12 + shaped * 0.88)));

            ctx.clearRect(0, 0, w, h);
            ctx.lineCap = "round";

            for (let i = 0; i < active; i++) {
                const g = grains[i];
                g.px = g.x;
                g.py = g.y;
                g.x += wind * g.carry + (Math.random() - 0.5) * 0.4 * dpr;
                g.y += g.vy * (1 - clearing * 0.8) + (Math.random() - 0.5) * 0.25 * dpr;

                if (g.x > w + 8 * dpr || g.y > h + 8 * dpr) {
                    // Once the storm is breaking, grains that leave stay gone. That
                    // emptying is the clear: the air thins out on its own rather than
                    // being faded out under a blanket.
                    if (clearing > 0.35) {
                        g.alpha = 0;
                        continue;
                    }

                    // Carried round rather than respawned. Putting every grain back just
                    // off the upwind edge drags the entire population into a band there
                    // within a single crossing, however much their speeds vary, and the
                    // rest of the screen empties out. Wrapping preserves whatever spread
                    // the field already had. Height is rerolled for variety, and px is
                    // pulled with it so the wrap frame does not draw one long streak
                    // straight across the canvas.
                    g.x -= w + 16 * dpr;
                    g.y = Math.random() * h;
                    g.px = g.x;
                    g.py = g.y;
                    continue;
                }

                if (g.alpha <= 0) {
                    continue;
                }

                ctx.globalAlpha = g.alpha * (1 - clearing * 0.15);
                ctx.strokeStyle = g.color;
                ctx.lineWidth = g.size;
                // Streaks stretch with the wind, so the same grain that dotted along in
                // the calm draws a long line once the storm is up.
                const stretch = 0.9 + shaped * 1.6 + clearing * 5;
                ctx.beginPath();
                ctx.moveTo(g.px + (g.px - g.x) * stretch, g.py + (g.py - g.y) * stretch);
                ctx.lineTo(g.x, g.y);
                ctx.stroke();
            }

            ctx.globalAlpha = 1;
            requestAnimationFrame(frame);
        }

        requestAnimationFrame(frame);

        return {
            // 0 is dead calm, 1 is full storm. Clamped, because the caller is reading a
            // CSS variable the runtime owns and that value is not this code's to trust.
            setIntensity: function (value) {
                const n = Number(value);
                intensity = Number.isFinite(n) ? Math.max(0, Math.min(1, n)) : intensity;
            },

            // The whoosh. Wind climbs hard, streaks stretch, grains leave and do not come
            // back. Resolves when the air is empty, but the caller must not wait on that
            // alone: a backgrounded tab stops firing animation frames, and the boot screen
            // has to come down either way.
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

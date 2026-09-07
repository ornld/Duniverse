// Blowing sand for the Index dropdown. I size the canvas by devicePixelRatio and scale
// grain speed and size by it, so grains stay sharp on retina. The loop quits when Blazor
// drops the panel. I ignore reduced motion on purpose.
window.duneNav = {
    sandSettle: function (canvas) {
        if (!canvas) {
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
            // Grains enter two ways: over the top, or through the upwind edge at any
            // height. Without the edge entries the wind sweeps everything out the far
            // side before it sinks, and the bottom of the panel stays empty.
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
    // The boot storm. I hand the canvas to a worker that owns every frame, since drawing here
    // froze whenever Blazor's runtime blocked the thread. No main thread fallback on purpose:
    // without the handover the boot screen stays plain.
    sandStorm: function (canvas) {
        const inert = {
            setIntensity: function () { },
            clear: function () { return Promise.resolve(); },
            stop: function () { }
        };

        if (!canvas) {
            return inert;
        }
        if (typeof Worker !== "function" || typeof canvas.transferControlToOffscreen !== "function") {
            return inert;
        }

        // Capped rather than taken as given: the grains are hairlines, and there is nothing in
        // a 1px streak a third pixel of precision improves. Costs no visible quality and saves
        // close to half the fill on a retina screen.
        const dpr = Math.min(window.devicePixelRatio || 1, 1.5);
        canvas.width = window.innerWidth * dpr;
        canvas.height = window.innerHeight * dpr;

        let worker;
        let surface;
        try {
            worker = new Worker("js/storm-worker.js");
            surface = canvas.transferControlToOffscreen();
        } catch (e) {
            if (worker) {
                try { worker.terminate(); } catch (ignored) { }
            }
            return inert;
        }

        let pendingClear = null;
        worker.onmessage = function (event) {
            const data = event.data || {};
            if ((data.type === "cleared" || data.type === "failed") && pendingClear) {
                const done = pendingClear;
                pendingClear = null;
                done();
            }
        };
        // A worker that dies must not leave the page waiting on a clear that will never land.
        worker.onerror = function () {
            if (pendingClear) {
                const done = pendingClear;
                pendingClear = null;
                done();
            }
        };

        worker.postMessage({
            type: "init",
            canvas: surface,
            dpr: dpr,
            grains: Math.min(900, Math.round(window.innerWidth / 1.6))
        }, [surface]);

        let alive = true;
        function send(message) {
            if (!alive) {
                return;
            }
            try {
                worker.postMessage(message);
            } catch (e) {
                alive = false;
            }
        }

        return {
            setIntensity: function (value) {
                send({ type: "intensity", value: value });
            },

            clear: function (ms) {
                return new Promise(function (resolve) {
                    if (!alive) {
                        resolve();
                        return;
                    }
                    pendingClear = resolve;
                    send({ type: "clear", ms: ms });
                });
            },

            stop: function () {
                send({ type: "stop" });
                alive = false;
                // Given a moment to close itself first, so the last frame is not cut mid-draw.
                setTimeout(function () {
                    try { worker.terminate(); } catch (e) { }
                }, 60);
            }
        };
    },

    // The door to the deep desert. Planting the thumper runs the ceremony here: a ring and
    // a kick of sand on each slam, then wormsign crossing the hero at the thumper's foot.
    // Answers true once the worm has crossed, false if the page left first.
    thumperCall: function (hero, button, overlay) {
        return new Promise(function (resolve) {
            if (!hero || !button || !overlay) {
                resolve(false);
                return;
            }

            const octx = overlay.getContext("2d");
            const dpr = Math.min(window.devicePixelRatio || 1, 2);
            const heroRect = hero.getBoundingClientRect();
            overlay.width = Math.round(heroRect.width * dpr);
            overlay.height = Math.round(heroRect.height * dpr);
            const w = overlay.width;
            const h = overlay.height;

            // The spike meets the sand a little above the art's foot. Rings spread from there.
            const art = button.getBoundingClientRect();
            const base = {
                x: (art.left - heroRect.left + art.width / 2) * dpr,
                y: (art.top - heroRect.top + art.height * 0.94) * dpr
            };

            const palette = ["#f4c07c", "#e0a458", "#c97f3d", "#a05c22"];
            // Matched to the cap's CSS slam: 0.7 s a beat, the strike just before the middle.
            const slams = [320, 1020, 1720];
            const crossAt = 1900;
            const crossSpan = 1400;
            const start = performance.now();
            let slamsDone = 0;
            const rings = [];
            const grains = [];
            const trail = [];
            const phase = Math.random() * 6;

            function kick(x, y, count, lift) {
                for (let k = 0; k < count; k++) {
                    grains.push({
                        x: x + (Math.random() - 0.5) * 16 * dpr,
                        y: y,
                        vx: (Math.random() - 0.5) * 2.4 * dpr,
                        vy: -(lift + Math.random() * 2) * dpr,
                        at: performance.now(),
                        life: 360 + Math.random() * 320,
                        c: palette[(Math.random() * palette.length) | 0]
                    });
                }
            }

            function trace(pts, dx, dy) {
                octx.beginPath();
                for (let i = 0; i < pts.length; i++) {
                    if (i === 0) {
                        octx.moveTo(pts[i][0] + dx, pts[i][1] + dy);
                    } else {
                        octx.lineTo(pts[i][0] + dx, pts[i][1] + dy);
                    }
                }
            }

            function draw(now) {
                if (!hero.isConnected) {
                    resolve(false);
                    return;
                }
                const t = now - start;

                while (slamsDone < slams.length && t >= slams[slamsDone]) {
                    rings.push({ at: now });
                    kick(base.x, base.y, 14, 1);
                    slamsDone++;
                }

                octx.clearRect(0, 0, w, h);

                // Flattened rings, since the sand here is seen at a low angle, not from above.
                for (let i = rings.length - 1; i >= 0; i--) {
                    const p = (now - rings[i].at) / 1000;
                    if (p >= 1) {
                        rings.splice(i, 1);
                        continue;
                    }
                    const ease = 1 - (1 - p) * (1 - p);
                    octx.strokeStyle = "rgba(244,192,124," + (0.55 * (1 - p)) + ")";
                    octx.lineWidth = (2.4 - 1.8 * p) * dpr;
                    octx.beginPath();
                    octx.ellipse(base.x, base.y, (8 + 120 * ease) * dpr, (3 + 34 * ease) * dpr, 0, 0, Math.PI * 2);
                    octx.stroke();
                }

                if (t >= crossAt) {
                    const p = Math.min(1, (t - crossAt) / crossSpan);
                    const x = (-0.1 + 1.2 * p) * w;
                    const y = base.y + Math.sin(p * 9 + phase) * h * 0.05;
                    trail.push([x, y]);
                    if (trail.length > 32) {
                        trail.shift();
                    }
                    kick(x, y, 3, 0.5);

                    octx.lineCap = "round";
                    octx.lineJoin = "round";
                    trace(trail, 5 * dpr, 6 * dpr);
                    octx.strokeStyle = "rgba(60,34,12,0.5)";
                    octx.lineWidth = 26 * dpr;
                    octx.stroke();
                    trace(trail, 0, 0);
                    octx.strokeStyle = "#dcae70";
                    octx.lineWidth = 20 * dpr;
                    octx.stroke();
                    trace(trail, -4 * dpr, -4 * dpr);
                    octx.strokeStyle = "rgba(255,232,190,0.55)";
                    octx.lineWidth = 5 * dpr;
                    octx.stroke();
                    octx.fillStyle = "#e2b579";
                    octx.beginPath();
                    octx.arc(x, y, 14 * dpr, 0, Math.PI * 2);
                    octx.fill();
                }

                for (let i = grains.length - 1; i >= 0; i--) {
                    const g = grains[i];
                    const age = (now - g.at) / g.life;
                    if (age >= 1) {
                        grains.splice(i, 1);
                        continue;
                    }
                    g.x += g.vx;
                    g.y += g.vy;
                    g.vy += 0.05 * dpr;
                    octx.globalAlpha = 0.8 * (1 - age);
                    octx.fillStyle = g.c;
                    octx.fillRect(g.x, g.y, 1.5 * dpr, 1.5 * dpr);
                }
                octx.globalAlpha = 1;

                if (t >= crossAt + crossSpan) {
                    octx.clearRect(0, 0, w, h);
                    resolve(true);
                    return;
                }
                requestAnimationFrame(draw);
            }

            requestAnimationFrame(draw);
        });
    },

    // Where focus belongs once the ritual lets go, matching the router's own target. A heading
    // takes no focus without a tabindex, so I lend it one. True only once focus sticks, since
    // a choice re-mounts the page under it.
    focusHeading: function () {
        const heading = document.querySelector("main h1");
        if (!heading) {
            return false;
        }
        if (document.activeElement === heading) {
            return true;
        }
        if (!heading.hasAttribute("tabindex")) {
            heading.setAttribute("tabindex", "-1");
        }
        heading.focus({ preventScroll: true });
        return false;
    }
};

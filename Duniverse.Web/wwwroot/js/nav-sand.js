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
    // a kick of sand on each slam, then wormsign crossing the strip at the thumper's foot.
    // Answers true once the worm has crossed, false if the page left first.
    thumperCall: function (button, overlay) {
        return new Promise(function (resolve) {
            if (!button || !overlay) {
                resolve(false);
                return;
            }

            const octx = overlay.getContext("2d");
            const dpr = Math.min(window.devicePixelRatio || 1, 2);
            const box = overlay.getBoundingClientRect();
            overlay.width = Math.round(box.width * dpr);
            overlay.height = Math.round(box.height * dpr);
            const w = overlay.width;
            const h = overlay.height;

            // The spike meets the sand a little above the art's foot. Rings spread from there.
            const art = button.getBoundingClientRect();
            const base = {
                x: (art.left - box.left + art.width / 2) * dpr,
                y: (art.top - box.top + art.height * 0.94) * dpr
            };

            // The ceremony scales with the stake, floored so a moon-sized thumper still
            // raises rings and a ridge that read from across the page.
            const s = Math.max(0.4, Math.min(1, art.height / 180));

            const palette = ["#f4c07c", "#e0a458", "#c97f3d", "#a05c22"];
            // Matched to the cap's CSS slam: 0.7 s a beat, the strike just before the middle.
            const slams = [320, 1020, 1720];
            const crossAt = 1900;
            const crossSpan = 1400;
            const start = performance.now();
            let slamsDone = 0;
            const rings = [];
            const grains = [];
            const phase = Math.random() * 6;

            // Each grain remembers the sand it left, and lands there instead of falling past it.
            function kick(x, y, count, lift) {
                for (let k = 0; k < count; k++) {
                    grains.push({
                        x: x + (Math.random() - 0.5) * 16 * s * dpr,
                        y: y,
                        floor: y,
                        vx: (Math.random() - 0.5) * 2.4 * s * dpr,
                        vy: -(lift + Math.random() * 2) * s * dpr,
                        at: performance.now(),
                        life: 360 + Math.random() * 320,
                        c: palette[(Math.random() * palette.length) | 0]
                    });
                }
            }

            // The worm is the game's animal, drawn small: a pale tapered tube with dark seams
            // riding a wave along the crest, and the cut, angled head with the red crescent.
            const W = 30 * s * dpr;
            const LEN = W * 7;
            function wave(x) {
                return base.y + Math.sin(x / (w * 0.11) + phase) * 6 * s * dpr;
            }

            function drawWorm(headX) {
                const n = 26;
                const xs = [];
                const ys = [];
                const nx = [];
                const ny = [];
                const ws = [];
                for (let i = 0; i <= n; i++) {
                    const x = headX - LEN * i / n;
                    const y = wave(x);
                    const dy = (wave(x + 1) - wave(x - 1)) / 2;
                    const len = Math.hypot(1, dy);
                    xs.push(x);
                    ys.push(y);
                    nx.push(-dy / len);
                    ny.push(1 / len);
                    const f = i / n;
                    let ww = W * (1 - 0.1 * f);
                    if (f > 0.65) {
                        ww *= 1 - 0.72 * Math.pow((f - 0.65) / 0.35, 1.4);
                    }
                    ww *= 1 + 0.04 * Math.sin(i * Math.PI * 0.5);
                    ws.push(Math.max(ww, W * 0.14));
                }
                function band(dx, dy, scale) {
                    octx.beginPath();
                    for (let i = 0; i <= n; i++) {
                        const hw = ws[i] * scale / 2;
                        const x = xs[i] + dx + nx[i] * hw;
                        const y = ys[i] + dy + ny[i] * hw;
                        if (i === 0) {
                            octx.moveTo(x, y);
                        } else {
                            octx.lineTo(x, y);
                        }
                    }
                    for (let i = n; i >= 0; i--) {
                        const hw = ws[i] * scale / 2;
                        octx.lineTo(xs[i] + dx - nx[i] * hw, ys[i] + dy - ny[i] * hw);
                    }
                    octx.closePath();
                }
                octx.fillStyle = "rgba(240,212,166,0.14)";
                band(-W * 0.04, -W * 0.04, 1.6);
                octx.fill();
                octx.fillStyle = "rgba(45,30,15,0.45)";
                band(W * 0.12, W * 0.16, 1.06);
                octx.fill();
                octx.fillStyle = "#aeaba2";
                band(0, 0, 1);
                octx.fill();
                octx.save();
                band(0, 0, 1);
                octx.clip();
                octx.fillStyle = "rgba(60,58,52,0.5)";
                band(W * 0.2, W * 0.24, 0.7);
                octx.fill();
                octx.fillStyle = "rgba(242,240,234,0.42)";
                band(-W * 0.16, -W * 0.19, 0.62);
                octx.fill();
                octx.lineWidth = Math.max(1, W * 0.06);
                for (let d = W * 0.6; d < LEN; d += W * 0.5) {
                    const i = Math.round(d / LEN * n);
                    if (i > n) {
                        break;
                    }
                    const hw = ws[i] / 2;
                    octx.strokeStyle = "rgba(45,43,39,0.55)";
                    octx.beginPath();
                    octx.moveTo(xs[i] + nx[i] * hw, ys[i] + ny[i] * hw);
                    octx.lineTo(xs[i] - nx[i] * hw, ys[i] - ny[i] * hw);
                    octx.stroke();
                    octx.strokeStyle = "rgba(236,232,224,0.3)";
                    octx.beginPath();
                    octx.moveTo(xs[i] - W * 0.06 + nx[i] * hw, ys[i] + ny[i] * hw);
                    octx.lineTo(xs[i] - W * 0.06 - nx[i] * hw, ys[i] - ny[i] * hw);
                    octx.stroke();
                }
                octx.restore();
                drawHead(xs[0], ys[0], Math.atan2(ys[0] - ys[1], xs[0] - xs[1]));
            }

            // The cut end of the tube: flared to the rim, corners chamfered, a flat nose with
            // the mouth as a red crescent along it. The same hull the game's head uses.
            function drawHead(x, y, angle) {
                const L = W * 1.25;
                const F = W * 1.14;
                const B = W;
                const hull = new Path2D();
                [[-0.5, -0.5 * B / F], [0.12, -0.5], [0.4, -0.36], [0.5, -0.12], [0.5, 0.12], [0.4, 0.36], [0.12, 0.5], [-0.5, 0.5 * B / F]]
                    .forEach(function (pt, i) {
                        if (i === 0) {
                            hull.moveTo(pt[0] * L, pt[1] * F);
                        } else {
                            hull.lineTo(pt[0] * L, pt[1] * F);
                        }
                    });
                hull.closePath();
                const nose = [[0.12, -0.5], [0.4, -0.36], [0.5, -0.12], [0.5, 0.12], [0.4, 0.36], [0.12, 0.5]];
                const cx = L * 0.08;

                octx.save();
                octx.translate(x, y);
                octx.rotate(angle);
                octx.fillStyle = "rgba(45,30,15,0.4)";
                octx.beginPath();
                octx.ellipse(W * 0.1, W * 0.14, W * 0.7, W * 0.62, 0, 0, Math.PI * 2);
                octx.fill();

                const hide = octx.createLinearGradient(0, -F / 2, 0, F / 2);
                hide.addColorStop(0, "#6f6c64");
                hide.addColorStop(0.3, "#c9c6bc");
                hide.addColorStop(0.6, "#a6a399");
                hide.addColorStop(1, "#5f5c54");
                octx.fillStyle = hide;
                octx.fill(hull);

                octx.save();
                octx.clip(hull);
                octx.fillStyle = "rgba(255,255,255,0.13)";
                octx.beginPath();
                octx.moveTo(L * 0.12, -F * 0.5);
                octx.lineTo(L * 0.4, -F * 0.36);
                octx.lineTo(L * 0.5, -F * 0.12);
                octx.lineTo(L * 0.22, -F * 0.16);
                octx.closePath();
                octx.fill();
                octx.fillStyle = "rgba(0,0,0,0.2)";
                octx.beginPath();
                octx.moveTo(L * 0.12, F * 0.5);
                octx.lineTo(L * 0.4, F * 0.36);
                octx.lineTo(L * 0.5, F * 0.12);
                octx.lineTo(L * 0.22, F * 0.16);
                octx.closePath();
                octx.fill();
                octx.fillStyle = "rgba(0,0,0,0.1)";
                octx.fillRect(L * 0.4, -F, L * 0.2, F * 2);

                octx.beginPath();
                nose.forEach(function (pt, i) {
                    const px = cx + (pt[0] * L - cx) * 0.95;
                    const py = pt[1] * F * 0.95;
                    if (i === 0) {
                        octx.moveTo(px, py);
                    } else {
                        octx.lineTo(px, py);
                    }
                });
                for (let i = nose.length - 1; i >= 0; i--) {
                    const f = 0.5 - 0.12 * (1 - Math.abs(i / (nose.length - 1) * 2 - 1));
                    octx.lineTo(cx + (nose[i][0] * L - cx) * f, nose[i][1] * F * f);
                }
                octx.closePath();
                octx.fillStyle = "#4a170d";
                octx.fill();
                octx.fillStyle = "rgba(230,115,45,0.45)";
                octx.beginPath();
                octx.arc(L * 0.4, 0, W * 0.16, 0, Math.PI * 2);
                octx.fill();
                octx.strokeStyle = "rgba(220,216,206,0.8)";
                octx.lineWidth = Math.max(1, W * 0.03);
                octx.beginPath();
                nose.forEach(function (pt, i) {
                    const px = cx + (pt[0] * L - cx) * 0.95;
                    const py = pt[1] * F * 0.95;
                    if (i === 0) {
                        octx.moveTo(px, py);
                    } else {
                        octx.lineTo(px, py);
                    }
                });
                octx.stroke();
                octx.restore();

                octx.strokeStyle = "rgba(30,28,25,0.45)";
                octx.lineWidth = Math.max(1, W * 0.035);
                octx.stroke(hull);
                octx.restore();
            }

            function draw(now) {
                if (!overlay.isConnected) {
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

                // Flattened arcs, since the sand here is seen at a low angle, not from above.
                // Only the upper half: a ring passing under the stake looked wrong.
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
                    octx.ellipse(base.x, base.y, (8 + 120 * ease) * s * dpr, (3 + 34 * ease) * s * dpr, 0, Math.PI, Math.PI * 2);
                    octx.stroke();
                }

                if (t >= crossAt) {
                    const p = Math.min(1, (t - crossAt) / crossSpan);
                    const headX = (-0.15 + 1.3 * p) * w;
                    kick(headX, wave(headX), 3, 0.5);
                    drawWorm(headX);
                }

                for (let i = grains.length - 1; i >= 0; i--) {
                    const g = grains[i];
                    const age = (now - g.at) / g.life;
                    if (age >= 1 || (g.vy > 0 && g.y >= g.floor)) {
                        grains.splice(i, 1);
                        continue;
                    }
                    g.x += g.vx;
                    g.y += g.vy;
                    g.vy += 0.05 * s * dpr;
                    octx.globalAlpha = 0.8 * (1 - age);
                    octx.fillStyle = g.c;
                    octx.fillRect(g.x, g.y, Math.max(1, 1.5 * s) * dpr, Math.max(1, 1.5 * s) * dpr);
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

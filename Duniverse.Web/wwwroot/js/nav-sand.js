// Melange sand for the Index dropdown. When the panel opens, fine grains fall from the
// top edge, settle at scattered depths, and dissolve. Faded grains respawn at the top
// after a random pause, so the opening gust relaxes into a steady sift that lasts as
// long as the panel is open. The loop keys off canvas.isConnected: when Blazor removes
// the panel, the canvas leaves the document and the animation stops itself. The canvas
// is sized against devicePixelRatio so grains stay single-pixel sharp on retina
// screens, and the whole effect skips itself for readers who ask the OS for reduced
// motion.
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
            grain.x = Math.random() * w;
            grain.y = -Math.random() * h * 0.6;
            grain.vy = (0.9 + Math.random() * 1.7) * dpr;
            grain.drift = (Math.random() - 0.5) * 0.6 * dpr;
            grain.size = (0.6 + Math.random() * 1.2) * dpr;
            grain.color = palette[(Math.random() * palette.length) | 0];
            grain.settleY = h * (0.2 + Math.random() * 0.75);
            grain.alpha = 0.15 + Math.random() * 0.55;
            grain.restFrames = 0;
            // The first wave falls at once; respawns wait a while so the steady state
            // stays a sparse drizzle instead of a sandstorm over the links.
            grain.startAt = now + (initial ? 0 : 600 + Math.random() * 2600);
            return grain;
        }

        const grains = [];
        const count = Math.round(rect.width / 1.2);
        const t0 = performance.now();
        for (let i = 0; i < count; i++) {
            grains.push(spawn({}, t0, true));
        }

        function frame(now) {
            if (!canvas.isConnected) {
                return;
            }

            ctx.clearRect(0, 0, w, h);

            for (const g of grains) {
                if (now < g.startAt) {
                    continue;
                }

                if (g.restFrames === 0 && g.y < g.settleY) {
                    g.y += g.vy;
                    g.x += g.drift + Math.sin((g.y + g.x) * 0.02) * 0.3 * dpr;
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
                ctx.fillStyle = g.color;
                ctx.fillRect(g.x, g.y, g.size, g.size);
            }

            ctx.globalAlpha = 1;
            requestAnimationFrame(frame);
        }

        requestAnimationFrame(frame);
    }
};

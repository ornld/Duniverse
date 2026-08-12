// The camera for the whole-Duniverse graph. Blazor calls attach after render, like
// nav-sand.js. I move one <g> with a CSS transform, so nothing goes back through
// Blazor. A drag swallows its click, so panning never opens a star.
window.duneUniverse = (function () {
    let svg = null;
    let world = null;
    let vb = null;
    let scale = 1, tx = 0, ty = 0;

    const MIN_SCALE = 0.8;
    const MAX_SCALE = 8;
    const reducedMotion = () => window.matchMedia("(prefers-reduced-motion: reduce)").matches;

    function apply(animated) {
        if (!world) {
            return;
        }
        // Don't let the constellation get dragged fully out of frame.
        tx = Math.min(200, Math.max(vb.width * (1 - scale) - 200, tx));
        ty = Math.min(200, Math.max(vb.height * (1 - scale) - 200, ty));
        world.style.transition = animated && !reducedMotion() ? "transform 0.6s ease" : "none";
        world.style.transform = "translate(" + tx + "px, " + ty + "px) scale(" + scale + ")";
    }

    // Converts screen pixels to viewBox units, so zooming can hold the point under
    // the cursor still.
    function toView(clientX, clientY) {
        const r = svg.getBoundingClientRect();
        return [
            (clientX - r.left) * vb.width / r.width,
            (clientY - r.top) * vb.height / r.height,
        ];
    }

    function zoomAt(clientX, clientY, factor) {
        const next = Math.min(MAX_SCALE, Math.max(MIN_SCALE, scale * factor));
        const k = next / scale;
        const p = toView(clientX, clientY);
        tx = p[0] - k * (p[0] - tx);
        ty = p[1] - k * (p[1] - ty);
        scale = next;
        apply(false);
    }

    // The nudge for someone who scrolls over the graph expecting to zoom. I re-arm it
    // only after the scrolling stops, so a long scroll down the page raises it once
    // instead of flickering the whole way.
    let hintEl = null;
    let hintTimer = null;
    function hintZoom() {
        if (!hintEl) {
            return;
        }
        hintEl.classList.add("is-showing");
        clearTimeout(hintTimer);
        hintTimer = setTimeout(function () {
            hintEl.classList.remove("is-showing");
        }, 1400);
    }

    function attach(container) {
        svg = container.querySelector("svg.universe-graph");
        world = svg ? svg.querySelector(".universe-world") : null;
        hintEl = container.querySelector(".universe-zoom-hint");
        if (!svg || !world) {
            return;
        }
        vb = svg.viewBox.baseVal;
        scale = 1;
        tx = 0;
        ty = 0;

        // A plain scroll belongs to the page, so a trackpad can get past the constellation.
        // A pinch already sets ctrlKey, so one test covers both. Anyone who can't pinch or
        // hold a modifier still has the card's +/- buttons.
        svg.addEventListener("wheel", function (e) {
            if (!e.ctrlKey && !e.metaKey) {
                hintZoom();
                return;
            }
            e.preventDefault();
            zoomAt(e.clientX, e.clientY, Math.exp(-e.deltaY * 0.0015));
        }, { passive: false });

        // One finger pans, two pinch. Tracking the midpoint and spread handles both
        // the same way.
        const pointers = new Map();
        let moved = false;
        let downAt = null;
        let lastMid = null;
        let lastDist = 0;

        function mid() {
            const pts = Array.from(pointers.values());
            if (pts.length === 0) {
                return null;
            }
            let x = 0, y = 0;
            for (const p of pts) { x += p[0] / pts.length; y += p[1] / pts.length; }
            return [x, y];
        }

        function dist() {
            const pts = Array.from(pointers.values());
            return pts.length < 2 ? 0 : Math.hypot(pts[0][0] - pts[1][0], pts[0][1] - pts[1][1]);
        }

        svg.addEventListener("pointerdown", function (e) {
            pointers.set(e.pointerId, [e.clientX, e.clientY]);
            if (pointers.size === 1) {
                moved = false;
                downAt = [e.clientX, e.clientY];
            }
            lastMid = mid();
            lastDist = dist();
        });

        svg.addEventListener("pointermove", function (e) {
            if (!pointers.has(e.pointerId)) {
                return;
            }
            pointers.set(e.pointerId, [e.clientX, e.clientY]);

            const m = mid();
            if (pointers.size >= 2) {
                const d = dist();
                if (lastDist > 0 && d > 0) {
                    zoomAt(m[0], m[1], d / lastDist);
                }
                lastDist = d;
            }
            if (lastMid) {
                // Measured from where the pointer first went down, not move to move.
                // A click with a bit of hand shake should still count as a click, and
                // a pinch always counts as a gesture.
                if (!moved && (pointers.size >= 2 || (downAt && Math.hypot(m[0] - downAt[0], m[1] - downAt[1]) > 6))) {
                    moved = true;
                    // I capture only once a real drag starts. Capturing on press redirects
                    // the click to the SVG, so no star can be clicked. Mid-drag there's no
                    // click worth keeping, and capture stops a fast pan slipping off the SVG.
                    for (const id of pointers.keys()) {
                        try {
                            svg.setPointerCapture(id);
                        } catch {
                            // If a pointer can't be captured, panning still works
                            // without it.
                        }
                    }
                }
                const r = svg.getBoundingClientRect();
                tx += (m[0] - lastMid[0]) * vb.width / r.width;
                ty += (m[1] - lastMid[1]) * vb.height / r.height;
                apply(false);
            }
            lastMid = m;
        });

        function release(e) {
            pointers.delete(e.pointerId);
            lastMid = mid();
            lastDist = dist();
        }
        svg.addEventListener("pointerup", release);
        svg.addEventListener("pointercancel", release);

        svg.addEventListener("click", function (e) {
            if (moved) {
                e.stopPropagation();
                e.preventDefault();
                moved = false;
            }
        }, true);

        container.querySelectorAll("[data-uni-zoom]").forEach(function (button) {
            button.addEventListener("click", function () {
                const action = button.getAttribute("data-uni-zoom");
                if (action === "reset") {
                    reset();
                    return;
                }
                const r = svg.getBoundingClientRect();
                zoomAt(r.left + r.width / 2, r.top + r.height / 2, action === "in" ? 1.5 : 1 / 1.5);
            });
        });
    }

    // Glides the camera so the given viewBox point ends up centered at the given zoom.
    // Anyone with reduced motion on gets the jump without the glide.
    function focusOn(x, y, targetScale) {
        if (!svg) {
            return;
        }
        scale = Math.min(MAX_SCALE, Math.max(MIN_SCALE, targetScale));
        tx = vb.width / 2 - scale * x;
        ty = vb.height / 2 - scale * y;
        apply(true);
    }

    function reset() {
        scale = 1;
        tx = 0;
        ty = 0;
        apply(true);
    }

    return { attach: attach, focusOn: focusOn, reset: reset };
})();

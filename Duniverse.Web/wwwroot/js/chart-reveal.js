// The bloodline entrance used to play on mount, and on a phone that is below the
// fold: the generations settled with nobody watching. This resolves at first sight
// instead, and the page holds the chart back until then.
window.duneReveal = {
    once: function (selector) {
        const el = document.querySelector(selector);
        if (!el || typeof IntersectionObserver !== "function") {
            return Promise.resolve(true);
        }
        return new Promise(function (resolve) {
            const observer = new IntersectionObserver(function (entries) {
                if (entries.some(function (entry) { return entry.isIntersecting; })) {
                    observer.disconnect();
                    resolve(true);
                }
            }, { threshold: 0.2 });
            observer.observe(el);
        });
    },
};

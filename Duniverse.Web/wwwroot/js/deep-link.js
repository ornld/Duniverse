// A ?focus= link centers the record. I measure with getBoundingClientRect and scroll by
// hand, one path for SVG and ordinary elements alike. No element-type branch, no
// scrollIntoView: Chrome won't scroll reliably for SVG <g>. Instant on purpose, since a
// slow scroll from the top on load looks broken.
window.duneScroll = {
    toId: function (id) {
        const el = document.getElementById(id);
        if (!el || !window.innerHeight) {
            return;
        }
        const rect = el.getBoundingClientRect();
        const target = rect.top + window.scrollY - window.innerHeight / 2;
        window.scrollTo({ top: Math.max(0, target), behavior: "auto" });
    },
};

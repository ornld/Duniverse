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

        // A chart that scrolls sideways can hold the record off screen to the right, so the
        // well moves too. Nothing happens where the page already shows the whole chart.
        let well = el.parentElement;
        while (well && well !== document.body) {
            const style = window.getComputedStyle(well);
            if ((style.overflowX === "auto" || style.overflowX === "scroll")
                && well.scrollWidth > well.clientWidth) {
                const node = el.getBoundingClientRect();
                const frame = well.getBoundingClientRect();
                well.scrollLeft += (node.left + node.width / 2) - (frame.left + frame.width / 2);
                return;
            }
            well = well.parentElement;
        }
    },
};

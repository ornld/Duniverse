// When a link brings someone in with ?focus=, the record they want might sit way down
// the page. This scrolls it to the center of the screen so they land looking right at it.
//
// I can't just use scrollIntoView here: the targets are SVG <g> nodes, and Chrome doesn't
// reliably scroll the page for those. Measuring with getBoundingClientRect and scrolling
// by hand works for SVG and regular elements alike. The jump is instant on purpose, since
// a slow scroll from the top on page load just looks broken.
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

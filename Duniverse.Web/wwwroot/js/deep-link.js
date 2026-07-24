// A record handed into a page through a query param may sit below the fold. This centers
// the matching element in the viewport so the reader lands already looking at the
// highlight, rather than at a page that appears unchanged.
//
// It scrolls by computed offset rather than element.scrollIntoView, because the targets
// are SVG <g> nodes inside the charts, and scrollIntoView on an SVG sub-element does not
// reliably move the document in Chromium. getBoundingClientRect reads the same on SVG and
// HTML, so centering by hand is the portable path. The jump is instant on purpose: a
// smooth scroll from the top on first load reads as jank, and a deep-link landing wants
// the record framed immediately.
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

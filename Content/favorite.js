// ¼ÓÔØÊ±äÖÈ¾ºìÐÄ
document.addEventListener("DOMContentLoaded", () => {
    document.querySelectorAll('.heart').forEach(h => {
        const id = h.dataset.id || h.closest('.card')?.dataset.id || h.closest('.left')?.querySelector('button')?.dataset.id;
        if (localStorage['fav_' + id]) h.classList.add('on');
    });
});

function toggleFav(id, el) {
    const key = 'fav_' + id;
    if (localStorage[key]) {
        localStorage.removeItem(key);
        el.classList.remove('on');
    } else {
        localStorage[key] = 1;
        el.classList.add('on');
    }
}
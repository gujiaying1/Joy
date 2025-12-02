// ½¥±ä·­Ò³
let idx = 0;
const imgs = document.querySelectorAll('.hero-slider img');
setInterval(() => {
    imgs[idx].classList.remove('active');
    idx = (idx + 1) % imgs.length;
    imgs[idx].classList.add('active');
}, 4000);

// Æ½»¬¹ö¶¯
function smoothScroll(targetId) {
    document.getElementById(targetId).scrollIntoView({ behavior: 'smooth' });
}

// ½¥±äÂÖ²¥
let idx = 0;
const imgs = document.querySelectorAll('.slides img');
setInterval(() => {
    imgs[idx].classList.remove('active');
    idx = (idx + 1) % imgs.length;
    imgs[idx].classList.add('active');
}, 4000);
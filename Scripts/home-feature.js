  /* ========== Parallax ========== */
    window.addEventListener("scroll", () => {
        const offset = window.scrollY * .35;
        document.querySelectorAll(".banner img").forEach(img => {
        img.style.transform = `translateY(${offset}px)`;
        });
    });

    /* ========== Scroll Reveal ========== */
    const revealEls = document.querySelectorAll(".reveal");
    function reveal() {
        revealEls.forEach(el => {
            const rect = el.getBoundingClientRect().top;
            if (rect < window.innerHeight * .85) {
                el.classList.add("visible");
            }
        });
    }
    window.addEventListener("scroll", reveal);
    window.addEventListener("load", reveal);

    /* ========== Slider ========== */
    const slides = document.querySelectorAll('.slide');
    let idx = 0;
    setInterval(() => {
        slides[idx].classList.remove('active');
    idx = (idx + 1) % slides.length;
    slides[idx].classList.add('active');
    }, 5000);
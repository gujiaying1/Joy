(function () {
    const canvas = document.getElementById('occChart');
    if (!canvas) return;
    const ctx = canvas.getContext('2d');
    const W = canvas.width;
    const H = canvas.height;
    const barW = W / 24;

    function fetchAndDraw() {
        fetch('@Url.Action("GetCurrent", "Occupancy")')
            .then(r => r.json())
            .then(data => {
                draw(data);
                setInfo(data);
            });
    }

    function draw(data) {
        ctx.clearRect(0, 0, W, H);
        const max = Math.max(...data.map(o => o.max));
        data.forEach((o, i) => {
            const h = (o.count / max) * (H - 40);
            const x = i * barW;
            ctx.fillStyle = o.count > max * 0.8 ? '#e53935' : '#3AC6A8';
            ctx.fillRect(x + 2, H - h - 20, barW - 4, h);
            if (i % 3 === 0) {
                ctx.fillStyle = '#666'; ctx.font = '12px Arial';
                ctx.fillText(o.time.substr(11, 5), x + 4, H - 5);
            }
        });
    }

    function setInfo(data) {
        if (!data.length) return;
        const curr = data[data.length - 1].count;
        const peak = Math.max(...data.map(o => o.count));
        document.getElementById('peak').textContent = `峰值 ${peak} 人`;
        document.getElementById('suggest').textContent =
            curr > 60 ? '当前高峰，建议 14:00 或 20:00 后前往' : '当前空闲，欢迎来锻炼！';
    }

    fetchAndDraw();
    setInterval(fetchAndDraw, 30000);
})();
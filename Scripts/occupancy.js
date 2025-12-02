const canvas = document.getElementById('chart');
const ctx = canvas.getContext('2d');
const W = canvas.width;
const H = canvas.height;
const barW = W / 24;   // 每小时一柱

let data = [];   // 24 条 {Time, Count, Max}

function fetchData() {
    fetch('/Occupancy/GetCurrent')
        .then(r => r.json())
        .then(d => {
            data = d;
            draw();
            setInfo();
        });
}

function draw() {
    ctx.clearRect(0, 0, W, H);
    const max = Math.max(...data.map(o => o.max));   // 80
    data.forEach((o, i) => {
        const h = (o.count / max) * (H - 40);
        const x = i * barW;
        // 柱
        ctx.fillStyle = o.count > max * 0.8 ? '#e53935' : '#3AC6A8';
        ctx.fillRect(x + 2, H - h - 20, barW - 4, h);
        // 时间标签（每 3h 一个）
        if (i % 3 === 0) {
            ctx.fillStyle = '#666';
            ctx.font = '12px Arial';
            ctx.fillText(o.time.substr(11, 5), x + 4, H - 5);
        }
    });
}

function setInfo() {
    const curr = data.length ? data[data.length - 1].count : 0;
    const peak = Math.max(...data.map(o => o.count));
    document.getElementById('peak').textContent = `峰值 ${peak} 人`;
    document.getElementById('suggest').textContent =
        curr > 60 ? '当前高峰，建议 14:00 或 20:00 后前往' : '当前空闲，欢迎来锻炼！';
}

// 首次加载 + 定时刷新
fetchData();
setInterval(fetchData, 30000);   // 30 s
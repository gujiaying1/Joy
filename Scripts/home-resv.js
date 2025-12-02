// 平滑滚动
function smoothScroll(targetId) {
    document.getElementById(targetId).scrollIntoView({ behavior: 'smooth' });
}

// 加载时段格子（抄原 reservation.js 稍作改名）
function loadSlots(date) {
    fetch(`/Reservation/GetSlots?date=${date}`)
        .then(r => r.json())
        .then(data => {
            let html = '';
            data.forEach(s => {
                const free = s.max - s.current;
                html += `<div class="slot ${free === 0 ? 'full' : ''}" data-hour="${s.hour}" onclick="selectSlot(this,${s.hour})">
               <div class="time">${s.hour}:00</div>
               <div class="num">${free}<span>/${s.max}</span></div>
             </div>`;
            });
            document.getElementById('slotPanel').innerHTML = html;
            document.getElementById('confirmBtn').style.display = 'none';
        });
}

// 选中时段
function selectSlot(el, hour) {
    document.querySelectorAll('.slot').forEach(x => x.classList.remove('sel'));
    el.classList.add('sel');
    document.getElementById('confirmBtn').style.display = 'inline-block';
    document.getElementById('confirmBtn').onclick = () => showModal(hour);
}

// 弹窗确认（简版）
function showModal(hour) {
    const dto = {
        Date: document.querySelector('.day-btn.on').dataset.day,
        Hour: hour,
        Count: 1
    };
    if (!confirm(`确认预约 ${dto.Date}  ${hour}:00 ？`)) return;
    fetch('/Reservation/Reserve', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(dto)
    })
        .then(r => r.json())
        .then(res => {
            alert(res.ok ? '预约成功！' : '失败：' + res.msg);
            if (res.ok) loadSlots(dto.Date);   // 刷新格子
        });
}

// 默认加载今天
window.onload = () => {
    document.querySelector('.day-btn').click();
};
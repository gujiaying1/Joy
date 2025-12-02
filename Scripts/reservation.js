let selDate = '', selHour = 0;

// 初始化：默认选中今天
window.onload = () => {
    document.querySelector('.day-btn').click();
};

// 日期按钮
document.querySelectorAll('.day-btn').forEach(b => {
    b.addEventListener('click', e => {
        document.querySelectorAll('.day-btn').forEach(x => x.classList.remove('on'));
        b.classList.add('on');
        selDate = b.dataset.day;
        loadSlots(selDate);
    });
});

// 加载时段
function loadSlots(date) {
    fetch(`/Reservation/GetSlots?date=${date}`)
        .then(r => r.json())
        .then(data => {
            let html = '';
            data.forEach(s => {
                const free = s.max - s.current;
                html += `<div class="slot ${free === 0 ? 'full' : ''}" data-hour="${s.hour}">
           <span class="h">${s.hour}:00</span>
           <span class="c">${free}</span>/<span class="m">${s.max}</span>
         </div>`;
            });
            document.getElementById('slotPanel').innerHTML = html;
            document.getElementById('confirmBtn').style.display = 'none';

            // 绑定点击
            document.querySelectorAll('.slot:not(.full)').forEach(d => {
                d.addEventListener('click', () => {
                    document.querySelectorAll('.slot').forEach(x => x.classList.remove('sel'));
                    d.classList.add('sel');
                    selHour = parseInt(d.dataset.hour);
                    document.getElementById('confirmBtn').style.display = 'inline-block';
                });
            });
        });
}

// 打开弹窗
document.getElementById('confirmBtn').onclick = () => {
    document.getElementById('mDate').textContent = selDate;
    document.getElementById('mHour').textContent = selHour;
    document.getElementById('mEnd').textContent = selHour + 1;
    document.getElementById('resvModal').style.display = 'block';
};

// 关闭弹窗
document.querySelector('.close').onclick = () => {
    document.getElementById('resvModal').style.display = 'none';
};

// 提交
document.getElementById('submitBtn').onclick = () => {
    const dto = {
        Date: selDate,
        Hour: selHour,
        Count: parseInt(document.getElementById('mCount').value)
    };
    fetch('/Reservation/Reserve', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(dto)
    })
        .then(r => r.json())
        .then(res => {
            alert(res.ok ? '预约成功！' : '失败：' + res.msg);
            if (res.ok) {
                document.getElementById('resvModal').style.display = 'none';
                loadSlots(selDate); // 刷新格子
            }
        });
};
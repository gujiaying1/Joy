
    // 添加到训练计划函数
        function addToWorkoutPlan(equipmentId, element) {
        // 获取设备名称
        const card = element.closest('.card');
        const equipmentName = card.querySelector('h3').textContent;

        // 获取防伪令牌
        const token = document.querySelector('input[name="__RequestVerificationToken"]').value;

        // 发送AJAX请求
        fetch('@Url.Action("AddToWorkoutPlan", "Generator")', {
            method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        'X-Requested-With': 'XMLHttpRequest'
            },
        body: JSON.stringify({
            equipmentId: equipmentId,
        equipmentName: equipmentName
            })
        })
        .then(response => {
            if (response.ok) {
                return response.json();
            }
        throw new Error('Network response was not ok.');
        })
        .then(data => {
            if (data.success) {
            // 更新爱心样式
            element.classList.add('on');
        element.style.color = '#e91e63';

        // 保存到localStorage
        localStorage.setItem(`plan_${equipmentId}`, 'true');

        // 显示成功通知
        showToast(`"${equipmentName}" added to My Plan!`);
            } else {
            showToast(data.message || 'Failed to add to plan', 'error');
            }
        })
        .catch(error => {
            console.error('Error:', error);
        showToast('Failed to save. Please try again.', 'error');
        });
    }

        // 显示Toast通知
        function showToast(message, type = 'success') {
        // 移除现有toast
        const existingToast = document.querySelector('.custom-toast');
        if (existingToast) {
            existingToast.remove();
        }

        // 创建新toast
        const toast = document.createElement('div');
        toast.className = `custom-toast ${type}`;
        toast.innerHTML = `
        <div class="toast-content">
            <i class="fas fa-${type === 'success' ? 'check-circle' : 'exclamation-circle'}"></i>
            <span>${message}</span>
        </div>
        `;

        // 添加样式
        toast.style.cssText = `
        position: fixed;
        bottom: 24px;
        right: 24px;
        background: ${type === 'success' ? '#34c759' : '#ff3b30'};
        color: white;
        padding: 12px 20px;
        border-radius: 12px;
        z-index: 10000;
        font-weight: 500;
        box-shadow: 0 4px 20px rgba(0,0,0,0.2);
        animation: slideInUp 0.3s ease;
        max-width: 300px;
        backdrop-filter: blur(20px);
        border: 1px solid rgba(255,255,255,0.2);
        `;

        document.body.appendChild(toast);

        // 3秒后移除
        setTimeout(() => {
            toast.style.animation = 'slideOutDown 0.3s ease';
            setTimeout(() => toast.remove(), 300);
        }, 3000);
    }

        // 页面加载时检查哪些设备已在计划中
        document.addEventListener('DOMContentLoaded', function() {
        // 添加CSS动画
        const style = document.createElement('style');
        style.textContent = `
        @@keyframes slideInUp {
            from {transform: translateY(100%); opacity: 0; }
        to {transform: translateY(0); opacity: 1; }
            }
        @@keyframes slideOutDown {
            from {transform: translateY(0); opacity: 1; }
        to {transform: translateY(100%); opacity: 0; }
            }
        .heart {
            cursor: pointer;
        font-size: 1.3rem;
        color: #ccc;
        transition: color 0.3s, transform 0.3s;
            }
        .heart:hover {
            transform: scale(1.2);
            }
        .heart.on {
            color: #e91e63 !important;
        animation: heartBeat 0.5s;
            }
        @@keyframes heartBeat {
            0 % { transform: scale(1); }
                25% {transform: scale(1.3); }
        50% {transform: scale(1); }
        75% {transform: scale(1.2); }
        100% {transform: scale(1); }
            }
        `;
        document.head.appendChild(style);

        // 检查localStorage的收藏状态
        document.querySelectorAll('.card').forEach(card => {
            const equipmentId = card.getAttribute('data-id');
        const heart = card.querySelector('.heart');
        if (localStorage.getItem(`plan_${equipmentId}`)) {
            heart.classList.add('on');
        heart.style.color = '#e91e63';
            }
        });
    });

    window.addEventListener('load', () => document.querySelectorAll('.reveal').forEach(e => e.classList.add('visible')));
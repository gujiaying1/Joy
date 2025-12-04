    document.addEventListener('DOMContentLoaded', function() {
        console.log('Equipment Detail Page Loaded');

        // 初始化步骤列表
        initStepsList();

        // 初始化画廊
        initGallery();

        // 加载保存的视频偏好
        loadVideoPreference();
    });

    // 根据部位初始化步骤
    function initStepsList() {
        const part = '@Model.Part.ToString().ToLower()';
        const stepsList = document.getElementById('stepsList');

        const steps = {
            'chest': [
                { text: "Adjust the seat height so handles align with mid-chest level. Ensure back pad provides full support.", tip: "Proper alignment reduces shoulder strain" },
                { text: "Sit firmly with back against pad, feet flat on floor. Grip handles with palms facing forward.", tip: "Maintain neutral spine throughout" },
                { text: "Push handles forward until arms are fully extended. Exhale during exertion.", tip: "Don't lock elbows at extension" },
                { text: "Squeeze chest muscles at peak contraction for 1-2 seconds. Focus on mind-muscle connection.", tip: "Visualize bringing elbows together" },
                { text: "Slowly return to starting position over 3-4 seconds. Keep tension on chest.", tip: "Control is key for muscle growth" }
            ],
            'legs': [
                { text: "Adjust machine to fit your body. Set seat depth, back pad position, and foot placement.", tip: "Knees should align with pivot point" },
                { text: "Position yourself with proper back support. Feet shoulder-width apart, toes slightly out.", tip: "Keep heels flat on platform" },
                { text: "Execute movement through full range of motion. Lower until knees form 90-degree angle.", tip: "Don't bounce at bottom position" },
                { text: "Focus on contracting quadriceps and glutes. Push through heels, not toes.", tip: "Squeeze glutes at top" },
                { text: "Maintain controlled tempo: 2 seconds up, 1 second pause, 3 seconds down.", tip: "Time under tension builds muscle" }
            ],
            'back': [
                { text: "Adjust seat and pad position to align with chest. Feet flat on floor, slight bend in knees.", tip: "Proper height prevents shoulder impingement" },
                { text: "Grip handles with palms facing each other or down, depending on attachment. Sit upright.", tip: "Use straps for heavier weights" },
                { text: "Pull handles toward chest while squeezing shoulder blades together. Keep chest up.", tip: "Initiate with back, not arms" },
                { text: "Hold for a moment at peak contraction. Feel the squeeze between shoulder blades.", tip: "Imagine holding a pencil between shoulder blades" },
                { text: "Slowly return to starting position, maintaining control. Stretch at full extension.", tip: "Control the eccentric for maximum growth" }
            ],
            'arms': [
                { text: "Set cable at appropriate height for exercise. Adjust weight stack to challenging but manageable.", tip: "Lighter weight with perfect form is better" },
                { text: "Stand with proper posture, keeping elbows close to body. Maintain slight bend in knees.", tip: "Anchor elbows to prevent swinging" },
                { text: "Execute movement with controlled form. Isolate biceps or triceps with strict technique.", tip: "Stop short of full lockout" },
                { text: "Squeeze target muscles at peak of contraction. Hold for maximum contraction.", tip: "Peak contraction increases muscle activation" },
                { text: "Return slowly to maintain tension on muscles. 3-4 seconds on negative phase.", tip: "Negative reps cause most muscle damage" }
            ],
            'shoulders': [
                { text: "Adjust seat height so handles align with shoulder height. Sit with back supported.", tip: "Use mirrors to check alignment" },
                { text: "Grip handles with palms facing forward. Keep wrists straight throughout movement.", tip: "Don't let wrists bend backward" },
                { text: "Press upward until arms are fully extended overhead. Keep slight bend in elbows at top.", tip: "Don't lock out joints" },
                { text: "Lower weight with control back to starting position. 3-second negative phase.", tip: "Control the descent" },
                { text: "Keep core engaged throughout movement to protect lower back.", tip: "Brace your core as if preparing for a punch" }
            ]
        };

        const defaultSteps = [
            { text: "Set up equipment according to your body measurements and flexibility.", tip: "Proper setup prevents injury" },
            { text: "Assume correct starting position with proper spinal alignment and joint angles.", tip: "Form before weight" },
            { text: "Execute movement through full natural range of motion. Don't force beyond comfort.", tip: "Quality over quantity" },
            { text: "Focus on contracting target muscle group. Mind-muscle connection is crucial.", tip: "Think about the muscle working" },
            { text: "Return to starting position with controlled tempo. Maintain tension throughout.", tip: "Never let momentum do the work" }
        ];

        const selectedSteps = steps[part] || defaultSteps;

        stepsList.innerHTML = '';
        selectedSteps.forEach((step, index) => {
            const stepItem = document.createElement('li');
            stepItem.className = 'step-item';
            stepItem.innerHTML = `
                <div class="step-number">${index + 1}</div>
                <div class="step-content">
                    <p>${step.text}</p>
                    ${step.tip ? `<span class="step-tip">💡 ${step.tip}</span>` : ''}
                </div>
            `;
            stepsList.appendChild(stepItem);
        });
    }

    // 画廊功能
    let currentSlide = 0;
    let slideInterval;

    function initGallery() {
        const slides = document.querySelectorAll('.gallery-slide');
        const dots = document.querySelectorAll('.dot');

        if (slides.length > 0) {
            showSlide(0);
            startSlideShow();
        }
    }

    function showSlide(index) {
        const slides = document.querySelectorAll('.gallery-slide');
        const dots = document.querySelectorAll('.dot');

        if (index >= slides.length) index = 0;
        if (index < 0) index = slides.length - 1;

        slides.forEach(slide => slide.classList.remove('active'));
        dots.forEach(dot => dot.classList.remove('active'));

        slides[index].classList.add('active');
        dots[index].classList.add('active');
        currentSlide = index;
    }

    function startSlideShow() {
        clearInterval(slideInterval);
        slideInterval = setInterval(() => {
            nextGallery();
        }, 5000);
    }

    function prevGallery() {
        showSlide(currentSlide - 1);
        startSlideShow();
    }

    function nextGallery() {
        showSlide(currentSlide + 1);
        startSlideShow();
    }

    function goToSlide(index) {
        showSlide(index);
        startSlideShow();
    }

    // 视频功能
    function showVideoSelector() {
        const selector = document.getElementById('videoSelector');
        selector.style.display = 'block';
    }

    function hideVideoSelector() {
        const selector = document.getElementById('videoSelector');
        selector.style.display = 'none';
    }

    function changeVideo(videoId) {
        const iframe = document.getElementById('bilibiliPlayer');
        iframe.src = `https://player.bilibili.com/player.html?bvid=${videoId}&page=1&high_quality=1&autoplay=0`;

        // 更新选中的视频
        document.querySelectorAll('.video-option').forEach(option => {
            option.classList.remove('active');
            if (option.dataset.video === videoId) {
                option.classList.add('active');
            }
        });

        hideVideoSelector();
        showNotification('Video changed successfully');

        // 保存偏好
        saveVideoPreference(videoId);
    }

    function loadCustomVideo() {
        const input = document.getElementById('customVideoUrl');
        const url = input.value.trim();

        if (!url) {
            showNotification('Please enter a video URL', 'error');
            return;
        }

        // 提取视频ID
        let videoId = extractBilibiliVideoId(url);

        if (videoId) {
            changeVideo(videoId);
            input.value = '';
        } else {
            showNotification('Invalid Bilibili video URL', 'error');
        }
    }

    function extractBilibiliVideoId(url) {
        // 支持多种B站视频链接格式
        const patterns = [
            /[Bb][Vv]([a-zA-Z0-9]{10})/,
            /av(\d+)/i,
            /video\/([a-zA-Z0-9]+)/,
            /b23\.tv\/[a-zA-Z0-9]+\/?.*[Bb][Vv]([a-zA-Z0-9]{10})/
        ];

        for (const pattern of patterns) {
            const match = url.match(pattern);
            if (match) {
                return match[0];
            }
        }

        return null;
    }

    function saveVideoPreference(videoId = null) {
        const equipmentId = @Model.Id;
        const currentVideoId = videoId || document.getElementById('bilibiliPlayer').src.match(/bvid=([a-zA-Z0-9]+)/)[1];

        // 这里可以添加保存到后端的逻辑
        localStorage.setItem(`video_pref_${equipmentId}`, currentVideoId);
        showNotification('Video preference saved');
    }

    function loadVideoPreference() {
        const equipmentId = @Model.Id;
        const savedVideoId = localStorage.getItem(`video_pref_${equipmentId}`);

        if (savedVideoId && savedVideoId !== '@recommendedVideoUrl') {
            changeVideo(savedVideoId);
        }
    }

    // 视频控制功能
    function toggleSlowMotion() {
        const iframe = document.getElementById('bilibiliPlayer');
        // B站iframe API可能需要额外配置
        showNotification('Slow motion feature requires B站播放器API');
    }

    function toggleFullscreen() {
        const container = document.querySelector('.bilibili-video-container');

        if (!document.fullscreenElement) {
            if (container.requestFullscreen) {
                container.requestFullscreen();
            } else if (container.webkitRequestFullscreen) {
                container.webkitRequestFullscreen();
            } else if (container.msRequestFullscreen) {
                container.msRequestFullscreen();
            }
        } else {
            if (document.exitFullscreen) {
                document.exitFullscreen();
            } else if (document.webkitExitFullscreen) {
                document.webkitExitFullscreen();
            } else if (document.msExitFullscreen) {
                document.msExitFullscreen();
            }
        }
    }

    // 训练计时器
    let workoutTimer = null;
    let workoutSeconds = 0;

    function startWorkoutTimer() {
        const timerBtn = document.querySelector('.timer-btn i');
        const timerDisplay = document.getElementById('workoutTimer');

        if (workoutTimer) {
            // 停止计时器
            clearInterval(workoutTimer);
            workoutTimer = null;
            timerBtn.className = 'fas fa-play';
            showNotification('Workout timer stopped');
        } else {
            // 开始计时器
            workoutTimer = setInterval(() => {
                workoutSeconds++;
                const minutes = Math.floor(workoutSeconds / 60);
                const seconds = workoutSeconds % 60;
                timerDisplay.textContent = `${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')}`;

                // 每5分钟提醒
                if (workoutSeconds % 300 === 0) {
                    showNotification(`Great work! You've been training for ${minutes} minutes.`);
                }
            }, 1000);
            timerBtn.className = 'fas fa-pause';
            showNotification('Workout timer started');
        }
    }

    // 保存到训练计划
    function saveToWorkoutPlan() {
        const equipmentId = @Model.Id;
        const equipmentName = '@Model.Name';

        // 这里可以添加AJAX调用保存到后端
        const savedWorkouts = JSON.parse(localStorage.getItem('saved_workouts') || '[]');
        if (!savedWorkouts.includes(equipmentId)) {
            savedWorkouts.push(equipmentId);
            localStorage.setItem('saved_workouts', JSON.stringify(savedWorkouts));
        }

        showNotification(`"${equipmentName}" added to your workout plan`);
    }

    // 下载PDF
    function downloadGuide() {
        showNotification('Generating PDF guide... (This would generate a PDF in production)');
        // 在实际项目中，这里会调用后端API生成PDF
    }

    // 分享功能
    function shareEquipment() {
        const equipmentName = '@Model.Name';
        const pageUrl = window.location.href;

        if (navigator.share) {
            navigator.share({
                title: equipmentName,
                text: `Check out this ${equipmentName} exercise guide`,
                url: pageUrl
            });
        } else {
            // 复制到剪贴板
            navigator.clipboard.writeText(pageUrl).then(() => {
                showNotification('Link copied to clipboard!');
            });
        }
    }

    // 模态框控制
    function openModal(content) {
        const modal = document.getElementById('videoModal');
        const modalBody = modal.querySelector('.modal-body');

        modalBody.innerHTML = content;
        modal.style.display = 'flex';
    }

    function closeModal() {
        const modal = document.getElementById('videoModal');
        modal.style.display = 'none';
    }

    // 通知系统
    function showNotification(message, type = 'success') {
        // 移除现有通知
        const existingNotification = document.querySelector('.notification');
        if (existingNotification) {
            existingNotification.remove();
        }

        // 创建新通知
        const notification = document.createElement('div');
        notification.className = `notification ${type}`;
        notification.innerHTML = `
            <div class="notification-content">
                <i class="fas fa-${type === 'success' ? 'check-circle' : 'exclamation-circle'}"></i>
                <span>${message}</span>
            </div>
        `;

        // 添加样式
        notification.style.cssText = `
            position: fixed;
            top: 32px;
            right: 32px;
            background: ${type === 'success' ? 'var(--secondary-color)' : 'var(--danger-color)'};
            color: white;
            padding: 16px 24px;
            border-radius: 16px;
            z-index: 10000;
            font-weight: 500;
            box-shadow: var(--shadow-lg);
            animation: slideIn 0.3s ease;
            max-width: 400px;
            backdrop-filter: blur(20px);
            border: 1px solid rgba(255, 255, 255, 0.2);
        `;

        document.body.appendChild(notification);

        // 3秒后移除
        setTimeout(() => {
            notification.style.animation = 'slideOut 0.3s ease';
            setTimeout(() => notification.remove(), 300);
        }, 3000);
    }



    // 视频选项点击事件
    document.querySelectorAll('.video-option').forEach(option => {
        option.addEventListener('click', () => {
            const videoId = option.dataset.video;
            changeVideo(videoId);
        });
    });

    // 相选项点击事件
    document.querySelectorAll('.phase').forEach(phase => {
        phase.addEventListener('click', () => {
            document.querySelectorAll('.phase').forEach(p => p.classList.remove('active'));
            phase.classList.add('active');

            // 根据阶段筛选步骤
            const phaseType = phase.dataset.phase;
            filterStepsByPhase(phaseType);
        });
    });

    function filterStepsByPhase(phase) {
        // 这里可以根据阶段显示不同的步骤
        // 在实际项目中，可以预先定义不同阶段的步骤
        console.log(`Filtering steps by phase: ${phase}`);

    }

// 保存到训练计划
function saveToWorkoutPlan() {
    const equipmentId = @Model.Id;
    const equipmentName = '@Model.Name';

    fetch('@Url.Action("AddToWorkoutPlan", "Workout")', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val()
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
            showNotification('"' + equipmentName + '" has been added to your workout plan!', 'success');

            // 更新爱心状态
            updateFavoriteStatus(equipmentId, true);
        } else {
            showNotification(data.message || 'Failed to add to plan', 'error');
        }
    })
    .catch(error => {
        console.error('Error:', error);
        showNotification('Failed to save. Please try again.', 'error');
    });
}

// 更新爱心状态
function updateFavoriteStatus(equipmentId, isFavorite) {
    // 在详细页更新爱心
    const heartBtn = document.querySelector('.btn-fav');
    if (heartBtn) {
        heartBtn.innerHTML = isFavorite ?
            '<i class="fas fa-heart"></i> In My Plan' :
            '<i class="far fa-heart"></i> Add to Plan';
        heartBtn.style.background = isFavorite ?
            'linear-gradient(135deg, #e91e63, #c2185b)' :
            'linear-gradient(135deg, #007aff, #0056d6)';
    }

    // 同时在列表页更新（如果用户返回列表页）
    updateListFavoriteStatus(equipmentId, isFavorite);
}

// 更新列表页爱心状态
function updateListFavoriteStatus(equipmentId, isFavorite) {
    const listHearts = document.querySelectorAll(`.heart[data-id="${equipmentId}"]`);
    listHearts.forEach(heart => {
        if (isFavorite) {
            heart.classList.add('on');
            heart.style.color = '#e91e63';
        } else {
            heart.classList.remove('on');
            heart.style.color = '#ccc';
        }
    });
}

// 初始化检查是否已加入计划
function checkIfInWorkoutPlan() {
    const equipmentId = @Model.Id;

    fetch('@Url.Action("IsInWorkoutPlan", "Workout")?equipmentId=' + equipmentId)
    .then(response => response.json())
    .then(data => {
        if (data.isInPlan) {
            updateFavoriteStatus(equipmentId, true);
        }
    });
}

// 页面加载时检查
document.addEventListener('DOMContentLoaded', function() {
    checkIfInWorkoutPlan();
});

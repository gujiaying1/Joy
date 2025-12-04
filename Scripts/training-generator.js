
    $(function () {
        console.log('Training Generator loaded');

        // Form submission
        $('#genForm').on('submit', function (e) {
            e.preventDefault();

            // Show loading state
            const $btn = $(this).find('.generate-btn');
            $btn.find('.btn-text').hide();
            $btn.find('.btn-loader').show();
            $btn.prop('disabled', true);

            console.log('Generating workout plan...');
            console.log('Form data:', $(this).serialize());

            $.ajax({
                url: '@Url.Action("Generate", "Generator")',
                type: 'POST',
                data: $(this).serialize(),
                success: function (result) {
                    console.log('Workout generated successfully');
                    console.log('Result:', result);

                    // Restore button state
                    $btn.find('.btn-text').show();
                    $btn.find('.btn-loader').hide();
                    $btn.prop('disabled', false);

                    // Show results section
                    $('#resultSection').show();
                    $('#result').html(result);

                    // Add click events for generated cards
                    $('.exercise-card').off('click').on('click', function () {
                        $(this).toggleClass('selected');
                        updateSaveButton();
                    });

                    // Scroll to results section
                    $('html, body').animate({
                        scrollTop: $('#resultSection').offset().top - 100
                    }, 500);
                },
                error: function (xhr, status, error) {
                    console.error('Error generating workout:', error);
                    console.error('Status:', status);
                    console.error('XHR:', xhr);

                    // Restore button state
                    $btn.find('.btn-text').show();
                    $btn.find('.btn-loader').hide();
                    $btn.prop('disabled', false);

                    $('#resultSection').show();
                    $('#result').html('<div class="empty-state"><p>Error generating workout plan. Please try again.</p></div>');
                }
            });
        });

        // Initialize loading of my plan
        loadMyPlan();
    });
    // 在生成器页面的JavaScript中添加
function addFromGenerator(equipmentId, element) {
    const equipmentName = element.closest('.exercise-card').querySelector('.exercise-name').textContent;

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
    .then(response => response.json())
    .then(data => {
        if (data.success) {
            showToast(`"${equipmentName}" added to My Plan!`);
            // 可以在这里添加按钮状态变化
        } else {
            showToast(data.message, 'error');
        }
    });
}
    // Update save button
    function updateSaveButton() {
        const selectedCount = $('.exercise-card.selected').length;

        if (selectedCount > 0) {
            $('#saveActions').show();
            $('#selectedCount').text(selectedCount);
        } else {
            $('#saveActions').hide();
        }
    }

    // Save plan
    function savePlan() {
        const selectedIds = $('.exercise-card.selected').map(function () {
            return $(this).data('id');
        }).get();

        if (selectedIds.length === 0) {
            alert('Please select at least one exercise to add to your plan.');
            return;
        }

        console.log('Saving plan with IDs:', selectedIds);

        $.ajax({
            url: '@Url.Action("SavePlan", "Generator")',
            type: 'POST',
            data: { ids: selectedIds },
            traditional: true,
            success: function (result) {
                console.log('Plan saved successfully:', result);

                if (result.ok) {
                    // Show success message
                    showNotification('Exercises added to your plan successfully!');

                    // Refresh my plan
                    loadMyPlan();

                    // Reset selection state
                    $('.exercise-card.selected').removeClass('selected');
                    $('#saveActions').hide();
                }
            },
            error: function (xhr, status, error) {
                console.error('Error saving plan:', error);
                alert('Error saving plan. Please try again.');
            }
        });
    }

    // Delete plan item
    function delPlan(id) {
        if (!confirm('Are you sure you want to remove this exercise from your plan?')) {
            return;
        }

        console.log('Deleting plan item:', id);

        $.ajax({
            url: '@Url.Action("RemoveFromPlan", "Generator")',
            type: 'POST',
            data: { id: id },
            success: function (result) {
                console.log('Item deleted successfully:', result);

                if (result.ok) {
                    showNotification('Exercise removed from your plan.');
                    loadMyPlan();
                }
            },
            error: function (xhr, status, error) {
                console.error('Error deleting item:', error);
                alert('Error removing exercise. Please try again.');
            }
        });
    }

    // Load my plan
    function loadMyPlan() {
        $.ajax({
            url: '@Url.Action("MyPlan", "Generator")',
            type: 'GET',
            success: function (result) {
                $('#planList').html(result);
            },
            error: function (xhr, status, error) {
                console.error('Error loading plan:', error);
            }
        });
    }

    // Show notification
    function showNotification(message) {
        // Create notification element
        const notification = $('<div class="notification">')
            .text(message)
            .css({
                position: 'fixed',
                top: '20px',
                right: '20px',
                background: '#0071e3',
                color: 'white',
                padding: '12px 20px',
                borderRadius: '8px',
                boxShadow: '0 4px 12px rgba(0, 0, 0, 0.15)',
                zIndex: '1000',
                fontSize: '14px',
                fontWeight: '500'
            });

        // Add to page
        $('body').append(notification);

        // Remove after 3 seconds
        setTimeout(() => {
            notification.fadeOut(300, function() {
                $(this).remove();
            });
        }, 3000);
    }

    // Bind save button click event
    $(document).on('click', '#savePlanBtn', savePlan);
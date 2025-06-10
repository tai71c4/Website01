// Home page functionality
$(document).ready(function() {
    // Assign appropriate icons to categories with animation
    if ($('.category-card').length > 0) {
        $('.category-card').each(function(index) {
            const categoryTitle = $(this).find('.category-title').text().trim().toLowerCase();
            let iconClass = 'fa-mobile-alt';
            
            if (categoryTitle.includes('ốp lưng')) {
                iconClass = 'fa-mobile-alt';
            } else if (categoryTitle.includes('kính')) {
                iconClass = 'fa-glasses';
            } else if (categoryTitle.includes('cáp') || categoryTitle.includes('sạc')) {
                iconClass = 'fa-plug';
            } else if (categoryTitle.includes('pin')) {
                iconClass = 'fa-battery-full';
            } else if (categoryTitle.includes('tai nghe') || categoryTitle.includes('âm thanh')) {
                iconClass = 'fa-headphones';
            }
            
            // Add animation delay based on index
            const delay = index * 0.1;
            $(this).css('animation-delay', delay + 's');
            $(this).addClass('animate-in');
            
            $(this).find('.category-icon i').removeClass('fa-mobile-alt').addClass(iconClass);
        });
    }
    
    // Smooth hover transition for category cards
    $('.category-card').hover(
        function() {
            $(this).find('.category-icon i').css('transform', 'scale(1.2)');
            $(this).find('.category-icon i').css('color', '#fff');
            $(this).find('.category-title').css('color', '#ffc107');
        },
        function() {
            $(this).find('.category-icon i').css('transform', 'scale(1)');
            $(this).find('.category-icon i').css('color', '#ffc107');
            $(this).find('.category-title').css('color', '#222');
        }
    );
});
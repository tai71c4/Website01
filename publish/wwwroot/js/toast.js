// Toast notification functionality
$(document).ready(function() {
    // Auto-hide toasts after 5 seconds
    setTimeout(function() {
        $('.toast').toast('hide');
    }, 5000);
    
    // Initialize all tooltips
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl)
    });
});
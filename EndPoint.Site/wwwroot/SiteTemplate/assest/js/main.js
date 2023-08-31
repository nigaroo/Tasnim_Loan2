jQuery(document).ready(function () {

    // enter just number in text inputs
    jQuery("input[name='onlynumbers']").on('input', function (e) {
        jQuery(this).val(jQuery(this).val().replace(/[^0-9]/g, ''));
    });


    // change plus to minus
    jQuery('.df-collapse').click(function (e) {
        e.preventDefault();
        jQuery(this).closest('.df-faq').siblings().find('i').addClass('fa-plus')
        jQuery(this).closest('.df-faq').siblings().find('i').removeClass('fa-minus')
        jQuery(this).find('i').toggleClass('fa-plus fa-minus')
    });

    jQuery('.dv-scroll_to').click(function (e) {
        e.preventDefault();
        var jump = jQuery(this).attr('href');
        var new_position = jQuery(jump).offset();
        jQuery('html, body').stop().animate({ scrollTop: new_position.top - 40 }, 700);
    });
});
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('.navbar-container').on('click', '#navMenuBtn', function () {
    displayNavList();
})

function tabsInitial() {
    var tabContainer = $('.tabs-container');
    for (var i = 0; i < tabContainer.length; i++) {
        var $thisTabs = tabContainer.eq(i);
        $thisTabs.find('a.nav-link:first').addClass('active');
        $thisTabs.find('a.nav-link:first').attr('aria-selected', true);
        $thisTabs.find('.tab-pane.fade:first').addClass('show active');
    }
}

function displayNavList() {
    var $navList = $('.nav-item-list');
    var displayType = $navList.css('display');
    if (displayType == 'none') {
        $navList.show();
    }
    else if (displayType == 'block') {
        $navList.hide();
    }
}
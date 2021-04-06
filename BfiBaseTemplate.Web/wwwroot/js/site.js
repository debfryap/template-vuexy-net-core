
function toggleSideMenu() {
    if (localStorage.getItem("menu_collapse") === 'true') {
        console.log('collapse');
        $('body').addClass('menu-collapsed');
        $('body').removeClass('menu-expanded');
    } else {
        console.log('expand');
        $('body').addClass('menu-expanded');
        $('body').removeClass('menu-collapsed');
    }
}
toggleSideMenu();
$('.nav-toggle').click(function () {
    var IsCollapse = localStorage.getItem("menu_collapse") === 'true' ? false : true;
    localStorage.setItem("menu_collapse", IsCollapse);
    toggleSideMenu();
});

function darkMode() {
    var d = new Date();
    var n = d.getHours();
    if (n > 17) {
        $('body').addClass('dark-layout');
    }
    else {
        $('body').removeClass('dark-layout');
    }
}
darkMode();
document.addEventListener("DOMContentLoaded", function () {
    var menuItems = document.querySelectorAll("nav .menu li");
    var menuIcon = document.querySelector(".menu-icon");
    var menu = document.querySelector("nav .menu");

    for (var i = 0; i < menuItems.length; i++) {
        var menuItem = menuItems[i];
        var submenu = menuItem.querySelector(".submenu");

        if (submenu) {
            menuItem.addEventListener("click", function () {
                var isActive = this.classList.contains("active");
                var submenu = this.querySelector(".submenu");

                // Cerrar submenu anterior
                var activeSubmenu = document.querySelector(
                    "nav .menu li.active .submenu"
                );
                if (activeSubmenu && activeSubmenu !== submenu) {
                    activeSubmenu.style.display = "none";
                    activeSubmenu.parentNode.classList.remove("active");
                }

                if (!isActive) {
                    submenu.style.display = "block";
                    this.classList.add("active");
                } else {
                    submenu.style.display = "none";
                    this.classList.remove("active");
                }
            });
        }
    }

    menuIcon.addEventListener("click", function () {
        menu.classList.toggle("responsive");
    });
});

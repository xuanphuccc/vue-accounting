const sidebar = document.getElementById("sidebar");
const sidebarMenu = document.querySelector(".sidebar__menu");
const tippy = document.querySelector(".sidebar__tippy");
const menuElements = document.querySelectorAll(".sidebar__link");

const toggleSidebar = () => {
    if (sidebar) {
        sidebar.classList.toggle("--compact");
    }
};

// show tippy on hover sidebar item
const showTippy = () => {
    Array.from(menuElements).forEach((element) => {
        element.onmouseenter = () => {
            if (sidebar.classList.contains("--compact")) {
                tippy.style.display = "block";
                const linkRect = element.getBoundingClientRect();
                const tippyRect = tippy.getBoundingClientRect();

                // set tippy position
                tippy.style.top =
                    linkRect.top + linkRect.height / 2 - 56 - tippyRect.height / 2 + "px";

                // set tippy content
                tippy.textContent = element.textContent;
            }
        };
    });

    sidebarMenu.onmouseleave = () => {
        tippy.style.display = "none";
    };
};
showTippy();

// open dialog
const openDialog = () => {
    const dialog = document.getElementById("dialog");

    if (dialog) {
        dialog.classList.add("--active");
    }
};

// close dialog
const closeDialog = () => {
    const dialog = document.getElementById("dialog");

    if (dialog) {
        dialog.classList.remove("--active");
    }
};

// stop event bubble
const stopBubbles = (e) => {
    e.stopPropagation();
};

const openDialog = () => {
    const dialog = document.getElementById("dialog");

    if (dialog) {
        dialog.classList.add("--active");
    }
};

const closeDialog = () => {
    const dialog = document.getElementById("dialog");

    if (dialog) {
        dialog.classList.remove("--active");
    }
};

const stopBubbles = (e) => {
    e.stopPropagation();
};

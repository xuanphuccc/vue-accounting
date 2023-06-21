/**
 * Author: txphuc (18/06/2023)
 * Description: Open dialog
 */
const openDialog = () => {
    try {
        const dialog = document.getElementById("dialog");

        if (dialog) {
            dialog.classList.add("--active");
        }
    } catch (error) {
        console.warn(error);
    }
};

/**
 * Author: txphuc (18/06/2023)
 * Description: Close dialog
 */
const closeDialog = () => {
    try {
        const dialog = document.getElementById("dialog");

        if (dialog) {
            dialog.classList.remove("--active");
        }
    } catch (error) {
        console.warn(error);
    }
};

/**
 * Author: txphuc (18/06/2023)
 * Description: Stop event bubble
 */
const stopBubbles = (e) => {
    try {
        e.stopPropagation();
    } catch (error) {
        console.warn(error);
    }
};

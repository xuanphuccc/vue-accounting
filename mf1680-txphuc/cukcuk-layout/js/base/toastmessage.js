/**
 * Author: txphuc (18/06/2023)
 * Description: Show toast message
 */
const showToast = ({
    type = "success",
    title = "Toast title!",
    message = "Toast message",
}) => {
    try {
        const toastList = document.getElementById("toast-list");

        if (toastList) {
            const toastMessage = document.createElement("div");
            toastMessage.style.marginTop = "16px";

            const icons = {
                success: "ms-icon--circle-check-solid",
                error: "ms-icon--circle-exclamation-solid",
                warning: "ms-icon--triangle-exclamation-solid",
                infor: "ms-icon--circle-info-solid",
            };

            toastMessage.innerHTML = `
        <div class="ms-toast --${type}">
            <span
                class="ms-toast__icon ${icons[type]}"
            ></span>
            <div class="ms-toast__content">
                <span class="ms-toast__title">${title}</span>
                <span class="ms-toast__text">${message}</span>
            </div>
            <span class="ms-toast__action">Hoàn tác</span>
            <span
                class="ms-toast__close ms-icon--times"
                title="Đóng"
            ></span>
        </div>
        `;

            toastList.appendChild(toastMessage);

            const autoRemove = setTimeout(() => {
                toastMessage.remove();
            }, 5000);

            toastMessage.onclick = (e) => {
                if (e.target.closest(".ms-toast__close")) {
                    toastMessage.remove();
                    clearTimeout(autoRemove);
                }
            };
        }
    } catch (error) {
        console.warn(error);
    }
};

/**
 * Author: txphuc (18/06/2023)
 * Description: Random toast message
 */
const randomToast = () => {
    try {
        const types = ["success", "error", "warning", "infor"];

        const randNum = Math.floor(Math.random() * 4);
        showToast({ type: types[randNum] });
    } catch (error) {
        console.warn(error);
    }
};

/**
 * Author: txphuc (20/06/2023)
 * Description: Resize table column
 */
const resizeTableColumn = () => {
    try {
        const colResizeBtns = document.querySelectorAll(".ms-table_col-resize");

        Array.from(colResizeBtns).forEach((resizeBtn) => {
            const thElement = resizeBtn.parentElement;

            // enable resizing when resize button pressed
            const activeResize = () => {
                const thElementRect = thElement.getBoundingClientRect();

                // resizing column
                const resizeColumn = (e) => {
                    const mouseX = e.clientX;

                    thElement.style.width = mouseX - thElementRect.left + 4 + "px";
                };

                window.addEventListener("mousemove", resizeColumn);

                // event clean up
                window.onmouseup = () => {
                    window.removeEventListener("mousemove", resizeColumn);
                };
            };

            resizeBtn.addEventListener("mousedown", activeResize);
        });
    } catch (error) {
        console.warn(error);
    }
};
resizeTableColumn();

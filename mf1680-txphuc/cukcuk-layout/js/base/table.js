const colResizeBtns = document.querySelectorAll(".ms-table_col-resize");

Array.from(colResizeBtns).forEach((resizeBtn) => {
    const thElement = resizeBtn.parentElement;

    // enable resizing when resize button pressed
    const activeResize = () => {
        console.log("resizing");

        // resizing column
        const resizeColumn = (e) => {
            const thElementRect = thElement.getBoundingClientRect();
            const mouseX = e.clientX;

            thElement.style.width = mouseX - thElementRect.left + "px";
        };

        window.addEventListener("mousemove", resizeColumn);

        // event clean up
        window.onmouseup = () => {
            console.log("clean up");
            window.removeEventListener("mousemove", resizeColumn);
        };
    };

    resizeBtn.addEventListener("mousedown", activeResize);
});

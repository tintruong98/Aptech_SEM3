const btn = document.querySelector(".btn-toggle");
const theme = document.querySelector("#theme-link");

// Lắng nghe sự kiện click vào button
btn.addEventListener("click", function () {
    // Nếu URL đang là "ligh-theme.css"
    if (theme.getAttribute("href") == "light-theme.css") {
        // thì chuyển nó sang "dark-theme.css"
        theme.href = "dark-theme.css";
    } else {
        // và ngược lại
        theme.href = "light-theme.css";
    }
});
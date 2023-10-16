function togglePassword() {
    var x = document.getElementById("si-pw");
    var icon = document.querySelector(".si-input-pw");

    if (x.type === "password") {
        x.type = "text";
        icon.classList.remove("fa-eye-slash");
        icon.classList.add("fa-eye");
    } else {
        x.type = "password";
        icon.classList.remove("fa-eye");
        icon.classList.add("fa-eye-slash");
    }
}

function validateEmail() {
    var emailInput = document.getElementById("si-email");
    var icon = document.querySelector(".si-input-check");

    var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;

    if (emailPattern.test(emailInput.value)) {
        icon.classList.remove("fa-xmark");
        icon.classList.add("fa-check");
    } else {
        icon.classList.remove("fa-check");
        icon.classList.add("fa-xmark");
    }
}
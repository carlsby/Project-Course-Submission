document.addEventListener("DOMContentLoaded", function () {
    validateFirstName();
    validateLastName();
    validateEmail();
});


function togglePassword() {
    var x = document.getElementById("pw");
    var icon = document.querySelector(".input-pw");

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

function toggleConfirmPassword() {
    var x = document.getElementById("confirm-pw");
    var icon = document.querySelector(".input-confirm-pw");

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

function validateFirstName() {
    var firstNameInput = document.getElementById("firstname");
    var icon = document.querySelector(".firstname-check");

    var firstNamePattern = /^^[a-zA-ZåäöÅÄÖ]+(?:[-\s][a-zA-ZåäöÅÄÖ]+)?$/;

    if (firstNamePattern.test(firstNameInput.value)) {
        icon.classList.remove("fa-xmark");
        icon.classList.add("fa-check");
    } else {
        icon.classList.remove("fa-check");
        icon.classList.add("fa-xmark");
    }
}

function validateLastName() {
    var lastNameInput = document.getElementById("lastname");
    var icon = document.querySelector(".lastname-check");

    var lastNamePattern = /^[a-zA-ZåäöÅÄÖ]+(?:[-\s][a-zA-ZåäöÅÄÖ]+)?$/;

    if (lastNamePattern.test(lastNameInput.value)) {
        icon.classList.remove("fa-xmark");
        icon.classList.add("fa-check");
    } else {
        icon.classList.remove("fa-check");
        icon.classList.add("fa-xmark");
    }
}

function validateEmail() {
    var emailInput = document.getElementById("email");
    var icon = document.querySelector(".email-check");

    var emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

    if (emailPattern.test(emailInput.value)) {
        icon.classList.remove("fa-xmark");
        icon.classList.add("fa-check");
    } else {
        icon.classList.remove("fa-check");
        icon.classList.add("fa-xmark");
    }
}
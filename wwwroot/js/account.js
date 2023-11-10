document.addEventListener("DOMContentLoaded", function () {
    validateForm();

    const inputElements = document.querySelectorAll(".Edit-input");
    inputElements.forEach(function (element) {
        element.addEventListener("input", validateForm);
    });
});

function validateForm() {
    validateFirstName();
    validateLastName();
    validateEmail();
    validatePhoneNumber();
    validationScript();
}

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

    var firstNamePattern = /^^[a-zA-ZÂ‰ˆ≈ƒ÷]+(?:[-\s][a-zA-ZÂ‰ˆ≈ƒ÷]+)?$/;

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

    var lastNamePattern = /^[a-zA-ZÂ‰ˆ≈ƒ÷]+(?:[-\s][a-zA-ZÂ‰ˆ≈ƒ÷]+)?$/;

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

function validatePhoneNumber() {
    var phoneInput = document.getElementById("phonenumber");
    var icon = document.querySelector(".phone-check");

    var phonePattern = /^\d{7,15}$/;

    if (phonePattern.test(phoneInput.value)) {
        icon.classList.remove("fa-times"); 
        icon.classList.add("fa-check");    
    } else {
        icon.classList.remove("fa-check");    
        icon.classList.add("fa-times");       
    }
}

function validationScript() {
    const myInput = document.getElementById("pw");
    const confirm = document.getElementById("confirm-pw");

    const confirmMessage = document.getElementById("confirm-pw-message");

    const letter = document.getElementById("letter");
    const capital = document.getElementById("capital");
    const number = document.getElementById("number");
    const length = document.getElementById("length");
    const compare = document.getElementById("compare");
    const special = document.getElementById("special");

    const numbers = /[0-9]/g;
    const specCharReg = /^(?=.*[!@#$%^&*()_\-+=\[\]{};':"\\|,.<>\/?]).*$/;

    if (myInput != null) {
        myInput.addEventListener("focus", function () {
            message.style.display = "block";
        });

        myInput.addEventListener("blur", function () {
            message.style.display = "none";
        });

        myInput.addEventListener("keyup", function () {

            const lowerCaseLetters = /(?=.*[a-zÂ‰ˆ])/g;

            if (myInput.value.match(lowerCaseLetters)) {
                letter.classList.remove("invalid");
                letter.classList.add("valid");
            } else {
                letter.classList.remove("valid");
                letter.classList.add("invalid");
            }

            if (myInput.value.match(specCharReg)) {
                special.classList.remove("invalid");
                special.classList.add("valid");
            } else {
                special.classList.remove("valid");
                special.classList.add("invalid");
            }

            const upperCaseLetters = /(?=.*[A-Z≈ƒ÷])/g;


            if (myInput.value.match(upperCaseLetters)) {
                capital.classList.remove("invalid");
                capital.classList.add("valid");
            } else {
                capital.classList.remove("valid");
                capital.classList.add("invalid");
            }

            if (myInput.value.match(numbers)) {
                number.classList.remove("invalid");
                number.classList.add("valid");
            } else {
                number.classList.remove("valid");
                number.classList.add("invalid");
            }

            if (myInput.value.length >= 8) {
                length.classList.remove("invalid");
                length.classList.add("valid");
            } else {
                length.classList.remove("valid");
                length.classList.add("invalid");
            }
        })
    }

    if (confirm != null) {
        confirm.addEventListener("focus", function () {
            confirmMessage.style.display = "block";
        });

        confirm.addEventListener("blur", function () {
            confirmMessage.style.display = "none";
        });

        confirm.addEventListener("keyup", function () {
            if (confirm.value.match(myInput.value)) {
                compare.classList.remove("invalid");
                compare.classList.add("valid");
            } else {
                compare.classList.remove("valid");
                compare.classList.add("invalid");
            }
        })
    }
}
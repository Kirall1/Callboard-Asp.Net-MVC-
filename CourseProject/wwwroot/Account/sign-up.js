var phone = null;
var password = null;
var confirmPassword = null;
var login = null;

import { showError, removeError } from "./account.js";


window.onload = function () {
    phone = document.getElementById("phone"); // Получите ссылку на форму
    password = document.getElementById("password"); // Получите ссылку на форму
    login = document.getElementById("name"); // Получите ссылку на форму
    confirmPassword = document.getElementById("confirm_password"); // Получите ссылку на форму

    login.addEventListener("change", function (event) {
        event.preventDefault();
        validateName(login); // Передайте форму в функцию валидации
    });

    password.addEventListener("change", function (event) {
        event.preventDefault();
        validatePassword(password); // Передайте форму в функцию валидации
    });

    phone.addEventListener("change", function (event) {
        event.preventDefault();
        validatePhone(phone); // Передайте форму в функцию валидации
    });

    confirmPassword.addEventListener("change", function (event) {
        event.preventDefault();
        validateConfirmPassword(password, confirmPassword); // Передайте форму в функцию валидации
    });
};


// Валидация номера телефона
function validatePhone(phone) {
    var phoneRegex = /^[0-9]{10,12}$/;

    if (phoneRegex.test(phone.value)) {
        removeError(phone);
    }
    else {
        showError(phone, "Неверный номер телефона");
    }
}

function validateName(name) {
    var nameRegex = /^[a-zA-Z]{2,}$/;

    if (nameRegex.test(name.value)) {
        removeError(name);
    }
    else {
        showError(name, "Недопустимый логин")
    }

}

// Валидация пароля
function validatePassword(password) {


    var passwordRegex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*\W)[a-zA-Z0-9\W]{8,}$/;
    if (passwordRegex.test(password.value)) {
        removeError(password);
    }
    else {
        showError(password, "Недопустимый пароль");
    }
}


// Валидация подтверждения пароля
function validateConfirmPassword(password, confirmPassword) {


    if (password.value === confirmPassword.value) {
        removeError(confirmPassword);
    }
    else {
        showError(confirmPassword, "Пароли не совпадают");
    }
}



var phone = null;
var password = null;
var confirmPassword = null;

import { showError, removeError } from "./account.js";


window.onload = function () {
    phone = document.getElementById("phone"); // Получите ссылку на форму
    password = document.getElementById("password"); // Получите ссылку на форму
    confirmPassword = document.getElementById("confirm_password"); // Получите ссылку на форму

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

// Валидация имени


// Валидация подтверждения пароля
function validateConfirmPassword(password, confirmPassword) {


    if (password.value === confirmPassword.value) {
        removeError(confirmPassword);
    }
    else {
        showError(confirmPassword, "Пароли не совпадают");
    }
}



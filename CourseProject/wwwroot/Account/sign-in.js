var password = null;
var login = null;

import { showError, removeError } from "./account.js";


window.onload = function () {
    password = document.getElementById("password"); // Получите ссылку на форму
    login = document.getElementById("name"); // Получите ссылку на форму

    login.addEventListener("change", function (event) {
        event.preventDefault();
        validateName(login); // Передайте форму в функцию валидации
    });

    password.addEventListener("change", function (event) {
        event.preventDefault();
        validatePassword(password); // Передайте форму в функцию валидации
    });
};


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



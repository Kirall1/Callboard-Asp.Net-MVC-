var login = null;
var password = null;
window.onload = function () {
    login = document.getElementById("name"); // Получите ссылку на форму
    password = document.getElementById("password"); // Получите ссылку на форму
    login.addEventListener("change", function (event) {
        event.preventDefault();
        validateName(login); // Передайте форму в функцию валидации
    });

    password.addEventListener("change", function (event) {
        event.preventDefault();
        validatePassword(password); // Передайте форму в функцию валидации
    });
};


// Валидация имени
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

// Валидация формы


// Функция для отображения ошибки над полем ввода
export function showError(input, message) {
    var error = document.createElement("p");
    error.textContent = message;
    error.style.color = "red";
    input.parentNode.nextElementSibling.innerHTML = '';
    input.parentNode.nextElementSibling.appendChild(error);

    input.style.borderColor = "red";
}

export function removeError(input) {
    input.parentNode.nextElementSibling.textContent = "";
    input.parentNode.nextElementSibling.appendChild(document.createElement("br")); // Добавьте пустой текст для очистки сообщения об ошибке

    input.style.borderColor = "";
}

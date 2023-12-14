var form = null;
window.onload = function () {
    form = document.getElementById("sign_up_form"); // Получите ссылку на форму
    form.addEventListener("submit", function (event) {
        event.preventDefault();
        validateForm(form); // Передайте форму в функцию валидации
    });
};

// Валидация номера телефона
function validatePhone(phone) {
    if (!phone) {
        return false;
    }

    var phoneRegex = /^[0-9]{11}$/;
    return phoneRegex.test(phone);
}

// Валидация имени
function validateName(name) {
    if (!name) {
        return false;
    }

    var nameRegex = /^[a-zA-Zа-яА-Я]{2,}$/;
    return nameRegex.test(name);
}

// Валидация пароля
function validatePassword(password) {
    if (!password) {
        return false;
    }

    var passwordRegex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])[a-zA-Z0-9]{8,}$/;
    return passwordRegex.test(password);
}

// Валидация подтверждения пароля
function validateConfirmPassword(password, confirmPassword) {
    if (password === "" || confirmPassword === "") {
        return false;
    }

    return password === confirmPassword;
}

// Валидация формы
function validateForm(form) {
    var phone = form.phone.value;
    var name = form.name.value;
    var password = form.password.value;
    var confirmPassword = form.confirm_password.value;
    var errorCount = 0;

    if (!validatePhone(phone)) {
        showError(form.phone, "Неверный номер телефона");
        errorCount++;
    }
    else {
        removeError(form.phone)
    }

    if (!validateName(name)) {
        showError(form.name, "Неверное имя");
        errorCount++;
    }
    else {
        removeError(form.name)
    }

    if (!validatePassword(password)) {
        showError(form.password, "Неверный пароль");
        errorCount++;
    }
    else {
        removeError(form.password)
    }

    if (!validateConfirmPassword(password, confirmPassword)) {
        showError(form.confirm_password, "Пароли не совпадают");
        errorCount++;
    }
    else {
        removeError(form.confirm_password)
    }

    if (errorCount > 0) {
        return false;
    }
    return true;
}

// Функция для отображения ошибки над полем ввода
function showError(input, message) {
    var error = document.createElement("p");
    error.textContent = message;
    error.style.color = "red";
    input.parentNode.nextElementSibling.innerHTML = '';
    input.parentNode.nextElementSibling.appendChild(error);

    input.style.borderColor = "red";
}

function removeError(input) {
    input.parentNode.nextElementSibling.textContent = "";
    input.parentNode.nextElementSibling.appendChild(document.createElement("br")); // Добавьте пустой текст для очистки сообщения об ошибке

    input.style.borderColor = "";
}

// Обработчик события submit формы
form.addEventListener("submit", function (event) {
    event.preventDefault();

    if (!validateForm(this)) {
        return;
    }

    // Отправка данных формы на сервер
    // ...
});
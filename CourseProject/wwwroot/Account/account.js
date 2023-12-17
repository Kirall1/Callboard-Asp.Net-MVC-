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

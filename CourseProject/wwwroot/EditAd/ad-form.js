const form = document.querySelector('form');
const photosInput = document.getElementById('photos');
var selectedImagesContainer = document.getElementById('sidebar');
let selectedElement = document.getElementById('1');
selectElement(selectedElement);

// Handle image upload

window.onload = function () {
    selectedImagesContainer = document.getElementById('sidebar');
    for (let i = 0; i < selectedImagesContainer.children.length; i++) {
        selectedImagesContainer.children[i].addEventListener('click', showImage.bind(selectedImagesContainer.children[i]));
    }
}
photosInput.addEventListener('change', () => {
    const selectedFiles = photosInput.files;

    for (const file of selectedFiles) {
        const img = document.createElement('img');
        img.src = URL.createObjectURL(file);
        img.addEventListener('load', () => {
            const imageContainer = document.createElement('div');
            const deleteButton = document.createElement('button');
            imageContainer.classList.add('image-container');
            imageContainer.classList.add('not-highlighted');
            deleteButton.classList.add('delete-button');
            deleteButton.classList.add('btn');
            deleteButton.classList.add('btn-danger');
            deleteButton.addEventListener('click', () => deleteImage(deleteButton));
            deleteButton.innerText = 'Delete';
            imageContainer.addEventListener('click', showImage.bind(imageContainer));
            imageContainer.addEventListener('mouseover', () => highlightContainer(imageContainer));
            imageContainer.addEventListener('mouseout', () => resetContainer(imageContainer));
            imageContainer.appendChild(img);
            imageContainer.appendChild(deleteButton);
            selectedImagesContainer.appendChild(imageContainer);
        });
    }
});


function showImage() {
    var contentContainer = document.getElementById('selectedImageContainer');

    contentContainer.innerHTML = '';

    var selectedImage = document.createElement('img');
    selectedImage.src = this.children[0].src;

    contentContainer.appendChild(selectedImage);

    selectElement(this);
}

function selectElement(element) {
    if (selectedElement) {
        selectedElement.classList.remove('selected');
    }

    selectedElement = element;
    selectedElement.classList.add('selected');
}


function highlightContainer(element) {
    element.classList.remove('not-highlighted');
    element.classList.add('highlighted');
}

function resetContainer(element) {
    element.classList.remove('highlighted');
    element.classList.add('not-highlighted');
}

function removeListener(element) {
    element.parentElement.removeEventListener('click', showImage.bind(element.parentElement));
}

function addListener(element) {
    element.parentElement.addEventListener('click', showImage.bind(element.parentElement));
}

function removeFileFromList(fileList, index) {
    return fileList.split("|").filter((_, i) => i !== index).join("|");
}

// Функция для удаления изображения
function deleteImage(button) {
    const imageContainer = button.parentElement;

    removeFile(imageContainer);

    imageContainer.remove();
    if (selectedImagesContainer.children.length > 0) {
        showImage.call(selectedImagesContainer.children[0]);
    } else {
        var selectedImageContainer = document.getElementById("selectedImageContainer");
        selectedImageContainer.innerHTML = '';
    }
}

// Функция для удаления файла из соответствующего списка (photos или files)
function removeFile(element) {
    const imageSrc = element.children[0].src;

    if (imageSrc.includes("/Photos/")) {
        const photos = document.getElementById("photosOld");
        const index = Array.from(selectedImagesContainer.children).indexOf(element);
        photos.value = removeFileFromList(photos.value, index);
    } else {
        const index = Array.from(selectedImagesContainer.children).indexOf(element);
        photosInput.files = Array.from(photosInput.files).filter((_, i) => i !== index);
    }
}
let selectedElement = document.getElementById('1');
selectElement(selectedElement);

function showImage(imageSrc, element) {
    var contentContainer = document.getElementById('selectedImageContainer');

    contentContainer.innerHTML = '';

    var selectedImage = document.createElement('img');
    selectedImage.src = imageSrc;

    contentContainer.appendChild(selectedImage);

    selectElement(element);
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
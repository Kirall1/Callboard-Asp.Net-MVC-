let selectedElement = null;

function showImage(imageSrc, element) {
    var contentContainer = document.getElementById('selectedImageContainer');

    contentContainer.innerHTML = '';

    var selectedImage = document.createElement('img');
    selectedImage.src = imageSrc;

    contentContainer.appendChild(selectedImage);
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
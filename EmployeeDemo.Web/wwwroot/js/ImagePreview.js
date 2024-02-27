$(document).ready(function () {
    $("#uploadedImage").change(function () {
        const [file] = uploadedImage.files;
        if (file) {
            preview.src = URL.createObjectURL(file);
        }
    })
})
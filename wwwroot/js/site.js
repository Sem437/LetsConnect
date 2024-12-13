// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function show(itemId) {
    var infoDiv = document.getElementById(itemId)

    if (infoDiv.style.display == "none") {
        infoDiv.style.display = "block";
    }
    else {
        infoDiv.style.display = "none";
    }
}
// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function toggleInfo(infoId, iconId) {
    var infoDiv = document.getElementById(infoId);
    var icon = document.getElementById(iconId);

    // Toggle visibility
    if (infoDiv.style.display === "none") {
        infoDiv.style.display = "block";
        // Change the icon to arrow-up-outline
        icon.setAttribute("name", "arrow-up-outline");
    } else {
        infoDiv.style.display = "none";
        // Change the icon back to arrow-down-outline
        icon.setAttribute("name", "arrow-down-outline");
    }
}

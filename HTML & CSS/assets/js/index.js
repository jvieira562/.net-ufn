const openMenuIcon = document.getElementById("openMenu");
const closeMenuIcon = document.getElementById("closeMenu");
const menuBox = document.getElementById("menuMobileBox");

openMenuIcon.addEventListener("click", function() {
    menuBox.classList.add("open");
});

closeMenuIcon.addEventListener("click", function() {
    menuBox.classList.remove("open");
});
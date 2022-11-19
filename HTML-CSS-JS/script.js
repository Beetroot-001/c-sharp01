
function darkMode() {
    var body = document.body;
    var header = document.getElementsByClassName("maintext");
    body.classList.toggle("dark_mode");
    header[0].classList.toggle("dark_mode_header");
    var buttons = document.getElementsByClassName("dark_mode_button");
    var button = buttons[0];
    if(button.textContent.includes("Dark")){
        button.textContent = button.textContent.replace("Dark", "Light");
    }
    else {
        button.textContent = button.textContent.replace("Light", "Dark");
    }
    button.classList.toggle("light_mode_button");
}
function signupToggle() {
    var container = document.querySelector('.container23');
    container.classList.toggle('active');
    var popup = document.querySelector('.signup-form');
    popup.classList.toggle('active');
}
function loginToggle() {
    var container = document.querySelector('.container23');
    container.classList.toggle('active');
    var popup = document.querySelector('.login-form');
    popup.classList.toggle('active');

}
function signinToggle() {
    var popuplogin = document.querySelector('.login-form');
    var popupsignin = document.querySelector('.signup-form');
    popupsignin.classList.toggle('active');
    popuplogin.classList.toggle('active');
}
function registerToggle() {
    var popuplogin = document.querySelector('.login-form');
    var popupsignin = document.querySelector('.signup-form');
    popuplogin.classList.toggle('active');
    popupsignin.classList.toggle('active');
}

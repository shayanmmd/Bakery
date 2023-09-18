document.addEventListener("DOMContentLoaded", function() {
  const form = document.getElementById("loginForm");
  const phoneInput = document.getElementById("phone");
  const usernameInput = document.getElementById("username");
  const submitButton = document.querySelector('input[type="submit"]');

  form.addEventListener("submit", function(event) {
    event.preventDefault();
    form.reportValidity();
  });

  submitButton.addEventListener("click", function() {
    form.reportValidity();
  });

  phoneInput.addEventListener("invalid", function() {
    const errorMessage = document.querySelector('label[for="phone"].error-message');
    errorMessage.innerText = ".شماره موبایل نامعتبر میباشد";
  });

  phoneInput.addEventListener("input", function() {
    const errorMessage = document.querySelector('label[for="phone"].error-message');
    errorMessage.innerText = "";
  });

  usernameInput.addEventListener("invalid", function() {
    const errorMessage = document.querySelector('label[for="username"].error-message');
    errorMessage.innerText = ".لطفاً یک نام کاربری انتخاب کنید";
  });

  usernameInput.addEventListener("input", function() {
    const errorMessage = document.querySelector('label[for="username"].error-message');
    errorMessage.innerText = "";
  });
});
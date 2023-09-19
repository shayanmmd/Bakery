function typeText(element, text, speed) {
    let index = 0;
    const timer = setInterval(() => {
      element.textContent += text.charAt(index);
      index++;
      if (index === text.length) {
        clearInterval(timer);
      }
    }, speed);
  }
  
  const typedTextElement = document.getElementById("typed-text");
  const startButton = document.getElementById("start-button");
  
  const text = "برای اینکه نوبت بگیری روی گزینه 'بزن بریم' کلیک کن";
  typeText(typedTextElement, text, 100); // Adjust the speed by changing the value (in milliseconds)
  
  startButton.addEventListener("click", () => {
    console.log("Button clicked!");
  });
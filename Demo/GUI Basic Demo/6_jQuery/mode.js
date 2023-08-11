//Change Theme | Light to dark | Dark to Light

//Store theme in local storage
//theme.0 = darkMode & theme.1 = lightMode
//By Default theme is dark
if (localStorage.theme == undefined) {
  localStorage.theme = 0;
}

//Select Mode Button
const mode = document.querySelector("#btnMode");
//Select main container
const webpage = document.querySelector(".container");
//Select components for toggle text color
const themeCustomerId = document.querySelector("#themeCustomerId");
const themeTableItemDetails = document.querySelector("#tableItemDetails");
const themeTableTotalAmount = document.querySelector("#tableTotalAmount");

//Set Appereance while loading the page
if (localStorage.theme == 1) {
  //Change Background
  webpage.className = "container bg-light";

  //Remove text-white class from text components
  themeCustomerId.classList.remove("text-white");
  themeTableItemDetails.classList.remove("text-white");
  themeTableTotalAmount.classList.remove("text-white");

  //Change content of Theme Button
  mode.innerHTML = "Dark Mode";
  //Here we are not changing localStorage.theme because it is just for loading, Toggling occurs when user changes the theme by clicking button.
} else {
  webpage.className = "container bg-dark";

  //Add text-white class to text components
  themeCustomerId.classList.add("text-white");
  themeTableItemDetails.classList.add("text-white");
  themeTableTotalAmount.classList.add("text-white");

  //Change content of Theme Button
  mode.innerHTML = "Light Mode";
  //Here we are not changing localStorage.theme because it is just for loading, Toggling occurs when user changes the theme by clicking button.
}

//Toggle Appereance of webpage by clicking button

mode.addEventListener("click", () => {
  if (mode.innerHTML.trim() == "Light Mode") {
    //Change Background
    webpage.className = "container bg-light";

    //Remove text-white class from text components
    themeCustomerId.classList.remove("text-white");
    themeTableItemDetails.classList.remove("text-white");
    themeTableTotalAmount.classList.remove("text-white");

    //Change content of Theme Button
    mode.innerHTML = "Dark Mode";

    //Update theme dark to light
    localStorage.theme = 1;
  } else if (mode.innerHTML.trim() == "Dark Mode") {
    //Change Background
    webpage.className = "container bg-dark";

    //Add text-white class to text components
    themeCustomerId.classList.add("text-white");
    themeTableItemDetails.classList.add("text-white");
    themeTableTotalAmount.classList.add("text-white");

    //Change content of Theme Button
    mode.innerHTML = "Light Mode";

    //Update theme light to dark
    localStorage.theme = 0;
  }
});

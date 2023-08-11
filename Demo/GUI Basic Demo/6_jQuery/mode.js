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

//Change Background | Dark to Light
function setBackgroundLight() {
  webpage.className = "container bg-light";
}

//Change Background | Light to Dark
function setBackgroundDark() {
  webpage.className = "container bg-dark";
}

//Add text-white class to text components
function addWhiteText() {
  themeCustomerId.classList.add("text-white");
  themeTableItemDetails.classList.add("text-white");
  themeTableTotalAmount.classList.add("text-white");
}

//Remove text-white class from text components
function removeWhiteText() {
  themeCustomerId.classList.remove("text-white");
  themeTableItemDetails.classList.remove("text-white");
  themeTableTotalAmount.classList.remove("text-white");
}

//Change content of Theme Button | Light to Dark
function setBtnTextDark() {
  mode.innerHTML = "Dark Mode";
}

//Change content of theme Button | Dark to Light
function setBtnTextLight() {
  mode.innerHTML = "Light Mode";
}

//Update theme dark to light in local storage
function setThemeVariableLight() {
  localStorage.theme = 1;
}

//Update theme light to dark in local storage
function setThemeVariableDark() {
  localStorage.theme = 0;
}

//Callbacks is used for better code visibility

//setDarkTheme will call all 4 functions which are added below :
var setDarkTheme = $.Callbacks();
setDarkTheme.add(setBackgroundLight);
setDarkTheme.add(removeWhiteText);
setDarkTheme.add(setBtnTextDark);
setDarkTheme.add(setThemeVariableLight);

//setLightTheme will call all 4 functions which are added below:
var setLightTheme = $.Callbacks();
setLightTheme.add(setBackgroundDark);
setLightTheme.add(addWhiteText);
setLightTheme.add(setBtnTextLight);
setLightTheme.add(setThemeVariableDark);

//Set Appereance while loading the page
if (localStorage.theme == 1) {
  //Here we are not changing localStorage.theme because it is just for loading, Toggling occurs when user changes the theme by clicking button.
  setDarkTheme.remove(setThemeVariableLight);
  setDarkTheme.fire();
  setDarkTheme.add(setThemeVariableLight);
} else {
  //Here we are not changing localStorage.theme because it is just for loading, Toggling occurs when user changes the theme by clicking button.
  setLightTheme.remove(setThemeVariableDark);
  setLightTheme.fire();
  setLightTheme.add(setThemeVariableDark);
}

//Toggle Appereance of webpage by clicking button

mode.addEventListener("click", () => {
  if (mode.innerHTML.trim() == "Light Mode") {
    setDarkTheme.fire();
  } else if (mode.innerHTML.trim() == "Dark Mode") {
    setLightTheme.fire();
  }
});

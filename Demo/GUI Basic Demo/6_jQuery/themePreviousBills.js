//Change theme on basis of local storage
const backgroundPreviousTheme = document.querySelector(".container");
const textTablePreviousBills = document.querySelector(
  "#themePreviousBillsPage"
);
const themePreviousBillsTable = document.querySelector("#tablePreviousBills");
if (localStorage.theme == "1") {
  backgroundPreviousTheme.classList.remove("bg-dark");
  textTablePreviousBills.classList.remove("text-white");
  themePreviousBillsTable.classList.remove("text-white");
} else {
  backgroundPreviousTheme.classList.add("bg-dark");
  textTablePreviousBills.classList.add("text-white");
  themePreviousBillsTable.classList.add("text-white");
}

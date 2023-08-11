//Change theme on basis of local storage
const backgroundCurrentTheme = document.querySelector(".container");
const themeCurrentBillsPage = document.querySelector("#themeCurrentBillsPage");
const themeConfirmedBillsTable = document.querySelector("#tableConfirmedBills");
if (localStorage.theme == "1") {
  backgroundCurrentTheme.classList.remove("bg-dark");
  themeCurrentBillsPage.classList.remove("text-white");
  themeConfirmedBillsTable.classList.remove("text-white");
} else {
  backgroundCurrentTheme.classList.add("bg-dark");
  themeCurrentBillsPage.classList.add("text-white");
  themeConfirmedBillsTable.classList.add("text-white");
}

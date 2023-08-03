// Check Web Storage is available or not
if (typeof Storage !== "undefined") {
  console.log("You can use Web Storage");
} else {
  console.log("Web Storage is not available");
}

//Local Storage

//store
localStorage.setItem("Position", "Web Developer");
localStorage.setItem("a", "Web b");
localStorage.setItem("c", "Web d");

//retrieve
console.log("Your position is " + localStorage.getItem("Position"));

//remove
localStorage.removeItem("Position");
if (!localStorage.getItem("Position")) {
  //here value in if contion is null..
  console.log("Position does not exist");
}

//clear

// Remove all saved data from sessionStorage
console.log("a : " + localStorage.getItem("a"));
console.log("c : " + localStorage.getItem("c"));

// localStorage.clear();
console.log("a : " + localStorage.getItem("a"));
console.log("c : " + localStorage.getItem("c"));

//Click Counter
const clickCounterBtn = document.querySelector("#clickCounterBtn");
clickCounterBtn.addEventListener("click", () => {
  if (localStorage.clickCount) {
    localStorage.clickCount = Number(localStorage.clickCount) + 1;
  } else {
    localStorage.clickCount = 1;
  }
  document.getElementById(
    "clickCounterAck"
  ).innerHTML = `Click Count : ${localStorage.clickCount}`;
});

//Session Storage

//Click Counter Session Storage
const clickCounterBtnSS = document.querySelector("#clickCounterBtnSS");
clickCounterBtnSS.addEventListener("click", () => {
  if (sessionStorage.clickCount) {
    sessionStorage.clickCount = Number(sessionStorage.clickCount) + 1;
  } else {
    sessionStorage.clickCount = 1;
  }
  document.getElementById(
    "clickCounterAckSS"
  ).innerHTML = `Click Count : ${sessionStorage.clickCount}`;
});

//Cookies

//Create Cookies
document.cookie = "name = yash; SameSite = None; Secure";
document.cookie = "favorite_color = green";

//Show Cookies
const showCookiesBtn = document.querySelector("#showCookiesButton");
showCookiesBtn.addEventListener("click", () => {
  const output = document.getElementById("cookies");
  console.log(document.cookie);
  output.textContent = ">" + document.cookie;
});

//Hide Cookies
const hideCookiesBtn = document.querySelector("#clearOutputCookiesButton");
hideCookiesBtn.addEventListener("click", () => {
  const output = document.getElementById("cookies");
  output.textContent = "";
  console.log("Cookies are unvisible now on webpage");
});

//Show Cookie Value
const findCookieValueBtn = document.querySelector("#findCookieValueButton");
findCookieValueBtn.addEventListener("click", () => {
  const cookieValue = document.cookie
    .split("; ")
    .find((cookieName) => cookieName.startsWith("name="))
    ?.split("=")[1];
  const output = document.getElementById("cookieValue");
  output.textContent = ">" + cookieValue;
});

//reset Cookie Value

//Check a cookie existance
const isCookieBtn = document.querySelector("#isCookieButton");
isCookieBtn.addEventListener("click", () => {
  const inputCookie = document.getElementById("inputCookie");
  if (
    document.cookie
      .split(";")
      .some((item) => item.trim().startsWith(inputCookie.value + "="))
  ) {
    console.log("present");
    const output = document.getElementById("isCookieText");
    output.innerHTML = inputCookie.value + " is present";
  } else {
    console.log("Not present");
    const output = document.getElementById("isCookieText");
    output.textContent = inputCookie.value + " is not present";
  }
});

//Cookie Validation
//Check that cookie has specific value or not
const inputCookieNameBtn = document.querySelector("#inputCookieNameButton");
inputCookieNameBtn.addEventListener("click", () => {
  const inputCookieName = document.getElementById("inputCookieName");
  const inputCookieValue = document.getElementById("inputCookieValue");
  if (
    document.cookie
      .split(";")
      .some(
        (item) => item === inputCookieName.value + "=" + inputCookieValue.value
      )
  ) {
    const output = document.getElementById("cookieValidation");
    output.textContent = "Cookie is valid";
  } else {
    const output = document.getElementById("cookieValidation");
    output.textContent = "Cookie is invalid";
  }
});

//Cache

//is cache support available or not ?
let isCacheSupported = "caches" in window;
if (isCacheSupported) {
  console.log("Cache is supported");
} else {
  console.log("Cache is not supported");
}

//For creating cache
//here myCache is cacheName
caches.open("myCache").then((cache) => {
  console.log("myCache is created");
});

//Adding

//Single item addition in cache
let amazonLogoUrl = //if any link contains AllowAccessOrigin in server side header then it can not be cacahed.
  "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a9/Amazon_logo.svg/2560px-Amazon_logo.svg.png";
caches.open("myCache").then((cache) => {
  cache.add(amazonLogoUrl).then(() => {
    console.log("Amazon Logo is added in cache memory");
  });
});

//Multiple items addition in cache
let flipcartLogoUrl =
  "https://imagedelivery.net/5MYSbk45M80qAwecrlKzdQ/3e7a0718-2f18-4201-845f-68bfb02fa400/public";
let jiomartLogoUrl =
  "https://upload.wikimedia.org/wikipedia/en/5/54/JioMart_logo.svg";
let urlArray = [flipcartLogoUrl, jiomartLogoUrl];
caches.open("myCache").then((cache) => {
  cache.addAll(urlArray).then(() => {
    console.log("Array of url is cached");
  });
});

//Addition using put method in key-value pair
fetch(amazonLogoUrl).then((response) => {
  caches.open("myCache").then((cache) => {
    cache.put(amazonLogoUrl, response);
    console.log("amazonLogoUrl is added by put method");
  });
});

//Retriving from cache
caches.open("myCache").then((cache) => {
  cache.match(amazonLogoUrl).then((response) => {
    console.log(response);
  });
});

//Returns all items from cache
caches.open("myCache").then((cache) => {
  console.log("********" + cache.keys());
});

//Retrieving all items from cache
caches.open("myCache").then((cache) => {
  cache.keys().then((arrayOfRequest) => {
    console.log(arrayOfRequest);
  });
});

//Delete an item from cache
caches.open("myCache").then((cache) => {
  cache.delete(flipcartLogoUrl);
});
caches.open("myCache").then((cache) => {
  cache.match(flipcartLogoUrl).then((response) => {
    console.log(response); //prints undefined because flipcart logo is not in cache
  });
});

//Delete cache completely
// caches.delete("myCache").then((cache) => {
//   console.log("myCache is deleted successfully"); //prints undefined because
// });

//Provide 2 decimal precision to subscription feild
const subscriptionFeeFeild = document.querySelector("#subscriptionFee");
subscriptionFeeFeild.addEventListener("blur", () => {
  subscriptionFeeFeild.value = Number(subscriptionFeeFeild.value).toFixed(2);
});
//When user enters confirm password, Below pressed key will be showed up.
const textBox = document.querySelector("#cnf_pwd");
const output = document.querySelector("#cnf_pwd_output");
textBox.addEventListener("keypress", (event) => {
  console.log(event.key);
  output.textContent = `You pressed "${event.key}".`;
});
//Events on Reset Button
function resetMsgClick() {
  alert("Reset button clicked");
}
function resetMsg() {
  document.getElementById("resetMsg").innerHTML =
    "By clicking this btn, all values of form will be set as default";
}
function clearResetMsg() {
  document.getElementById("resetMsg").innerHTML = "";
}
//change background color while focusing address
function focusEvent() {
  document.getElementById("address").style.backgroundColor = "lightblue";
}
//When user starts filling form , this msg prints
function assuranceMsg() {
  document.getElementById("assuranceMsg").innerHTML =
    "Dont Worry, We'll never share your information with others";
}
//When webpage is fully loaded
function loadingMsg() {
  alert("Click OK to redirect website");
}
//Form Validation
function validation() {
  //First name and last name can not be empty
  var f_name = document.getElementById("f_name").value;
  if (f_name.length == 0 || f_name == null) {
    alert("First Name is empty");
    return false;
  }
  var l_name = document.getElementById("l_name").value;
  if (l_name.length == 0 || l_name == null) {
    alert("Last Name is empty");
    return false;
  }
  //Email validation by position of . and @
  var email = document.getElementById("email").value;
  var atPosition = email.indexOf("@");
  var dotPosition = email.lastIndexOf(".");
  if (dotPosition < atPosition) {
    alert("Please enter valid email address");
    return false;
  }
  //Contact number must be number
  var number = document.getElementById("number").value;
  if (isNaN(number)) {
    alert("Please enter valid contact number..");
    return false;
  }
  //Password and confirm password must be same.
  var pwd = document.getElementById("password").value;
  var cnf_pwd = document.getElementById("cnf_pwd").value;
  if (
    pwd != cnf_pwd ||
    pwd.length == 0 ||
    pwd == null ||
    cnf_pwd.length == 0 ||
    cnf_pwd == null
  ) {
    alert("Password & Confirm Password are not same..");
    return false;
  }
}

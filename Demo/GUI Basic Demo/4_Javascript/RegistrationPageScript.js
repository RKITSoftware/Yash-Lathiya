const subscriptionFeeFeild = document.querySelector("#subscriptionFee");
subscriptionFeeFeild.addEventListener("blur", () => {
  subscriptionFeeFeild.value = parseFloat(subscriptionFeeFeild.value).toFixed(
    2
  );
});
const textBox = document.querySelector("#cnf_pwd");
const output = document.querySelector("#cnf_pwd_output");
textBox.addEventListener("keypress", (event) => {
  console.log(event.key);
  output.textContent = `You pressed "${event.key}".`;
});
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
function focusEvent() {
  document.getElementById("address").style.backgroundColor = "lightblue";
}
function assuranceMsg() {
  document.getElementById("assuranceMsg").innerHTML =
    "Dont Worry, We'll never share your information with others";
}
// function loadingMsg() {
//   alert("Click OK to redirect website");
// }
function validation() {
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
  var email = document.getElementById("email").value;
  var atPosition = email.indexOf("@");
  var dotPosition = email.lastIndexOf(".");
  if (dotPosition < atPosition) {
    alert("Please enter valid email address");
    return false;
  }
  var number = document.getElementById("number").value;
  if (isNaN(number)) {
    alert("Please enter valid contact number..");
    return false;
  }
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

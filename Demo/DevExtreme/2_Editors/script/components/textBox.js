export default function showTextBox() {
  $("#content").remove();
  $(".container").append("<div id='content'></div>");

  $("#content").append(
    `<div class='left-right '>
      <div class='left'>Username</div>
      <div class='right' id='username'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right '>
      <div class='left'>Email Id</div>
      <div class='right' id='emailId'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right '>
      <div class='left'>Password</div>
      <div class='right' id='password'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right '>
      <div class='left'>Mobile Number</div>
      <div class='right' id='mobileNumber'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right wMax'>
      <div class='left'><div id= 'chkBox''></div></div>
      <div class='right' id='privacyPolicy'></div>
    </div>`
  );

  const username = $("#username")
    .dxTextBox({
      placeholder: "Enter your username",
      showClearButton: true,
      onValueChanged() {
        emailId.option("value", username.option("value") + "@rkitsoftware.com");
      },
    })
    .dxTextBox("instance");

  const emailId = $("#emailId")
    .dxTextBox({
      disabled: true,
      value: "@rkitsoftware.com",
    })
    .dxTextBox("instance");

  const password = $("#password")
    .dxTextBox({
      showClearButton: true,
      mode: "password", // accepts email, password, search, tel, text & url
      placeholder: "Enter your password",
    })
    .dxTextBox("instance");

  const mobileNumber = $("#mobileNumber")
    .dxTextBox({
      showClearButton: true,
      mask: "(+\\91) X0000 00000",
      maskRules: { X: /[2-9]/ },
    })
    .dxTextBox("instance");

  const chkBox = $("#chkBox")
    .dxCheckBox({
      onValueChanged(e) {
        if (e.value) {
          username.option("disabled", true);
          password.option("disabled", true);
          mobileNumber.option("disabled", true);
        } else {
          username.option("disabled", false);
          password.option("disabled", false);
          mobileNumber.option("disabled", false);
        }
      },
    })
    .dxCheckBox("instance");

  const privacyPolicy = $("#privacyPolicy")
    .dxTextBox({
      value: "I accept privacy policy with my concent",
      width: 400,
      readOnly: true,
    })
    .dxTextBox("instance");
}

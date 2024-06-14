export default function showValidation() {
  $("#content").remove();
  $(".container").append("<div id='content'></div>");

  $("#content").append(
    `<div class='left-right wMax'>
      <div class='left'>Username</div>
      <div class='right' id='username'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right wMax'>
      <div class='left'>Email</div>
      <div class='right' id='email'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right wMax'>
      <div class='left'>Password</div>
      <div class='right' id='password'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right wMax'>
      <div class='left'>Confirm Password</div>
      <div class='right' id='confirm'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right wMax'>
      <div class='left'>Date of Birth</div>
      <div class='right' id='dob'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right wMax'>
      <div class='left'>Gender</div>
      <div class='right' id='gender'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right wMax'>
      <div class='left'>Qualification</div>
      <div class='right' id='qualification'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right wMax'>
      <div class='right' id='check'></div>
    </div>`
  );

  $("#content").append(`<div id='registrationBtn'></div>`);

  const sendRequest = function (value) {
    const invalidEmail = "test";
    const d = $.Deferred();
    setTimeout(() => {
      d.resolve(value !== invalidEmail);
    }, 1000);
    return d.promise();
  };

  const username = $("#username")
    .dxTextBox({
      placeholder: "Sachin Tendulkar",
      value: "",
    })
    .dxValidator({
      validationGroup: "registrationGroup",
      validationRules: [
        {
          type: "required",
          message: "Username is required.",
        },
        {
          type: "pattern",
          pattern: "^[a-zA-Z]+$",
          message: "Do not use digits or spaces.",
        },
        {
          type: "async",
          message: "Username is already registered",
          validationCallback(params) {
            return sendRequest(params.value);
          },
        },
      ],
    })
    .dxTextBox("instance");

  const email = $("#email")
    .dxTextBox({
      placeholder: "example@example.com",
      // onKeyDown() {
      //   email.option("validationStatus", "pending");
      // },
    })
    .dxValidator({
      validationGroup: "registrationGroup",
      validationRules: [
        {
          type: "required",
          message: "Email is required.",
        },
        {
          type: "email",
          message: "Email is invalid.",
        },
      ],
    })
    .dxTextBox("instance");

  const password = $("#password")
    .dxTextBox({
      mode: "password",
      placeholder: "Password@123",
      // onKeyDown() {
      //   password.option("validationStatus", "pending");
      // },
    })
    .dxValidator({
      validationGroup: "registrationGroup",
      validationRules: [
        {
          type: "required",
          message: "Password is required.",
        },
        {
          type: "pattern",
          pattern:
            "^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*])(?=.{8,})",
          message:
            "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one number and one special character.",
        },
      ],
    })
    .dxTextBox("instance");

  const confirm = $("#confirm")
    .dxTextBox({
      mode: "password",
      placeholder: "Password@123",
      // onKeyDown() {
      //   confirm.option("validationStatus", "pending");
      // },
    })
    .dxValidator({
      validationGroup: "registrationGroup",
      validationRules: [
        {
          type: "required",
          message: "Confirm Password is required.",
        },
        {
          type: "compare",
          comparisonTarget: () => {
            return password.option("value");
          },
          message: "Passwords do not match.",
        },
      ],
    })
    .dxTextBox("instance");

  const dob = $("#dob")
    .dxDateBox({})
    .dxValidator({
      validationGroup: "registrationGroup",
      validationRules: [
        {
          type: "required",
          message: "Date of Birth is required.",
        },
        {
          type: "range",
          max: new Date(),
          message: "Date of Birth is invalid.",
        },
      ],
    })
    .dxDateBox("instance");

  const gender = $("#gender")
    .dxRadioGroup({
      items: ["Male", "Female", "Non-Binary", "Prefer not to say"],
      value: "Male",
    })
    .dxValidator({
      validationGroup: "registrationGroup",
      validationRules: [
        {
          type: "required",
          message: "Gender is required.",
        },
      ],
    })
    .dxRadioGroup("instance");

  let qualifications = [
    "SSC",
    "HSC",
    "Diploma",
    "B.E. / B.Tech",
    "M.E. / M.Tech",
  ];

  const qualification = $("#qualification")
    .dxDropDownBox({
      placeholder: "Select Qualifications",
      value: [],
      dataSource: qualifications,
      isValid: false,
      placeholder: "Select your qualifications..",
      contentTemplate: (e) => {
        // console.log(e);
        const $tagBox = $("<div>").dxTagBox({
          dataSource: e.component.option("dataSource"),
          value: e.component.option("value"),
          showSelectionControls: true,
          maxDisplayedTags: 5,
          onValueChanged: (args) => {
            // console.log("e", e);
            // console.log("args", args);
            e.component.option("value", args.value);
          },
        });
        return $tagBox;
      },
    })
    .dxValidator({
      validationGroup: "registrationGroup",
      validationRules: [
        {
          type: "custom",
          validationCallback: (e) => {
            if (
              (e.value.includes("SSC") &&
                e.value.includes("HSC") &&
                e.value.includes("B.E. / B.Tech")) ||
              (e.value.includes("SSC") &&
                e.value.includes("Diploma") &&
                e.value.includes("B.E. / B.Tech"))
            ) {
              return true;
            }
          },
          message:
            "Please enter valid qualification flow...Minimum qualification is B.E. / B.Tech",
        },
      ],
    })
    .dxDropDownBox("instance");

  const check = $("#check")
    .dxCheckBox({
      value: false,
      text: "I agree to the Terms and Conditions",
      validationMessagePosition: "right",
    })
    .dxValidator({
      validationGroup: "registrationGroup",
      validationRules: [
        {
          type: "compare",
          comparisonTarget() {
            return true;
          },
          message: "You must agree to the Terms and Conditions",
        },
      ],
    })
    .dxCheckBox("instance");

  $("#registrationBtn").dxButton({
    text: "Register",
    stylingMode: "contained",
    type: "success",
    onClick: () => {
      const result =
        DevExpress.validationEngine.validateGroup("registrationGroup");

      console.log(result);

      let brokenRules = "";
      result.brokenRules.map((rule) => {
        brokenRules += `<p class = 'danger'>${rule.message}</p>`;
      });

      if (result.isValid) {
        DevExpress.ui.dialog.alert({
          messageHtml: "Registration Suceessful !",
        });
      } else {
        DevExpress.ui.dialog.alert({
          title: "Data is invalid !!",
          messageHtml: brokenRules,
        });
      }
    },
  });
}

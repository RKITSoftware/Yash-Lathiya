$(() => {
  $("#accType").append(
    `<div class='left-right '>
        <div class='left'>Account Type</div>
        <div class='right' id='accTypeId'></div>
    </div>`
  );

  $("#firstName").append(
    `<div class='left-right '>
        <div class='left'>First Name</div>
        <div class='right' id='firstNameId'></div>
    </div>`
  );

  $("#lastName").append(
    `<div class='left-right '>
        <div class='left'>Last Name</div>
        <div class='right' id='lastNameId'></div>
    </div>`
  );

  $("#email").append(
    `<div class='left-right '>
        <div class='left'>Email</div>
        <div class='right' id='emailId'></div>
    </div>`
  );

  $("#password").append(
    `<div class='left-right '>
        <div class='left'>Password</div>
        <div class='right' id='passwordId'></div>
    </div>`
  );

  $("#confirmPassword").append(
    `<div class='left-right '>
        <div class='left'>Confirm Password</div>
        <div class='right' id='confirmPasswordId'></div>
    </div>`
  );

  $("#mobileNumber").append(
    `<div class='left-right '>
        <div class='left'>Mobile Number</div>
        <div class='right' id='mobileNumberId'></div>
    </div>`
  );

  $("#dob").append(
    `<div class='left-right '>
        <div class='left'>Date of Birth</div>
        <div class='right' id='dobId'></div>
    </div>`
  );

  $("#gender").append(
    `<div class='left-right '>
        <div class='left'>Gender</div>
        <div class='right' id='genderId'></div>
    </div>`
  );

  $("#currentAddress").append(
    `<div class='left-right '>
        <div class='left'>Current Address</div>
        <div class='right' id='currentAddressId'></div>
    </div>`
  );

  $("#isAddressSame").append(
    `<div class='left-right '>
        <div class='right' id='isAddressSameId'></div>
    </div>`
  );

  $("#permanentAddress").append(
    `<div class='left-right '>
        <div class='left'>Permanent Address</div>
        <div class='right' id='permanentAddressId'></div>
    </div>`
  );

  $("#proofOfResidence").append(
    `<div class='left-right '>
        <div class='left'>Proof of Residence</div>
        <div class='right' id='residenceId'></div>
    </div>`
  );

  $("#proofOfIdentification").append(
    `<div class='left-right '>
        <div class='left'>Proof of Identification</div>
        <div class='right' id='identificationId'></div>
    </div>`
  );

  $("#photo").append(
    `<div class='left-right '>
        <div class='left'>Documents selected above<span> (.pdf)</span></div>
        <div class='right' id='documentId'></div>
    </div>`
  );

  $("#photo").append(
    `<div class='left-right '>
        <div class='left'>Photo<span> (.jpeg)</span></div>
        <div class='right' id='photoId'></div>
    </div>`
  );

  $("#signature").append(
    `<div class='left-right '>
        <div class='left'>Signature<span> (.jpeg, .pdf)</span></div>
        <div class='right' id='signatureId'></div>
    </div>`
  );

  $("#openingBalance").append(
    `<div class='left-right '>
        <div class='left'>Amount to credit for opening</div>
        <div class='right' id='amountId'></div>
    </div>`
  );

  $("#requirements").append(
    `<div class='left-right '>
        <div class='left'>Select your requirements</div>
        <div class='right' id='requirementId'></div>
    </div>`
  );

  $("#submitBtn").append(
    `<div class='left-right '>
        <div class='left' id='submitBtnId'></div>
        <div class='right' id='resetBtnId'></div>
    </div>`
  );

  
  const accType = $("#accTypeId")
    .dxSelectBox({
      width: 300,
      placeholder: "Choose Account Type",
      items: [
      {
          S10101: 1,
          S10102: "ABC"
      },
      {
        S10101: 2,
        S10102: "DEF"
      },
      {
        S10101: 3,
        S10102: "GHE"
      },
    ],    //["Savings Account", "Current Account", "Salaried Account"],
      acceptCustomValue: false,
      displayExpr: "S10102",
      valueExpr : "S10101",
      value : 2,
      validationMessageMode : "always",
    })
    .dxValidator({
      validationGroup: "AccOpeningGroup",
      validationRules: [
        {
          type: "required",
          message: "Account type is required.",
        },
      ],
    })
    .dxSelectBox("instance");

  console.log(accType.option("displayValue")) //// RP : displayValue returns selected value of select box

  const firstName = $("#firstNameId")
    .dxTextBox({
      width: 300,
      placeholder: "Sachin",
    })
    .dxValidator({
      validationGroup: "AccOpeningGroup",
      validationRules: [
        {
          type: "required",
          message: "First Name is required.",
        },
        {
          type: "pattern",
          pattern: "^[a-zA-Z]+$",
          message: "Enter valid first name",
        },
      ],
    })
    .dxTextBox("instance");

  const lastName = $("#lastNameId")
    .dxTextBox({
      width: 300,
      placeholder: "Tendulkar",
    })
    .dxValidator({
      validationGroup: "AccOpeningGroup",
      validationRules: [
        {
          type: "required",
          message: "Last Name is required.",
        },
        {
          type: "pattern",
          pattern: "^[a-zA-Z]+$",
          message: "Enter valid first name",
        },
      ],
    })
    .dxTextBox("instance");

  const isEmailExists = function (value) {
    const invalidEmail = "sachin@gmail.com";
    const d = $.Deferred();
    setTimeout(() => {
      d.resolve(value != invalidEmail);
    }, 1000);
    return d.promise();
  };

  const email = $("#emailId")
    .dxTextBox({
      width: 300,
      placeholder: "sachin@gmail.com",
      value: "",
    })
    .dxValidator({
      validationGroup: "AccOpeningGroup",
      validationRules: [
        {
          type: "required",
          message: "Email is required.",
        },
        {
          type: "email",
          message: "Email is invalid.",
        },
        {
          type: "async",
          message: "Email is already registered",
          validationCallback(params) {
            // console.log("validation callback");
            return isEmailExists(params.value);
          },
        },
      ],
    })
    .dxTextBox("instance");

  const password = $("#passwordId")
    .dxTextBox({
      width: 300,
      mode: "password",
      placeholder: "Password@123",
    })
    .dxValidator({
      validationGroup: "AccOpeningGroup",
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

  const confirm = $("#confirmPasswordId")
    .dxTextBox({
      mode: "password",
      placeholder: "Password@123",
      width: 300,
    })
    .dxValidator({
      validationGroup: "AccOpeningGroup",
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

  const mobile = $("#mobileNumberId")
    .dxTextBox({
      width: 300,
      showClearButton: true,
      mask: "(+\\91) X0000 00000",
      maskRules: { X: /[2-9]/ },
    })
    .dxValidator({
      validationGroup: "AccOpeningGroup",
      validationRules: [
        {
          type: "required",
          message: "Confirm Password is required.",
        },
      ],
    })
    .dxTextBox("instance");

  const dob = $("#dobId")
    .dxDateBox({
      width: 300,
    })
    .dxValidator({
      validationGroup: "AccOpeningGroup",
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

  const gender = $("#genderId")
    .dxRadioGroup({
      items: ["Male", "Female"],
      value: "Male",
    })
    .dxValidator({
      validationGroup: "AccOpeningGroup",
      validationRules: [
        {
          type: "required",
          message: "Gender is required.",
        },
      ],
    })
    .dxRadioGroup("instance");

  const currentAddress = $("#currentAddressId")
    .dxTextArea({
      width: 300,
      height: 70,
      autoResizeEnabled: true,
    })
    .dxValidator({
      validationGroup: "AccOpeningGroup",
      validationRules: [
        {
          type: "required",
          message: "Current address is required.",
        },
      ],
    })
    .dxTextArea("instance");

  const isAddressSame = $("#isAddressSameId")
    .dxCheckBox({
      text: "Permanent address is same as current address",
      value: false,
      onValueChanged: (data) => {
        if (data.value) {
          permanentAddress.option("value", currentAddress.option("text"));
          permanentAddress.option("disabled", true);
        } else {
          permanentAddress.option("disabled", false);
        }
      },
    })
    .dxCheckBox("instance");

  isAddressSame.registerKeyHandler("enter", function () {
    const val = isAddressSame.option("value");
    isAddressSame.option("value", !val);
  });

  const permanentAddress = $("#permanentAddressId")
    .dxTextArea({
      width: 300,
      height: 70,
      autoResizeEnabled: true,
    })
    .dxValidator({
      validationGroup: "AccOpeningGroup",
      validationRules: [
        {
          type: "required",
          message: "Permanent address is required.",
        },
      ],
    })
    .dxTextArea("instance");

  const proofsOfResidence = [
    {
      key: "Issued by central authority",
      items: [
        {
          id: 1,
          proofName: "Aadhar Card",
          imgLink : "../assets/images/aadhar.png"
        },
        {
          id: 2,
          proofName: "Election Card",
          imgLink:
            "../assets/images/election.png"
        },
      ],
    },
    {
      key: "Issued by state authority",
      items: [
        {
          id: 4,
          proofName: "MAA Amrutam Card",
          imgLink:
            "../assets/images/maa.jpg",
        },
        {
          id: 5,
          proofName: "Certificate issued by DDO",
          imgLink:
            "../assets/images/images.jpg"
        },
      ],
    },
  ];

  const proofOfResidence = $("#residenceId")
    .dxSelectBox({
      dataSource: proofsOfResidence,
      displayExpr: "proofName",
      valueExpr: "id",
      value: proofsOfResidence[0].items[0].id,
      acceptCustomValue: false,
      grouped: true, // data source is grouped
      searchEnabled: true, // enabling
      fieldTemplate(data, container) {
        const result = $(`<div class='proof'>
                            <img src='${data.imgLink}' />
                            <div class='proof-name'></div>
                          </div>`);
        result.find(".proof-name").dxTextBox({
          value: data && data.proofName,
          // readOnly: true,
        });
        container.append(result);
      },
      itemTemplate(data) {
        return `<div class='proof'>
                  <img src='${data.imgLink}' />
                  <div class='proof-name'>${data.proofName}</div>
                </div>`;
      },
    })
    .dxValidator({
      validationGroup: "AccOpeningGroup",
      validationRules: [
        {
          type: "required",
          message: "Proof of recidence is required.",
        },
      ],
    })
    .dxSelectBox("instance");

  const proofsOfIdentification = [
    {
      key: "Issued by central authority",
      items: [
        {
          id: 1,
          proofName: "Aadhar Card",
          imgLink:
            "../assets/images/aadhar.png",
        },
        {
          id: 2,
          proofName: "Election Card",
          imgLink:
            "../assets/images/election.png",
        },
        {
          id: 3,
          proofName: "PAN Card",
          imgLink:
            "../assets/images/pan.jpg"
        },
        {
          id: 6,
          proofName: "Driving Licence",
          imgLink:
            "../assets/images/driving.svg"
        },
      ],
    },
    {
      key: "Issued by state authority",
      items: [
        {
          id: 4,
          proofName: "MAA Amrutam Card",
          imgLink:
            "../assets/images/maa.jpg",
        },
        {
          id: 5,
          proofName: "Certificate issued by DDO",
          imgLink:
            "../assets/images/images.jpg",
        },
      ],
    },
  ];

  const proofOfIdentification = $("#identificationId")
    .dxSelectBox({
      dataSource: proofsOfIdentification,
      displayExpr: "proofName",
      valueExpr: "id",
      value: proofsOfResidence[0].items[0].id,
      acceptCustomValue: false,
      grouped: true, // data source is grouped
      searchEnabled: true, // enabling
      fieldTemplate(data, container) {
        const result = $(`<div class='proof'>
                          <img src='${data.imgLink}' />
                          <div class='proof-name'></div>
                        </div>`);
        result.find(".proof-name").dxTextBox({
          value: data && data.proofName,
          // readOnly: true,
        });
        container.append(result);
      },
      itemTemplate(data) {
        return `<div class='proof'>
                <img src='${data.imgLink}' />
                <div class='proof-name'>${data.proofName}</div>
              </div>`;
      },
    })
    .dxValidator({
      validationGroup: "AccOpeningGroup",
      validationRules: [
        {
          type: "required",
          message: "Identification proof is required.",
        },
      ],
    })
    .dxSelectBox("instance");

  const documents = $("#documentId")
    .dxFileUploader({
      selectButtonText: "Select Documents",
      allowedFileExtensions: [".pdf"],
      multiple: true,
    })
    .dxValidator({
      validationGroup: "AccOpeningGroup",
      validationRules: [
        {
          type: "required",
          message: "Photo required.",
        },
      ],
    })
    .dxFileUploader("instance");

  const photo = $("#photoId")
    .dxFileUploader({
      selectButtonText: "Select Photo",
      allowedFileExtensions: [".jpeg"],
    })
    .dxValidator({
      validationGroup: "AccOpeningGroup",
      validationRules: [
        {
          type: "required",
          message: "Photo required.",
        },
      ],
    })
    .dxFileUploader("instance");

  const signature = $("#signatureId")
    .dxFileUploader({
      selectButtonText: "Select Signature",
      allowedFileExtensions: [".jpeg", ".pdf"],
    })
    .dxValidator({
      validationGroup: "AccOpeningGroup",
      validationRules: [
        {
          type: "required",
          message: "Signature required.",
        },
      ],
    })
    .dxFileUploader("instance");

  const amount = $("#amountId")
    .dxNumberBox({
      format: "₹ #,###.##",
      stylingMode: "underlined",
      hint: "Total amount consists priciple amount + your profit",
    })
    .dxValidator({
      validationGroup: "AccOpeningGroup",
      validationRules: [
        {
          type: "required",
          message: "Signature required.",
        },
      ],
    })
    .dxNumberBox("instance");

  const requirementList = [
    "Passbook",
    "Checkbook (15 pages)",
    "Checkbook (50 pages)",
    "Debit Card",
    "Credit Card",
    "Net Banking",
  ];

  $("#requirementId").dxDropDownBox({
    value: [],
    dataSource: requirementList,
    width: 400,
    placeholder: "choose requirements",
    contentTemplate: (e) => {
      // console.log(e);
      const $tagBox = $("<div>").dxTagBox({
        dataSource: e.component.option("dataSource"),
        value: e.component.option("value"),
        showSelectionControls: true,
        maxDisplayedTags: 6,
        width: 220,
        onValueChanged: (args) => {
          // console.log("e", e);
          // console.log("args", args);
          e.component.option("value", args.value);
        },
      });
      return $tagBox;
    },
  });

  const submit = $("#submitBtnId")
    .dxButton({
      text: "Submit",
      stylingMode: "contained",
      type: "success",
      width: 100,
      onClick: () => {
        const result =
          DevExpress.validationEngine.validateGroup("AccOpeningGroup");

        console.log(result);

        let brokenRules = "";
        result.brokenRules.map((rule) => {
          brokenRules += `<p class = 'danger'>${rule.message}</p>`;
        });

        if (result.isValid) {
          storeFormValues();
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
    })
    .dxButton("instance");

  const storeFormValues = () => {
    const formData = {
      accType: accType.option("value"),
      firstName: firstName.option("value"),
      lastName: lastName.option("value"),
      email: email.option("value"),
      password: password.option("value"),
      confirmPassword: confirm.option("value"),
      mobile: mobile.option("value"),
      dob: dob.option("value"),
      gender: gender.option("value"),
      currentAddress: currentAddress.option("value"),
      isAddressSame: isAddressSame.option("value"),
      permanentAddress: permanentAddress.option("value"),
      proofOfResidence: proofOfResidence.option("value"),
      proofOfIdentification: proofOfIdentification.option("value"),
      documents: documents.option("value"),
      photo: photo.option("value"),
      signature: signature.option("value"),
      amount: amount.option("value"),
      requirements: $("#requirementId")
        .dxDropDownBox("instance")
        .option("value"),
    };
    sessionStorage.setItem("formData", JSON.stringify(formData));
  };

  const reset = $("#resetBtnId")
    .dxButton({
      text: "Reset",
      stylingMode: "contained",
      type: "danger",
      onClick: () => {
        resetFormValues();
      },
    })
    .dxButton("instance");

  const resetFormValues = () => {
    location.reload();
  };
});

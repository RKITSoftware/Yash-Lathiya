export default function showTextArea() {
  $("#content").remove();
  $(".container").append("<div id='content'></div>");

  $("#content").append(
    `<div class='left-right wMax'>
      <div class='left'>First Name</div>
      <div class='right' id='firstName'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right wMax'>
      <div class='right' id='isBothAddressSame'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right wMax'>
      <div class='left'>Current Address</div>
      <div class='right' id='currentAddress'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right wMax'>
      <div class='left'>Permanent Address</div>
      <div class='right' id='permanentAddress'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right wMax'>
      <div class='left'>Describe your self <span>(500 chars)</span> </div>
      <div class='right' id='describeYourSelf'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right wMax'>
      <div class='right' id='autoSizeEnabled'></div>
    </div>`
  );

  const firstName = $("#firstName").dxTextArea({}).dxTextArea("instance");

  const isBothAddressSame = $("#isBothAddressSame")
    .dxCheckBox({
      text: "Is current address & permanent address same ?",
      value: false,
      onValueChanged(data) {
        if (data.value) {
          // console.log(permanentAddress);
          console.log(currentAddress.option("text"));
          permanentAddress.option("value", currentAddress.option("text"));
          permanentAddress.option("disabled", true);
        } else {
          permanentAddress.option("disabled", false);
        }
      },
    })
    .dxCheckBox("instance");

  isBothAddressSame.registerKeyHandler("enter", function () {
    const val = isBothAddressSame.option("value");
    isBothAddressSame.option("value", !val);
  });

  const currentAddress = $("#currentAddress")
    .dxTextArea({
      // height: 90,
      width: 330,
      onKeyUp: () => {
        if (isBothAddressSame.option("value")) {
          permanentAddress.option("value", currentAddress.option("text"));
        }
      },
    })
    .dxTextArea("instance");

  const permanentAddress = $("#permanentAddress")
    .dxTextArea({
      // height: 90,
      width: 330,
    })
    .dxTextArea("instance");

  const describeYourSelf = $("#describeYourSelf")
    .dxTextArea({
      // height: 100,
      width: 330,
      maxLength: 500,
      spellCheck: true,
    })
    .dxTextArea("instance");

  const autoSizeEnabled = $("#autoSizeEnabled")
    .dxCheckBox({
      text: "Enable Auto Sizing in Text Area",
      onValueChanged(e) {
        if (e.value) {
          firstName.option("autoResizeEnabled", true);
          currentAddress.option("autoResizeEnabled", true);
          permanentAddress.option("autoResizeEnabled", true);
          describeYourSelf.option("autoResizeEnabled", true);
        } else {
          currentAddress.option("autoResizeEnabled", false);
          permanentAddress.option("autoResizeEnabled", false);
          describeYourSelf.option("autoResizeEnabled", false);
        }
      },
    })
    .dxCheckBox("instance");

  autoSizeEnabled.registerKeyHandler("enter", function () {
    const val = autoSizeEnabled.option("value");
    autoSizeEnabled.option("value", !val);
  });
}

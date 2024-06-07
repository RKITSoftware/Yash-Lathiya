export default function showCheckBox() {
  $("#content").remove();
  $(".container").append("<div id='content'></div>");

  $("#content").append(
    `<div class='left-right'>
      <div class='left'>Checked</div>
      <div class='right' id='checked'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right'>
      <div class='left'>Unhecked</div>
      <div class='right' id='unchecked'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right'>
      <div class='left'>Undefined</div>
      <div class='right' id='undefined'></div>
    </div>`
  );

  // $("#content").append(
  //   `<div class='left-right'>
  //     <div class='left'>Three State</div>
  //     <div class='right' id='threeState'></div>
  //   </div>`
  // );

  $("#content").append(
    `<div class='left-right'>
      <div class='left'>Handle Value Change : IsLocationIndia</div>
      <div class='right' id='isLocationIndia'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right'>
      <div class='left'>Handle Value Change : IsLocationUSA</div>
      <div class='right' id='isLocationUSA'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right'>
      <div class='left'>INR</div>
      <div class='right' id='inr'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right'>
      <div class='left'>USD</div>
      <div class='right' id='usd'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right'>
      <div class='left'>Validation</div>
      <div class='right' id='validation'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right'>
      <div class='left'>withLabel</div>
      <div class='right' id='withLabel1'></div>
      <div class='right' id='withLabel2'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right'>
      <div class='left'>On Off Events</div>
      <div class='right' id='switch'></div>
    </div>`
  );

  // default options for all checkboxes
  DevExpress.ui.dxCheckBox.defaultOptions({
    options: {
      // Here go the CheckBox properties
      hint: "hint is set from default options",
    },
  });

  $("#checked").dxCheckBox({
    value: true,
  });

  $("#unchecked").dxCheckBox({
    value: false,
  });

  $("#undefined").dxCheckBox({
    value: undefined,
  });

  // three state is only applicable in higher versions of dx
  // $("#threeState").dxCheckBox({
  //   threeState: true,
  // });

  const locationIndiaChkBox = $("#isLocationIndia")
    .dxCheckBox({
      value: false,
      onValueChanged: function (e) {
        console.log("is location India : ", e.value);
        rupeeChkBox.option("value", e.value);
        locationUsaChkBox.option("value", !e.value);
      },
    })
    .dxCheckBox("instance");

  // set focus on the element
  locationIndiaChkBox.focus();

  const locationUsaChkBox = $("#isLocationUSA")
    .dxCheckBox({
      value: false,
      onValueChanged: function (e) {
        console.log("is loacation USA : ", e.value);
        usdChkBox.option("value", e.value);
        locationIndiaChkBox.option("value", !e.value);
      },
    })
    .dxCheckBox("instance");

  const rupeeChkBox = $("#inr")
    .dxCheckBox({
      value: false,
      disabled: true,
      onContentReady: () => {
        console.log("rupee check box is ready");
      },
      onDispoaing: () => {
        console.log("rupee check box is dispoaing");
      },
    })
    .dxCheckBox("instance");

  const usdChkBox = $("#usd")
    .dxCheckBox({
      value: false,
      disabled: true,
      onContentReady: () => {
        console.log("usd check box is ready");
      },
      onDispoaing: () => {
        console.log("usd check box is dispoaing");
      },
    })
    .dxCheckBox("instance");

  const techChkBox = $("#withLabel1")
    .dxCheckBox({
      text: "Technical",
    })
    .dxCheckBox("instance");

  // batch changes proceessing
  techChkBox.beginUpdate();

  locationIndiaChkBox.option("value", true);
  locationUsaChkBox.option("value", true);

  techChkBox.endUpdate();
  // all changes will be modified after endUpdate() call

  techChkBox.registerKeyHandler("enter", function () {
    const val = techChkBox.option("value");
    techChkBox.option("value", !val);
  });

  const nonTechChkBox = $("#withLabel2")
    .dxCheckBox({
      text: "Non-Technical",
    })
    .dxCheckBox("instance");

  nonTechChkBox.registerKeyHandler("enter", function () {
    const val = nonTechChkBox.option("value");
    nonTechChkBox.option("value", !val);
  });

  $("#validation").dxCheckBox({
    // isValid: false,
    // accepts json or array of json
    validationErrors: [
      { message: "validation msg" },
      { message: "validation msg" },
    ],
    validationMessageMode: "auto", // accepts auto and always
    validationStatus: "invalid", // accepts valid, invalid & pending validation
  });

  const switchWidget = $("#switch").dxSwitch({
    value: true,
    onValueChanged: function (e) {
      locationIndiaChkBox.off(); //  only off the events which are attached by on
      if (e.value == false) {
        rupeeChkBox.dispose();
        usdChkBox.dispose();
        console.log(rupeeChkBox);
      }
    },
  });
}

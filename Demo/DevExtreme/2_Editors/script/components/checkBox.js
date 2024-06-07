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
      <div class='left'>withLabel</div>
      <div class='right' id='withLabel1'></div>
      <div class='right' id='withLabel2'></div>
    </div>`
  );

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
    })
    .dxCheckBox("instance");

  const usdChkBox = $("#usd")
    .dxCheckBox({
      value: false,
      disabled: true,
    })
    .dxCheckBox("instance");

  $("#withLabel1").dxCheckBox({
    text: "Technical",
  });

  $("#withLabel2").dxCheckBox({
    text: "Non-Technical",
  });
}

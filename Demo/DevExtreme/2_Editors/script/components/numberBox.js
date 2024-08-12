export default function showNumberBox() {

  // remove "content" to delete previously loaded script
  $("#content").remove();

  // append again "content" to container 
  $(".container").append("<div id='content'></div>");

  /* added html components for demonstration */

  $("#content").append(
    `<div class='left-right'>
      <div class='left'>SIP Amount</div>
      <div class='right' id='sipAmount'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right'>
      <div class='left'>Annual Rate of Return</div>
      <div class='right' id='rate'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right'>
      <div class='left'>Period (years) </div>
      <div class='right' id='years'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right'>
      <div class='left'>Compounding Frequency</div>
      <div class='right' id='compondingFrequency'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right'>
      <div class='left'>Total Amount</div>
      <div class='right' id='totalAmount'></div>
    </div>`
  );

  $("#content").append(`<div id='calculateBtn'></div>`);

  $("#sipAmount").dxNumberBox({
    showClearButton: true,
    min: 0, // minimum value
    format: "₹ #", // integer format
    hint: "Monthly SIP Amount",
    mode: "number",
    // on input enter (or) changes
    onInput: () => {
      console.log(calculateWidget);
      // calculateWidget.click();
    },
  });

  $("#rate").dxNumberBox({
    showClearButton: true,
    showSpinButtons: true,
    format: "#,###.## %",
    min: 0,
    hint: "Rate of intrest in percentage",
    onInput: () => {
      console.log(calculateWidget);
      // calculateWidget.click();
    },
  });

  $("#years").dxNumberBox({
    showClearButton: true,
    showSpinButtons: true,
    format: "#.# years",
    min: 0,
    max: 40,
    hint: "number of years",
    useLargeSpinButtons: true,
    onFocusOut: () => {
      console.log(calculateWidget);

      calculateWidget.click();
    },
  });

  $("#compondingFrequency").dxNumberBox({
    value: 12,
    disabled: true,
    hint: "It means you're paying monthly to Mutual funds",
  });

  $("#totalAmount").dxNumberBox({
    format: "₹ #,###.##",
    readOnly: true,
    stylingMode: "underlined",
    hint: "Total amount consists priciple amount + your profit",
  });

  const calculateWidget = $("#calculateBtn")
    .dxButton({
      text: "Calculate",
      onClick: function () {
        console.log("clicked");
        // Retrieve values from NumberBoxes
        const sipAmount = $("#sipAmount")
          .dxNumberBox("instance")
          .option("value");
        const rate = $("#rate").dxNumberBox("instance").option("value") / 100; // Convert percentage to decimal
        const years = $("#years").dxNumberBox("instance").option("value");
        const frequency = 12; // Monthly compounding

        // Calculate the future value of SIP
        const n = years * frequency;
        const i = rate;

        // Future Value of a Series formula
        const totalAmount =
          sipAmount * ((Math.pow(1 + i, n) - 1) / i) * (1 + i);

        // Set the calculated total amount
        $("#totalAmount")
          .dxNumberBox("instance")
          .option("value", totalAmount.toFixed(2));
      },
    })
    .dxButton("instance");
}

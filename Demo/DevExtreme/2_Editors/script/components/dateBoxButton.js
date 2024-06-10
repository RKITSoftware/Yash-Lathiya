export default function showDateBox() {
  $("#content").remove();
  $(".container").append("<div id='content'></div>");

  $("#content").append(
    `<div class='left-right'>
      <div class='left'>Date</div>
      <div class='right' id='date'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right'>
      <div class='left'>Time</div>
      <div class='right' id='time'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right'>
      <div class='left'>Date & Time</div>
      <div class='right' id='dateAndTime'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right'>
      <div class='left'>Custom Format</div>
      <div class='right' id='customFormat'></div>
    </div>`
  );

  $("#content").append(
    `<div class='top'>Birthday Calculator</div>
    <div class='left-right'>
      <div class='left'>Birthday</div>
      <div class='right' id='birthday'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right'>
      <div class='left'>Age</div>
      <div class='right' id='age'></div>
    </div>`
  );

  const now = new Date();
  const holidays = [
    new Date("2024-01-14"), // Makar Sankranti
    new Date("2024-01-26"), // Republic Day
    new Date("2024-03-08"), // Maha Shivaratri
    new Date("2024-03-25"), // Holi
    new Date("2024-04-13"), // Rama Navami
    new Date("2024-04-19"), // Hanuman Jayanti
    new Date("2024-08-15"), // Independence Day
    new Date("2024-08-19"), // Raksha Bandhan
    new Date("2024-08-26"), // Janmashtami
    new Date("2024-09-15"), // Ganesh Chaturthi
    new Date("2024-10-05"), // Navaratri start
    new Date("2024-10-14"), // Dussehra
    new Date("2024-10-17"), // Karva Chauth
    new Date("2024-11-01"), // Diwali
    new Date("2024-11-02"), // Govardhan Puja
    new Date("2024-11-03"), // Bhai Dooj
    new Date("2024-07-21"), // Guru Purnima
  ];

  $("#date").dxDateBox({
    type: "date",
    value: now,
    displayFormat: "dd/MM/yyyy",
    acceptCustomValue: false, // default value is true
    accessKey: "q", // focus on alt + accessKey
    adaptivityEnabled: true, // default value is false --> screen specific UI --> supports UI on smaller screens too
    applyButtonText: "Date is selected", //text displayed on apply button
  });

  $("#time").dxDateBox({
    type: "time",
    value: now,
    displayFormat: "HH:mm:ss ",
    useMaskedBehaviour: true,
    inputAttr: {
      id: "inputTimeId",
    },
  });

  const time = $("#inputTimeId");

  console.log("selected time : ", time);
  $("#dateAndTime").dxDateBox({
    pickerType: "rollers",
    stylingMode: "filled",
    type: "datetime",
    value: now,
    showClearButton: true,
    displayFormat: "dd/MM/yyyy HH:mm:ss ",
    invalidDateMessage: "Value must be a data or time",
  });

  const customDateInstance = $("#customFormat")
    .dxDateBox({
      value: now,
      displayFormat: "EEEE, MMM dd, hh:mm a",
      disabledDates: holidays,
      type: "datetime",
      pickerType: "calender",
      showAnalogClock: true,
      onValueChanged: (e) => {
        console.log("onChange");
        DevExpress.ui.notify({
          message: "value is changed to " + customDateInstance.value,
          position: { my: "top-left", at: "bottom-right", of: "#customFormat" },
        });
      },
      onCopy: () => {
        console.log("onCopy");
        DevExpress.ui.notify({
          message: "value is copied to clipboard",
        });
      },
      onOpened: () => {
        DevExpress.ui.notify({
          message: "drop down is opened",
        });
      },
      // onOptionChanged: () => {
      //   DevExpress.ui.notify({
      //     message: "option is changed",
      //   });
      // },
    })
    .dxDateBox("instance");

  const millisecondsInDay = 24 * 60 * 60 * 1000;

  const birthdayDxBox = $("#birthday")
    .dxDateBox({
      type: "date",
      value: now,
      displayFormat: "dd/MM/yyyy",
      applyValueMode: "useButtons", // can accept "useButtons" or "instantly" (which does not consist buttons)
      max: new Date(),
      min: new Date("1900-01-01"),
      deferRendering: false, // ui will be in html if changes on outside pop up box
      dateOutOfRangeMessage: "Birthdate can not be future date",
      buttons: [
        {
          name: "today",
          location: "before",

          options: {
            text: "Today",
            stylingMode: "text",
            onClick() {
              birthdayDxBox.option("value", new Date().getTime());
            },
          },
        },
        {
          name: "prevDate",
          location: "before",
          options: {
            icon: "spinprev",
            stylingMode: "text",
            onClick() {
              const currentDate = birthdayDxBox.option("value");
              birthdayDxBox.option("value", currentDate - millisecondsInDay);
            },
          },
        },
        {
          name: "nextDate",
          location: "after",
          options: {
            icon: "spinnext",
            stylingMode: "text",
            onClick() {
              const currentDate = birthdayDxBox.option("value");
              birthdayDxBox.option("value", currentDate + millisecondsInDay);
            },
          },
        },
        "dropDown",
      ],
      onValueChanged: (e) => {
        const birthday = new Date(e.value);
        const age = now.getFullYear() - birthday.getFullYear();
        $("#age").dxTextBox({
          disabled: true,
          value: age + " years",
        });
      },
    })
    .dxDateBox("instance");
}

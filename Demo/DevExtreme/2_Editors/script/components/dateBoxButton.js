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
  });

  $("#time").dxDateBox({
    type: "time",
    value: now,
    displayFormat: "HH:mm:ss ",
  });

  $("#dateAndTime").dxDateBox({
    pickerType: "rollers",
    type: "datetime",
    value: now,
    showClearButton: true,
    displayFormat: "dd/MM/yyyy HH:mm:ss ",
  });

  $("#customFormat").dxDateBox({
    value: now,
    displayFormat: "EEEE, MMM dd, hh:mm a",
    disabledDates: holidays,
  });

  $("#birthday").dxDateBox({
    type: "date",
    value: now,
    displayFormat: "dd/MM/yyyy",
    onValueChanged: (e) => {
      const birthday = new Date(e.value);
      const age = now.getFullYear() - birthday.getFullYear();
      $("#age").dxTextBox({
        disabled: true,
        value: age + " years",
      });
    },
  });
}

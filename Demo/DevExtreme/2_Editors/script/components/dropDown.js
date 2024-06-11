export default function showCdropDown() {
  $("#content").remove();
  $(".container").append("<div id='content'></div>");

  $("#content").append(
    `<div class='left-right'>
      <div class='left'>Job Role</div>
      <div class='right' id='jobrole'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right'>
      <div class='left'>Favorite Cricketers</div>
      <div class='right' id='fav'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right'>
      <div class='left'>Skills</div>
      <div class='right' id='skills'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right'>
      <div class='left'>Countries</div>
      <div class='right' id='countries'></div>
    </div>`
  );

  $("#content").append(`<div id='hideBtn'></div>`);

  $("#content").append(`<div id='consoleDataSourceBtn'></div>`);

  const jobRoles = [
    "Frontend Developer",
    "Backend Developer",
    "Full Stack Developer",
    "Flutter Developer",
  ];

  const jobRoleWidget = $("#jobrole")
    .dxDropDownBox({
      value: "",
      dataSource: jobRoles,
      placeholder: "job profile",
      hint: "you can type your custom role too",
      acceptCustomValue: true, //user can add custom value
      buttons: [
        {
          name: "clearr",
          location: "after",
          options: {
            icon: "close",
            onClick: (e) => {
              jobRoleWidget.option("value", ""); // Clear the dropdown value
              console.log("clear button clicked");
            },
          },
        },
      ],
      contentTemplate: (e) => {
        const $list = $("<div>").dxList({
          dataSource: e.component.option("dataSource"),
          selectionMode: "single",
          onSelectionChanged: (arg) => {
            console.log(arg);
            e.component.option("value", arg.addedItems[0]);
            e.component.close();
          },
        });
        return $list;
      },
      onEnterKey: () => {
        DevExpress.ui.notify({
          message: "enter is pressed",
        });
      },
      onFocusIn: () => {
        DevExpress.ui.notify({
          message: "focus in",
        });
      },
      onFocusOut: () => {
        DevExpress.ui.notify({
          message: "focus out",
        });
      },
      onKeyDown: () => {
        DevExpress.ui.notify({
          message: jobRoleWidget.option("value"),
        });
      },
      onOpened: () => {
        DevExpress.ui.notify({
          message: "drop down is opened",
        });
      },
    })
    .dxDropDownBox("instance");

  console.log(jobRoleWidget);

  const cricketers = [
    {
      bcci_id: 1001,
      name: "Sachin Tendulkar",
      role: "batsman",
      team: "Mumbai Indians",
    },
    {
      bcci_id: 1002,
      name: "Mahendra Singh Dhoni",
      role: "wicketkeeper - batsman",
      team: "Chennai Super Kings",
    },
    {
      bcci_id: 1003,
      name: "Rohit Sharma",
      role: "batsman",
      team: "Mumbai Indians",
    },
    {
      bcci_id: 1004,
      name: "Gautam Gambhir",
      role: "batsman",
      team: "Kolkata Knight Riders",
    },
    {
      bcci_id: 1005,
      name: "Suresh Raina",
      role: "batsman",
      team: "Chennai Super Kings",
    },
  ];

  const selectedValue = cricketers[0].bcci_id;

  $("#fav").dxDropDownBox({
    value: selectedValue,
    valueExpr: "bcci_id",
    displayExpr: "name",
    showDropDownButton: false,
    stylingMode: "underlined", // accepts outlined, underlined & filled
    showClearButton: true,
    dataSource: new DevExpress.data.ArrayStore({
      data: cricketers,
      key: "bcci_id",
    }),
    dropDownOptions: {
      width: "500px",
    },
    contentTemplate: (e) => {
      const $dataGrid = $("<div>").dxDataGrid({
        dataSource: e.component.option("dataSource"),
        columns: ["name", "role", "team"],
        height: 250,
        selection: { mode: "single" },
        selectedRowKeys: [selectedValue],
        onSelectionChanged: (selectedItems) => {
          const keys = selectedItems.selectedRowKeys,
            hasSelection = keys.length;
          e.component.option("value", hasSelection ? keys[0] : null);
          e.component.close();
        },
      });
      return $dataGrid;
    },
  });

  const skills = [
    "JavaScript",
    "React",
    "Angular",
    "Vue",
    "Node.js",
    "Python",
    "Java",
    "C#",
    "PHP",
  ];

  $("#skills").dxDropDownBox({
    value: [],
    dataSource: skills,
    isValid: false,
    placeholder: "skill-set",
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
    onChange: () => {
      console.log("onChange");
    },
    onClosed: () => {
      DevExpress.ui.notify({
        message: "ui is closed",
      });
      console.log("onClosed");
    },
  });

  let countryList = [];
  $.get("https://api.first.org/data/v1/countries", (data) => {
    Object.values(data.data).map((countryObj) => {
      countryList.push(countryObj.country);
    });
    console.log(countryList);
  });

  const countriesWidget = $("#countries")
    .dxDropDownBox({
      value: "",
      dataSource: countryList,
      focusStateEnabled: true,
      placeholder: "America",
      acceptCustomValue: true, //user can add custom value
      buttons: [
        {
          name: "clearr",
          location: "after",
          options: {
            icon: "close",
            onClick: (e) => {
              countriesWidget.option("value", ""); // Clear the dropdown value
              console.log("clear button clicked");
            },
          },
        },
      ],
      contentTemplate: (e) => {
        const $list = $("<div>").dxList({
          dataSource: e.component.option("dataSource"),
          selectionMode: "single",
          onSelectionChanged: (arg) => {
            console.log(arg);
            e.component.option("value", arg.addedItems[0]);
            e.component.close();
          },
        });
        return $list;
      },
    })
    .dxDropDownBox("instance");

  $("#hideBtn").dxButton({
    text: "Hide Job Profile",
    onClick: () => {
      jobRoleWidget.option("visible", false);
    },
  });

  $("#consoleDataSourceBtn").dxButton({
    text: "Console Data Source",
    onClick: () => {
      const ds = jobRoleWidget.getDataSource();
      console.log("dataSource", ds);
      jobRoleWidget.open();
    },
  });
}

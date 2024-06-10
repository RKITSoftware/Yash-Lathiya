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

  const jobRoles = [
    "Frontend Developer",
    "Backend Developer",
    "Full Stack Developer",
    "Flutter Developer",
  ];

  $("#jobrole").dxDropDownBox({
    value: "",
    dataSource: jobRoles,
    acceptCustomValue: true, //user can add custom value
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
  });

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
    contentTemplate: (e) => {
      const $tagBox = $("<div>").dxTagBox({
        dataSource: e.component.option("dataSource"),
        value: e.component.option("value"),
        showSelectionControls: true,
        maxDisplayedTags: 5,
        onValueChanged: (args) => {
          e.component.option("value", args.value);
        },
      });
      return $tagBox;
    },
  });
}

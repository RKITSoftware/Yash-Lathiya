export default function showSelectBox() {
  $("#content").remove();
  $(".container").append("<div id='content'></div>");

  $("#content").append(
    `<div class='left-right'>
      <div class='left'>Dream 11 Id</div>
      <div class='right' id='id'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right'>
      <div class='left'>Favourite Team of IPL</div>
      <div class='right' id='team'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right'>
      <div class='right' id='msg'></div>
    </div>`
  );

  const dream11Ids = [
    "d123",
    "d456",
    "d789",
    "d234",
    "d345",
    "d567",
    "d678",
    "d910",
  ];

  $("#id").dxSelectBox({
    items: dream11Ids,
    acceptCustomValue: true,
  });

  const teams = [
    {
      key: "Champions",
      items: [
        {
          id: 1,
          teamName: "Chennai Super Kings",
          imgLink: "../assets/images/csk.png",
          msg: "I'm Dhoni fan too",
        },
        {
          id: 3,
          teamName: "Mumbai Indians (till '23)",
          imgLink: "../assets/images/mi.png",
          msg: "RO-HIT Sharma",
        },
      ],
    },
    {
      key: "Overrated Teams",
      items: [
        {
          id: 2,
          teamName: "Delhi Capitals",
          imgLink: "../assets/images/dc.png",
          msg: "I'm Pant fan too",
        },
        {
          id: 4,
          teamName: "Kolkata Knight Riders",
          imgLink: "../assets/images/kkr.jpg",
          msg: "man of the match wo hota hain jisne sabse jyada run banaye !!!",
        },
        {
          id: 5,
          teamName: "Royal Challenges Banglore",
          imgLink: "../assets/images/rcb.png",
          msg: "Not agreed to E sal kap nam de.. ",
        },
        {
          id: 6,
          teamName: "Rajsthan Royals",
          imgLink: "../assets/images/rr.png",
          msg: "thoda paani milega.. ??",
        },
        {
          id: 3,
          teamName: "Gujarat Titans",
          imgLink: "../assets/images/gt.png",
          msg: "Here was Hardik !!",
        },
      ],
    },
  ];

  const favTeamWidget = $("#team")
    .dxSelectBox({
      dataSource: teams,
      displayExpr: "teamName",
      valueExpr: "id",
      value: teams[0].items[0].id,
      acceptCustomValue: false,
      grouped: true, // data source is grouped
      searchEnabled: true, // enabling
      fieldTemplate(data, container) {
        const result = $(`<div class='fav-team'>
                            <img src='${data.imgLink}' />
                            <div class='team-name'></div>
                          </div>`);
        result.find(".team-name").dxTextBox({
          value: data && data.teamName,
          // readOnly: true,
        });
        container.append(result);
      },
      itemTemplate(data) {
        return `<div class='fav-team'>
                  <img src='${data.imgLink}' />
                  <div class='team-name'>${data.teamName}</div>
                </div>`;
      },
      onValueChanged(data) {
        const selectedTeam = teams
          .flatMap((group) => group.items)
          .find((team) => team.id === data.value);
        msgwidget.option("value", selectedTeam ? selectedTeam.msg : "");
      },
    })
    .dxSelectBox("instance");

  const msgwidget = $("#msg")
    .dxTextBox({
      value: teams[0].items[0].msg,
      readOnly: true,
      width: "100%",
    })
    .dxTextBox("instance");
}
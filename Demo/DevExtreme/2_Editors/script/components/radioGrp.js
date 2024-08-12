export default function showRadioGrp() {
  
  // remove "content" to delete previously loaded script
  $("#content").remove();

  // append again "content" to container 
  $(".container").append("<div id='content'></div>");

  /* added html components for demonstration */

  $("#content").append(
    `<div class='left-right'>
      <div class='left'>Meeting Priority (Vertical)</div>
      <div class='right' id='vertical'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right'>
      <div class='left'>Meeting Priority (Horizontal)</div>
      <div class='right' id='horizontal'></div>
    </div>`
  );

  $("#content").append(
    `<div class='left-right'>
      <div class='left'>Confirmed Priority</div>
      <div class='right' id='confirmed'></div>
    </div>`
  );

  const priorities = ["Low", "Normal", "Urgent", "High"];

  // it's vertical ui of radio group
  const vertical = $("#vertical")
    .dxRadioGroup({
      items: priorities,
      value: priorities[0],
      onValueChanged: (e) => {
        // console.log(e.value);
        confirmed.option("value", e.value);
      },
      itemTemplate: (itemData, _, itemElement) => {
        console.log("itemData", itemData);
        console.log("itemElement", itemElement);
        itemElement.parent().addClass(itemData.toLowerCase()).text(itemData);
      },
    })
    .dxRadioGroup("instance");

  $("#horizontal").dxRadioGroup({
    items: priorities,
    value: priorities[0],
    layout: "horizontal",
    onValueChanged: (e) => {
      console.log(e.value);
    },
  });

  const confirmed = $("#confirmed")
    .dxTextArea({
      readOnly: true,
      value: vertical.option("value"),
    })
    .dxTextArea("instance");
}

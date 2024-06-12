export default function showButton() {
  $("#content").remove();
  $(".container").append("<div id='content'></div>");

  $("#content").append(`<div class='btn' id='stylingMode'></div>`);

  $("#content").append(`<div class='btn' id='type'></div>`);

  const styles = [
    {
      id: 0,
      text: "Contained",
      stylingMode: "contained",
    },
    {
      id: 1,
      text: "Outlined",
      stylingMode: "outlined",
    },
    {
      id: 2,
      text: "Text",
      stylingMode: "text",
    },
  ];

  const types = [
    {
      id: 0,
      text: "Normal",
      type: "normal",
    },
    {
      id: 1,
      text: "Default",
      type: "default",
    },
    {
      id: 2,
      text: "Success",
      type: "success",
    },
    {
      id: 3,
      text: "Danger",
      type: "danger",
    },
    {
      id: 4,
      text: "Back",
      type: "back",
    },
  ];

  let currentIndex = 0;
  let currentTypeIndex = 0;

  const stylingModeButton = $("#stylingMode")
    .dxButton({
      type: "default",
      text: styles[currentIndex].text,
      stylingMode: styles[currentIndex].stylingMode,
      icon: "check",
      onClick: () => {
        // Increment the index to get the next style, and reset to 0 if at the end
        currentIndex = (currentIndex + 1) % styles.length;

        // Get the new style
        const newStyle = styles[currentIndex];
        console.log(newStyle);
        // Update the button's text and stylingMode
        stylingModeButton.option("text", newStyle.text);
        stylingModeButton.option("stylingMode", newStyle.stylingMode);
      },
    })
    .dxButton("instance");

  const typeButton = $("#type")
    .dxButton({
      type: types[currentTypeIndex].type,
      text: types[currentTypeIndex].text,
      onClick: () => {
        // Increment the index to get the next type, and reset to 0 if at the end
        currentTypeIndex = (currentTypeIndex + 1) % types.length;

        // Get the new type
        const newType = types[currentTypeIndex];
        console.log(newType);
        // Update the button's text and type
        typeButton.option("text", newType.text);
        typeButton.option("type", newType.type);
      },
    })
    .dxButton("instance");
}

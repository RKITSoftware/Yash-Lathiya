var buttonWidget;

$(function () {
  // toast
  const toast = $("#toast").dxToast({ displayTime: 600 }).dxToast("instance");

  const buttonContainer = $("#buttonContainer").dxButton({
    // text of component
    text: "Dx Button",

    accessKey: "a", // can be accessed by Alt + a

    activeStateEnabled: false, // true (by-default) -> UI changes active .. false --> no UI interactive

    disabled: false, // true (by-default) ->

    // can add element attributes like class & id
    elementAttr: {
      class: "my-custom-class dx-yash",
    },

    focusStateEnabled: true, // true (by-default) -> can be focused by keyboard .. false --> cannot be focused by keyboard

    hint: "Im' dx hint", // specifies hint when user pauses(similar to mouse over) UI component

    hoverStateEnabled: false, // (by-default : true) hover state enabling

    icon: "https://www.devexpress.com/Content/Core/facebook-share-icon.png", // icon of container
    // icon: "save",

    stylingMode: "outlined", // text, outlined & contained

    type: "danger", // black, danger, default, normal, succeess

    visible: true, // visibility

    // click event of the container
    onClick: function () {
      alert("Hello world!");
    },

    // when contenmt is ready
    onContentReady: () => {
      toast.option({
        message: "Dx Button is ready",
        type: "success",
      });
      toast.show();
    },

    // onInitialized
    onInitialized: () => {
      toast.option({
        message: "Dx Button is initialized",
      });
      toast.show();
    },

    // specifies height of the container
    height: () => {
      return window.innerHeight / 5;
    },

    // specifies width of the container
    width: () => {
      return 300;
    },
  });

  console.log("widget", buttonWidget);

  console.log("container", buttonContainer);

  // instance
  buttonWidget = buttonContainer.dxButton("instance");

  // get method
  const btnType = buttonWidget.option("type");

  // set method
  buttonWidget.option("type", "success");

  $("#disabledBtn").dxButton({
    disabled: true, // disabled component
  });

  // destroy widget

  $("#removeBtn").dxButton({
    text: "Remove",
    onClick: () => {
      buttonContainer.remove();
    },
  });

  $("#disposeBtn").dxButton({
    text: "Dispose",
    onClick: () => {
      buttonWidget.dispose();
    },
  });
});

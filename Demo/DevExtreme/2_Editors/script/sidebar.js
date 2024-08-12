import showCheckBox from "./components/checkBox.js";
import showDropDown from "./components/dropDown.js";
import showNumberBox from "./components/numberBox.js";
import showSelectBox from "./components/selectBox.js";
import showTextArea from "./components/textArea.js";
import showTextBox from "./components/textBox.js";
import showButton from "./components/button.js";
import showFileUploader from "./components/fileUploader.js";
import showValidation from "./components/validation.js";
import showRadioGrp from "./components/radioGrp.js";
import showDateBox from "./components/dateBoxButton.js";

$(() => {

  // Here each button of sidebar contains onClick event which loads the respective Demo of dxEditor on "content" container

  $("#checkBoxBtn").dxButton({
    text: "Check Box",
    width: () => {
      return window.innerHeight;
    },
    onClick: () => {
      showCheckBox();
    },
  });

  $("#dateBoxBtn").dxButton({
    text: "Date Box",
    width: () => {
      return window.innerHeight;
    },
    onClick: () => {
      showDateBox();
    },
  });

  $("#dropDownBtn").dxButton({
    text: "Drop Down",
    width: () => {
      return window.innerHeight;
    },
    onClick: () => {
      showDropDown();
    },
  });

  $("#numberBoxBtn").dxButton({
    text: "Number Box",
    width: () => {
      return window.innerHeight;
    },
    onClick: () => {
      showNumberBox();
    },
  });

  $("#selectBoxBtn").dxButton({
    text: "Select Box",
    width: () => {
      return window.innerHeight;
    },
    onClick: () => {
      showSelectBox();
    },
  });

  $("#textAreaBtn").dxButton({
    text: "Text Area",
    width: () => {
      return window.innerHeight;
    },
    onClick: () => {
      showTextArea();
    },
  });

  $("#textBoxBtn").dxButton({
    text: "Text Box",
    width: () => {
      return window.innerHeight;
    },
    onClick: () => {
      showTextBox();
    },
  });

  $("#btnBtn").dxButton({
    text: "Button",
    width: () => {
      return window.innerHeight;
    },
    onClick: () => {
      showButton();
    },
  });

  $("#fileUploaderBtn").dxButton({
    text: "File Uploader",
    width: () => {
      return window.innerHeight;
    },
    onClick: () => {
      showFileUploader();
    },
  });

  $("#validationBtn").dxButton({
    text: "Validation",
    width: () => {
      return window.innerHeight;
    },
    onClick: () => {
      showValidation();
    },
  });

  $("#radioGrpBtn").dxButton({
    text: "Radio Group",
    width: () => {
      return window.innerHeight;
    },
    onClick: () => {
      showRadioGrp();
    },
  });
});

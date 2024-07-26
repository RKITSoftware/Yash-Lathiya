import showLoadIndicator from "./components/loadIndicator.js";
import showLoadPanel from "./components/loadPanel.js";
import showPopover from "./components/popover.js"
import showPopup from "./components/popup.js"
import showToast from "./components/toast.js"

$(() => {
    $("#loadIndicatorBtn").dxButton({
      text: "Load Indicator",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        showLoadIndicator();
      },
    });

    $("#loadPanelBtn").dxButton({
      text: "Load Panel",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        showLoadPanel();
      },
    });

    $("#popoverBtn").dxButton({
      text: "Popover",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        showPopover();
      },
    });

    $("#popupBtn").dxButton({
      text: "Popup",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        showPopup();
      },
    });

    $("#toastBtn").dxButton({
      text: "toast",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        showToast();
      },
    });
});
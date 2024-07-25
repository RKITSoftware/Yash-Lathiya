import showMenu from "./components/menu.js";
import showTreeView from "./components/treeView.js";

$(() => {
    $("#menuBtn").dxButton({
      text: "Menu",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        showMenu();
      },
    });

    $("#treeViewBtn").dxButton({
      text: "Tree View",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        showTreeView();
      },
    });
});
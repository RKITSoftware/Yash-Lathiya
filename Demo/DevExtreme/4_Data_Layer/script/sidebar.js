import showArrayStore from "./components/arrayStore.js";
import showCustomStore from "./components/customStore.js";
import showDataSource from "./components/dataSource.js";
import showLocalStore from "./components/localStore.js";
import showQuery from "./components/query.js";

$(() => {
  $("#arrayStoreBtn").dxButton({
    text: "Array Store",
    width: () => {
      return window.innerHeight;
    },
    onClick: () => {
      showArrayStore();
    },
  });

  $("#customStoreBtn").dxButton({
    text: "Custom Store",
    width: () => {
      return window.innerHeight;
    },
    onClick: () => {
      showCustomStore();
    },
  });

  $("#dataSourceBtn").dxButton({
    text: "Data Source",
    width: () => {
      return window.innerHeight;
    },
    onClick: () => {
      showDataSource();
    },
  });

  $("#localStoreBtn").dxButton({
    text: "Local Store",
    width: () => {
      return window.innerHeight;
    },
    onClick: () => {
      showLocalStore();
    },
  });

  $("#queryBtn").dxButton({
    text: "Query",
    width: () => {
      return window.innerHeight;
    },
    onClick: () => {
      showQuery();
    },
  });
});

import showDataBinding from "./components/dataBinding.js";
import showPagingAndScrolling from "./components/pagingAndScrolling.js";
// import showDataSource from "./components/dataSource.js";
// import showLocalStore from "./components/localStore.js";
// import showQuery from "./components/query.js";

$(() => {
  $("#dataBindingBtn").dxButton({
    text: "Data Binding",
    width: () => {
      return window.innerHeight;
    },
    onClick: () => {
      showDataBinding();
    },
  });

    $("#pagingAndScrollingBtn").dxButton({
      text: "Paging & Scrolling",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        showPagingAndScrolling();
      },
    });

  //   $("#dataSourceBtn").dxButton({
  //     text: "Data Source",
  //     width: () => {
  //       return window.innerHeight;
  //     },
  //     onClick: () => {
  //       showDataSource();
  //     },
  //   });

  //   $("#localStoreBtn").dxButton({
  //     text: "Local Store",
  //     width: () => {
  //       return window.innerHeight;
  //     },
  //     onClick: () => {
  //       showLocalStore();
  //     },
  //   });

  //   $("#queryBtn").dxButton({
  //     text: "Query",
  //     width: () => {
  //       return window.innerHeight;
  //     },
  //     onClick: () => {
  //       showQuery();
  //     },
  //   });
});

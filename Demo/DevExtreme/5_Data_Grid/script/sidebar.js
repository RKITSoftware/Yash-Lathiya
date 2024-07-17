import showDataBinding from "./components/dataBinding.js";
import showPagingAndScrolling from "./components/pagingAndScrolling.js";
import showEditing from "./components/editing.js";
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

    $("#editingBtn").dxButton({
      text: "Editing",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        showEditing();
      },
    });

    $("#groupingBtn").dxButton({
      text: "Grouping",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        // showDataSource();
      },
    });
    
    $("#filteringBtn").dxButton({
      text: "Filtering",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        // showDataSource();
      },
    });
    
    $("#sortingBtn").dxButton({
      text: "Sorting",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        // showDataSource();
      },
    });
    
    $("#selectionBtn").dxButton({
      text: "Selection",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        // showDataSource();
      },
    });
    
    $("#columnsBtn").dxButton({
      text: "Columns",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        // showDataSource();
      },
    });
    
    $("#statePersistenceBtn").dxButton({
      text: "State Persistance",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        // showDataSource();
      },
    });
    
    $("#appearanceBtn").dxButton({
      text: "Appearance",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        // showDataSource();
      },
    });
    
    $("#templateBtn").dxButton({
      text: "Template",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        // showDataSource();
      },
    });
    
    $("#dataSummariesBtn").dxButton({
      text: "Data Summaries",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        // showDataSource();
      },
    });
    
    $("#masterDetailBtn").dxButton({
      text: "Master Detail",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        // showDataSource();
      },
    });
    
    $("#exportBtn").dxButton({
      text: "Export",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        // showDataSource();
      },
    });
    
    $("#adaptibilityBtn").dxButton({
      text: "Adaptibility",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        // showDataSource();
      },
    });
});
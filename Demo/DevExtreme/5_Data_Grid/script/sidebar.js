import showDataBinding from "./components/dataBinding.js";
import showPagingAndScrolling from "./components/pagingAndScrolling.js";
import showEditing from "./components/editing.js";
import showGrouping from "./components/grouping.js";
import showFiltering from "./components/filtering.js";
import showSorting from "./components/sorting.js";
import showSelection from "./components/selection.js"
import showColumns from "./components/columns.js";
import showStatePersistence from "./components/statePersistence.js";
import showAppearance from "./components/appearance.js";
import showTemplate from "./components/template.js";
import showDataSummaries from "./components/dataSummaries.js";
import showmasterDetails from "./components/masterDetails.js";

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
        showGrouping();
      },
    });
    
    $("#filteringBtn").dxButton({
      text: "Filtering",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        showFiltering();
      },
    });
    
    $("#sortingBtn").dxButton({
      text: "Sorting",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        showSorting();
      },
    });
    
    $("#selectionBtn").dxButton({
      text: "Selection",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        showSelection();
      },
    });
    
    $("#columnsBtn").dxButton({
      text: "Columns",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        showColumns();
      },
    });
    
    $("#statePersistenceBtn").dxButton({
      text: "State Persistance",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        showStatePersistence();
      },
    });
    
    $("#appearanceBtn").dxButton({
      text: "Appearance",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        showAppearance();
      },
    });
    
    $("#templateBtn").dxButton({
      text: "Template",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        showTemplate();
      },
    });
    
    $("#dataSummariesBtn").dxButton({
      text: "Data Summaries",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        showDataSummaries();
      },
    });
    
    $("#masterDetailBtn").dxButton({
      text: "Master Detail",
      width: () => {
        return window.innerHeight;
      },
      onClick: () => {
        showmasterDetails();
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
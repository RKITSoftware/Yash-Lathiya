export default function showPagingAndScrolling() {
    $("#content").remove();
    $(".container").append("<div id='content'></div>");
  
    $.ajax({
      url : "../script/data/employees.json",
      method : "GET",
      dataType : "json",
      success : (employees) => {
        $("#content").dxDataGrid({
          dataSource : employees,
          keyExpr : "EmployeeID",
          showBorders : true,
          height : 300,
          paging : {
            pageSize : 5,
          },
          pager : {
            visible : true, // accepts true & false
            allowedPageSizes: [5, 10, 'all'],
            showPageSizeSelector : true,
            showInfo : true,
            showNavigationButtons: true,
            displayMode: "full" // full & compact 
          },
          scrolling: {
            mode : "virtual",
            useNative: false,
            scrollByContent: true,
            scrollByThumb: true,
            showScrollbar: "onHover" // "onScroll" | "always" | "never"
          }
        });
      },
      error : () => {
        console.log("error to fetch employees from ajax request")
      }
    })
    
  }
  
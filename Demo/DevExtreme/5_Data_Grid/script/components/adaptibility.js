export default function showAdaptibility() {
    $("#content").remove();
    $(".container").append("<div id='content'></div>");
  
    $.ajax({
      url : "../script/data/employees.json",
      method : "GET",
      dataType : "json",
      success : (employees) => {
        let datagrid = $("#content").dxDataGrid({
          dataSource : employees,
          keyExpr : "EmployeeID",
          columnHidingEnabled : true,
          showBorders : true,
          width : "100%",
          paging : {
            pageSize : 10
          },
          columnChooser : {
            enabled : true,
            mode : "select"
          },
          columns : [
            {
              dataField : 'EmployeeID',
              allowEditing : false,
              width : 30,
              sortOrder: 'asc',
            },
            {
              dataField : "FullName",
            },
            {
              dataField : "Position"
            },
            {
              dataField : "TitleOfCourtesy",
              hidingPriority : 0
            },
            {
              dataField : "BirthDate",
              hidingPriority : 2
            },
            {
              dataField : "Photo",
              hidingPriority : 1
            },
            {
              dataField : "Country",
            }
          ],
        })
          .dxDataGrid("instance");
      },
      error : () => {
        console.log("error to fetch employees from ajax request")
      }
    })
  }
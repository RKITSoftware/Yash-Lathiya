export default function showStatePersistence() {
    $("#content").remove();
    $(".container").append("<div id='content'></div>");
  
    $.ajax({
      url : "../script/data/employees.json",
      method : "GET",
      dataType : "json",
      success : (employees) => {
        // we can restet the state of data grid by ( option => state = null )
        $("#content").dxDataGrid({
          dataSource : employees,
          keyExpr : "EmployeeID",
          paging: {
            pageSize: 10,
          },
          stateStoring : {
            enabled : true,
            type : "localStorage",
            storageKey : "storage"
          },
          columns : [
            {
              dataField : 'EmployeeID',
              caption : "Id",
              width : 50
            },
            {
              dataField : "FullName",
            },
            {
              dataField : "Position"
            },
            {
              dataField : "TitleOfCourtesy",
            },
            {
              dataField : "BirthDate",
              dataType : "date"
            },
            {
              dataField : "Photo",
              width : 550
            },
            {
              dataField : "Country",
            }
          ],
        });
      },
      error : () => {
        console.log("error to fetch employees from ajax request")
      }
    })
    
  }
  
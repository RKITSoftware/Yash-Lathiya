export default function showColumns() {
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
          paging: {
            pageSize: 10,
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
          customizeColumns : (columns) => {
            console.log(columns)
            columns[2].width = 200
          }
        });
      },
      error : () => {
        console.log("error to fetch employees from ajax request")
      }
    })
    
  }
  
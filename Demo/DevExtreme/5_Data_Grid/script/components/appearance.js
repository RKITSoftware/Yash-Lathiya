export default function showAppearance() {
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
          showColumnLines : true,
          showRowLines :true,
          rowAlternationEnabled : true,
          showBorders : true,
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
  
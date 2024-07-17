export default function showGrouping() {
    $("#content").remove();
    $(".container").append("<div id='content'></div>");
  
    $.ajax({
      url : "../script/data/employees.json",
      method : "GET",
      dataType : "json",
      success : (employees) => {
        $("#content").dxDataGrid({
          dataSource : {
            store : {
                type : "array",
                data : employees,
                key : "EmployeeID"
            },
            group : ["Country", "TitleOfCourtesy"]
          },
          grouping : {
            autoExpandAll : false, // by default -> true
          },
          searchPanel : {
            visible : true
          },
          columns : [
            {
              dataField : 'EmployeeID',
              allowEditing : false
            },
            {
              dataField : "FullName",
            },
            {
              dataField : "Position"
            },
            {
              dataField : "TitleOfCourtesy",
              groupIndex : 1
            },
            {
              dataField : "BirthDate"
            },
            {
              dataField : "Photo",
            },
            {
              dataField : "Country",
              groupIndex  : 0
            }
          ]
        });
      },
      error : () => {
        console.log("error to fetch employees from ajax request")
      }
    })
    
  }
  
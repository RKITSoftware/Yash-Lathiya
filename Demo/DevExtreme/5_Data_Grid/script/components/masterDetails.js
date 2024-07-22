export default function showmasterDetails() {
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
          showBorders : true,
          paging : {
            pageSize : 10
          },
          columns : [
            {
              dataField : 'EmployeeID',
              allowEditing : false,
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
            },
            {
              dataField : "BirthDate"
            },
            {
              dataField : "Photo",
            },
            {
              dataField : "Country",
            }
          ],
          masterDetail: {
            enabled : true,
            template(container, option){
                const currentEmployeeData = option.data

                console.log("container", container)
                console.log("currentEmployeeData", currentEmployeeData)

                $("<div>")
                    .text(`Hello, I am master of ${currentEmployeeData.FullName}, I can contain dx functions too like DataGrid!!`)
                    .appendTo(container)
            }
          }
        })
          .dxDataGrid("instance");
      },
      error : () => {
        console.log("error to fetch employees from ajax request")
      }
    })
  }
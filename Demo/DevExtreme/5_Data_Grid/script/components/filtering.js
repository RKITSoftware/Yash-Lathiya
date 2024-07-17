export default function showFiltering() {
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
          filterRow : {
            visible : true,
            applyFilter: "onClick"
          },
          headerFilter : {
            visible :true
          },
          searchPanel : {
            visible : true
          },
          filterPanel : {
            visible : true
          },
          filterSyncEnabled: true,
        //   filterBuilderPopup: {
        //     width: 400,
        //     title: "Filter Builder"
        //   },
        //   filterBuilder : { ggit 
        //     customOperations : [{
        //         name : "isUsaEmployee",
        //         caption : "Is USA Employee ?",
        //         calculateFilterExpression : (filterValue, field) => {
        //             console.log(filterValue, field)
        //             return ["Country", "=", "USA"]
        //         }
        //     }]
        //   },
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
              allowFiltering : false
            },
            {
              dataField : "BirthDate"
            },
            {
              dataField : "Photo",
            },
            {
              dataField : "Country",
            //   filterOperations: ["equals", "isUsaEmployee"]
            }
          ]
        });
      },
      error : () => {
        console.log("error to fetch employees from ajax request")
      }
    })
    
  }
  
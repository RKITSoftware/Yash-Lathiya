export default function showColumns() {
    $("#content").remove();
    $(".container").append(`<div id='content'>
      <h1>Column Customization</h1>
      <div id='columnCustomization'></div>
      <h1>Column Based on Data Source</h1>
      <div id='columnBasedOnDataSource'></div>
      <h1>Multi Row Headers</h1>
      <div id='multiRowHeaders'></div>
      <h1>Column Resizing</h1>
      <div id='columnResizing'></div>
      <h1>Command Column Customization</h1>
      <div id='commandColumnCustomization'></div>
    </div>`);

    $.ajax({
      url : "../script/data/employees.json",
      method : "GET",
      dataType : "json",
      success : (employees) => {
        $("#columnCustomization").dxDataGrid({
          dataSource : employees,
          keyExpr : "EmployeeID",
          paging: {
            pageSize: 10,
          },
          showBorders : true,
          allowColumnReordering : true,
          allowColumnResizing : true,
          columnAutoWidth : true,
          columnChooser : {
            enabled : true
          },
          columnFixing : {
            enabled : true
          },
          columns : [
            {
              dataField : 'EmployeeID',
              caption : "Id",
              width : 50,
              fixed : true,
              alignment : "center" // accepts left & right too          
            },
            {
              dataField : "First Name",
              calculateCellValue(data){
                return data.FullName.split(" ")[0];
              }
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

    $.ajax({
      url : "../script/data/employees.json",
      method : "GET",
      dataType : "json",
      success : (employees) => {
        $("#columnBasedOnDataSource").dxDataGrid({
          dataSource : employees,
          keyExpr : "EmployeeID",
          paging: {
            pageSize: 10,
          },
          showBorders : true,
        });
      },
      error : () => {
        console.log("error to fetch employees from ajax request")
      }
    })

    $.ajax({
      url : "../script/data/countries.json",
      method : "GET",
      dataType : "json",
      success : (countries) => {
        $("#multiRowHeaders").dxDataGrid({
          dataSource : countries,
          keyExpr : "ID",
          columnAutoWidth : true,
          width : "100%",
          columnChooser : {
            enabled : true
          },
          paging: {
            pageSize: 10,
          },
          showBorders : true,
          columns : [
            "Country",
            {
              headerCellTemplate(container) {
                container.append($("<div>Area, km<sup>2</sup></div>"))
              },
              dataField: "Area"
            },
            {
              caption : "Population",
              columns : [
                {
                  caption : "Total",
                  dataField : "Population_Total",
                  format : "fixedPoint"
                },
                {
                  caption : "Urban",
                  dataField : "Population_Urban",
                  format : "percent"
                }
              ]
            },
            {
              caption : "Nomiminal GDP",
              columns : [
                {
                  caption : "Total",
                  dataField : "GDP_Total",
                  format : "fixedPoint",
                  sortOrder : "desc"
                },
                {
                  caption : "By Sector",
                  columns : 
                  [
                    {
                    caption : "Agriculture",
                    dataField : "GDP_Agriculture",
                    width : 95,
                    format : 
                    {
                      type : "percent",
                      precision : 1
                    }
                    },
                    {
                      caption : "Industry",
                      dataField : "GDP_Industry",
                      width : 80,
                      format : 
                      {
                        type : "percent",
                        precision : 1
                      }
                      },
                      {
                        caption : "Services",
                        dataField : "GDP_Services",
                        width : 85,
                        format : 
                        {
                          type : "percent",
                          precision : 1
                        }
                        }
                  ]
                }
              ]
            }
          ]
        });
      },
      error : () => {
        console.log("error to fetch employees from ajax request")
      }
    })

    $.ajax({
      url : "../script/data/employees.json",
      method : "GET",
      dataType : "json",
      success : (employees) => {
        $("#columnResizing").dxDataGrid({
          dataSource : employees,
          keyExpr : "EmployeeID",
          paging: {
            pageSize: 10,
          },
          showBorders : true,
          allowColumnResizing : true,
          columnResizingMode : "widget", // accepts nextColumn & widget
          columnMinWidth : 50,
          columnAutoWidth : true,
          columns : [
            {
              dataField : 'EmployeeID',
              caption : "Id",
              width : 50,
              fixed : true,
              alignment : "center" // accepts left & right too          
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

    $.ajax({
      url : "../script/data/employees.json",
      method : "GET",
      dataType : "json",
      success : (employees) => {
        $("#commandColumnCustomization").dxDataGrid({
          dataSource : employees,
          keyExpr : "EmployeeID",
          paging: {
            pageSize: 10,
          },
          showBorders : true,
          editing : {
            mode : "row",
            allowUpdating : true,
            allowDeleting : true,
            useIcons : true
          }
        });
      },
      error : () => {
        console.log("error to fetch employees from ajax request")
      }
    })
    
  }
  
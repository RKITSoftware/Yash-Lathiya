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

    var states;
    $.ajax({
      url : "../script/data/states.json",
      method : "GET",
      dataType : "json",
      success : (response) => {
        states = response
      },
      error : () => {
        console.log("error occured")
      }
    })
    
    $.ajax({
      url : "../script/data/customers.json",
      method : "GET",
      dataType : "json",
      success : (customers) => {
        console.log(customers)
        let maxID = customers[customers.length-1].ID

        const isChief = (position) => position && ["CEO", "CMO"].indexOf(position.trim().toUpperCase()) >= 0

        $("#commandColumnCustomization").dxDataGrid({
          dataSource : customers,
          keyExpr : "ID",
          paging: {
            enabled : false
          },
          showBorders : true,
          editing : {
            mode : "row",
            allowUpdating : true,
            allowDeleting(e){
              console.log(e)
              return !isChief(e.row.data.Position)
            },
            useIcons : true
          },
          onRowValidating(e){
            const position  = e.newData.Position
            if(isChief(position)){
              e.errorText = `The company can have only one ${position.toUpperCase()}. Please choose another position.`
              e.isValid = false
            }
          },
          onEditorPreparing(e){
            if(e.parentType === "dataRow" && e.dataField === "Position"){
              e.editorOptions.readOnly = isChief(e.value)
            }
          },
          columns : [
            {
              type : "buttons",
              width : 110,
              buttons : [
                "edit",
                "delete",
                {
                  hint : "clone",
                  icon : "copy",
                  visible(e) {
                    return !e.row.isEditing;
                  },
                  disabled(e){
                    return isChief(e.row.data.Position)
                  },
                  onClick(e){

                    // extend method merges content of two or more objects into first one
                    const clonedItem = $.extend({}, e.row.data, { ID: maxID += 1 })
                    customers.splice(e.row.rowIndex, 0, clonedItem)
                    e.component.refresh(true)
                    e.event.preventDefault()
                  }
                }
              ]
            },
            {
              dataField : "Prefix",
              caption  :"Title"
            },
            {
              dataField : "FirstName"
            },
            {
              dataField : "LastName"
            },
            {
              dataField : "Position",
              width : 130
            },
            {
              dataField : "StateID",
              caption : "State",
              width : 125,
              lookup: {
                dataSource : states,
                displayExpr : "Name",
                valueExpr : "ID"
              }
            },
            {
              dataField : "BirthDate",
              dataType : "date",
              width : 125
            }
          ]
        });
      },
      error : () => {
        console.log("error to fetch employees from ajax request")
      }
    })
    
  }
  
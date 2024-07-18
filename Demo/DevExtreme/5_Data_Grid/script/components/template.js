export default function showTemplate() {
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
          onCellPrepared(options){
            const fieldData = options.value
            // console.log(fieldData)
            if(fieldData && fieldData.value){
              fieldData.value("*" + fieldData.value) 
            }
            console.log(options)
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
            },+
            {
              dataField : "TitleOfCourtesy",
            },
            {
              dataField : "BirthDate",
              dataType : "date"
            },
            {
                // column customization
              dataField : "Photo",
              width: 60,
              allowFiltering: false,
              allowSorting: false,
              cellTemplate(container, options) {
                $('<div>')
                .append($('<img>', { src: options.value, alt: `Picture of ${options.data.FirstName} ${options.data.LastName}`, width : 50 }))
                .appendTo(container);
              },
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
  
export default function showTemplate() {
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
          paging: {
            pageSize: 5,
          },
          showColumnLines : true,
          showRowLines :true,
          rowAlternationEnabled : true,
          showBorders : true,
          
          // row customization
          dataRowTemplate(container, item) {
            const { data } = item;
            const markup = '<tr class=\'main-row\' role=\'row\'>'
          + `<td rowspan='2' role="gridcell"><img src='${data.Photo}' alt='Picture of ${data.FirstName} ${data.LastName}' tabindex='0'/></td>`
          + `<td role='gridcell'>${data.EmployeeID}</td>`
          + `<td role='gridcell'>${data.FullName}</td>`
          + `<td role='gridcell'>${data.Position}</td>`
          + `<td role='gridcell'>${data.TitleOfCourtesy}</td>`
          + `<td role='gridcell'>${formatDate(new Date(data.BirthDate))}</td>`
          + `<td role='gridcell'>${formatDate(new Date(data.Country))}</td>`
      + '</tr>'
      + '<tr class=\'notes-row\' role=\'row\'>'
          + `<td colspan='6' role='gridcell'><div>Customized Row Template</div></td>`
      + '</tr>';

      container.append(markup);
          },

          // cell  customization
          onCellPrepared(options){
            const fieldData = options.value
            // console.log(options.cellElement)
            if(fieldData){
              options.cellElement.append("<span>*</span>")
            }
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
                // column customization
              dataField : "Photo",
              width: 60,
              allowFiltering: false,
              allowSorting: false,
              visibleIndex : 0,
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
        })
          .dxDataGrid("instance");
      },
      error : () => {
        console.log("error to fetch employees from ajax request")
      }
    })
    
  }
  
export default function showSelection() {
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
          selection : {
            mode : "multiple", // accepts single or multiple
            selectAllMode : "page",
            showCheckBoxesMode : "always" // also accepts 'none', 'onClick', 'onLongTap', 'always'
          },
          paging: {
            pageSize: 10,
          },
          columns : [
            {
              dataField : 'EmployeeID',
              allowEditing : false,
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
          onSelectionChanged : (selectedItems) => {
            console.log(selectedItems)
          }
        });
      },
      error : () => {
        console.log("error to fetch employees from ajax request")
      }
    })
    
  }
  
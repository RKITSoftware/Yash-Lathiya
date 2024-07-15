export default function showDataBinding() {
  $("#content").remove();
  $(".container").append("<div id='content'></div>");

  $.ajax({
    url : "../script/data/employees.json",
    method : "GET",
    dataType : "json",
    success : (employees) => {
      $("#content").dxDataGrid({
        dataSource : employees,
        keyExpr : "EmployeeID"
      });
    },
    error : () => {
      console.log("error to fetch employees from ajax request")
    }
  })
  
}

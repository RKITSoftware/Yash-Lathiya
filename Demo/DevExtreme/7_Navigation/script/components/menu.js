export default function showMenu() {
    $("#content").remove();
    $(".container").append("<div id='content'></div>");
  
    $.ajax({
      url : "../assets/data/category.json",
      method : "GET",
      dataType : "json",
      success : (categories) => {
        $("#content").dxMenu({
            dataSource : categories,
            displayExpr : "name"
        })
      },
      error : () => {
        console.log("error to fetch employees from ajax request")
      }
    })
  }
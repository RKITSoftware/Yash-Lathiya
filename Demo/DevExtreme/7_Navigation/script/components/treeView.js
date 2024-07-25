export default function showTreeView() {
    $("#content").remove();
    $(".container").append("<div id='content'></div>");
  
    $.ajax({
      url : "../assets/data/products.json",
      method : "GET",
      dataType : "json",
      success : (products) => {
        $("#content").dxTreeView({
            items : products,
            width : 500,
            onItemClick(e){
                console.log(e)
            }
        })
      },
      error : () => {
        console.log("error to fetch employees from ajax request")
      }
    })
  }
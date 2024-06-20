export default function showDataBinding() {
  $("#content").remove();
  $(".container").append("<div id='content'></div>");

  $("#content").dxDataGrid({
    store: ["a", "b", "c"],
    
  });
}

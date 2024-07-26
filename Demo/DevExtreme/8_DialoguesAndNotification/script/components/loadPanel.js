export default function showLoadPanel() {
  $("#content").remove();
  $(".container").append(`
    <div id='content'>
      <h2>Load Panel (with Loading Indicator)</h2>
        <div id='loadPanel1'></div>
        <div id='dataGrid1'></div>
    </div>`);
  

  $("#loadPanel1").dxLoadPanel({
    visible: false,
    shading: true,
    shadingColor: '#ff0000',
    position: { of: '#dataGrid1' },
    showIndicator: true,
    message: 'Fetching Data ...'
  });

  // Show the LoadPanel, get data, and hide the LoadPanel
  $("#loadPanel1").dxLoadPanel("instance").option("visible", true);


  $.get("../assets/data/customers.json", customers => {
    $("#dataGrid1")
      .dxDataGrid({
        dataSource : customers,
        paging: {
          pageSize :5
        }
    })

      $("#loadPanel1").dxLoadPanel("instance").option("visible", false);
  })  
}
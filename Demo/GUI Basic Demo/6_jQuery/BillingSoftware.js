$(document).ready(function () {
  //Initialize Total Amount
  var totalAmount = 0.0;
  $("#totalAmount").val(Number(totalAmount).toFixed(2));

  //Initialize Sr No.
  var srNumber = 1;
  $("#srNo").val(srNumber);

  //Print Amount
  $("#itemQuantity, #itemPrice").keyup(function () {
    const amount =
      Number($("#itemPrice").val()) * Number($("#itemQuantity").val());
    $("#itemAmount").val(amount);
  });

  console.log($("#itemPrice").val());

  //Add item details in new row
  $("#btnAddItem").click(function () {
    const srNo = $("#srNo").val();
    const itemName = $("#itemName").val();
    const itemPrice = Number($("#itemPrice").val()).toFixed(2);
    const itemQuantity = Number($("#itemQuantity").val()).toFixed(2);
    const itemAmount = Number($("#itemAmount").val()).toFixed(2);
    var tableRow =
      "<tr><td>" +
      srNo +
      "</td><td>" +
      itemName +
      "</td><td>" +
      itemPrice +
      "</td><td>" +
      itemQuantity +
      "</td><td>" +
      itemAmount +
      "</td></tr>";
    $("#tableItemDetails").append(tableRow);
    //Update totalAmount
    totalAmount += Number(itemAmount);
    $("#totalAmount").val(totalAmount.toFixed(2));
    //Update srNumber
    srNumber += 1;
    $("#srNo").val(srNumber);
  });
});

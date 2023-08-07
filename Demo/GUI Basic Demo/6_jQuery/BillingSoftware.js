$(document).ready(function () {
  //Store billNumber in local storage
  if (localStorage.billNumber) {
    console.log("Bill Number :" + localStorage.billNumber);
  } else {
    localStorage.billNumber = 1001;
  }
  $("#billNumberId").val(localStorage.billNumber);

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

  //Reset Items
  $("#btnResetItems").click(function () {
    //Remove table Content
    $("#tableItemDetails tr:nth-child(2)").nextAll().remove();
    //Reset SrNumber
    srNumber = 1;
    $("#srNo").val(srNumber);
    //Reset Form values
    $("#itemName").val("");
    $("#itemPrice").val("");
    $("#itemQuantity").val("");
    $("#itemAmount").val("");
    //Reset Total Amount
    totalAmount = 0.0;
    $("#totalAmount").val(Number(totalAmount).toFixed(2));
  });

  //Add item details in new row
  $("#btnAddItem").click(function () {
    const srNo = $("#srNo").val();
    const itemName = $("#itemName").val();
    const itemPrice = Number($("#itemPrice").val()).toFixed(2);
    const itemQuantity = Number($("#itemQuantity").val()).toFixed(2);
    const itemAmount = Number($("#itemAmount").val()).toFixed(2);
    //Blank fields are not allowed
    if (itemName.trim() === "") {
      alert("Enter Item Name");
      return false;
    }
    if (itemPrice.trim() == 0.0) {
      alert("Enter Item Price");
      return false;
    }
    if (itemQuantity.trim() == 0.0) {
      alert("Enter Item Quantity");
      return false;
    }
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

  //Confirm Bill Details
  $("#btnConfirm").click(function () {
    localStorage.billNumber = Number(localStorage.billNumber) + 1;
    $("#billNumberId").val(localStorage.billNumber);
  });
});

$(document).ready(function () {
  //Store billNumber in local storage
  if (localStorage.billNumber) {
    console.log("Bill Number :" + localStorage.billNumber);
  } else {
    localStorage.billNumber = 1001;
  }
  $("#billNumberId").val(localStorage.billNumber);

  //red star is assigned to compulsory fields
  $("span").addClass("requiredSpan");

  //Set Current date
  $("#billDate").val(new Date().toISOString().split("T")[0]);

  //Initialize Total Amount
  var totalAmount = 0.0;
  $("#totalAmount").val(Number(totalAmount).toFixed(2));

  //Initialize Sr No.
  var srNumber = 1;
  $("#srNo").val(srNumber);

  //Load Bills from External JSON file
  $("#bills").load("Bills.json", function (data) {
    var bills = JSON.parse(data);
    console.log(bills);
    for (let i = 0; i < bills.length; i++) {
      let rowPriviousBills =
        "<tr><td>" +
        bills[i].billDate +
        "</td><td>" +
        bills[i].billNumber +
        "</td><td>" +
        bills[i].billTotalAmount +
        "</td><td>" +
        bills[i].customerName +
        "</td><td>" +
        bills[i].customerId +
        "</td><td>" +
        bills[i].customerAddress +
        "</td></tr>";
      $("#tablePreviousBills").append(rowPriviousBills);
    }
  });

  //Load Confirmed Bills from localstorage
  let confirmedBillsString = "[" + localStorage.bills + "]";
  var confirmedBills = JSON.parse(confirmedBillsString);
  console.log(confirmedBills);
  $("#tableConfirmedBills tr:nth-child(2)").nextAll().remove();
  for (let i = 0; i < confirmedBills.length; i++) {
    let rowConfirmedBills =
      "<tr><td>" +
      confirmedBills[i].billDate +
      "</td><td>" +
      confirmedBills[i].billNumber +
      "</td><td>" +
      confirmedBills[i].billTotalAmount +
      "</td><td>" +
      confirmedBills[i].customerName +
      "</td><td>" +
      confirmedBills[i].customerId +
      "</td><td>" +
      confirmedBills[i].customerAddress +
      "</td></tr>";
    $("#tableConfirmedBills").append(rowConfirmedBills);
  }

  //SearchBar for Confirmed Bill
  $("#searchBar").on("keyup", function () {
    var value = $("#searchBar").val().toLowerCase();
    $("#tableConfirmedBills tr").filter(function () {
      $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
      $("#tableConfirmedBills tr:nth-child(1)").show();
    });
  });

  //SearchBar for Previous Bill
  $("#searchBar").on("keyup", function () {
    var value = $("#searchBar").val().toLowerCase();
    $("#tablePreviousBills tr").filter(function () {
      $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
      $("#tablePreviousBills tr:nth-child(1)").show();
    });
  });

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
    // Blank fields are not allowed
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
    //data of bill
    const billNo = $("#billNumberId").val();
    const customerId = $("#customerId").val();
    const billDate = $("#billDate").val();
    const customerName = $("#customerName").val();
    const customerAddress = $("#customerAddress").val();
    const billTotalAmount = $("#totalAmount").val();

    //before confirmation checks all fields are filled up or not
    //[date, customerName, totalAmount]
    requiredFormValidation = [1, 1, 1];
    let errorMessage = "";
    if (billDate === "") {
      requiredFormValidation[0] = 0;
      errorMessage += "Bill Date is required,";
    }
    if (customerName.trim() === "") {
      requiredFormValidation[1] = 0;
      errorMessage += "\nPlease Enter Customer Name, ";
    }
    if (billTotalAmount == 0.0) {
      requiredFormValidation[2] = 0;
      errorMessage += "\nYou can not generate bill with 0 amount";
    }
    console.log(errorMessage);
    for (let i = 0; i < 3; i++) {
      if (requiredFormValidation[i] == 0) {
        alert(errorMessage);
        return false;
      }
    }

    //Make a object of all Bill Details...
    let billDetails = {
      billNumber: billNo,
      billDate: billDate,
      customerId: customerId,
      customerName: customerName,
      customerAddress: customerAddress,
      billTotalAmount: billTotalAmount,
    };
    console.log(billDetails);

    //Store that object (bill) in local storage
    const billDetail = JSON.stringify(billDetails);
    if (localStorage.bills) {
      localStorage.bills = localStorage.bills + "," + billDetail;
    } else {
      localStorage.bills = billDetail;
    }
    console.log(billDetail);

    //Increment billNumber in local storage
    localStorage.billNumber = Number(localStorage.billNumber) + 1;
    $("#billNumberId").val(localStorage.billNumber);

    //reset bill inputs
    $("#btnResetItems").trigger("click");
    $("#customerId").val("");
    $("#customerName").val("");
    $("#customerAddress").val("");
    $("#billDate").val(new Date().toISOString().split("T")[0]);
    alert("Bill added successfully");

    //Load Confirmed Bills from localstorage
    // let confirmedBillsString = "[" + localStorage.bills + "]";
    // var confirmedBills = JSON.parse(confirmedBillsString);
    // console.log(confirmedBills);
    // $("#tableConfirmedBills tr:nth-child(2)").nextAll().remove();
    // for (let i = 0; i < confirmedBills.length; i++) {
    //   let rowConfirmedBills =
    //     "<tr><td>" +
    //     confirmedBills[i].billDate +
    //     "</td><td>" +
    //     confirmedBills[i].billNumber +
    //     "</td><td>" +
    //     confirmedBills[i].billTotalAmount +
    //     "</td><td>" +
    //     confirmedBills[i].customerName +
    //     "</td><td>" +
    //     confirmedBills[i].customerId +
    //     "</td><td>" +
    //     confirmedBills[i].customerAddress +
    //     "</td></tr>";
    //   $("#tableConfirmedBills").append(rowConfirmedBills);
    // }
  });
});

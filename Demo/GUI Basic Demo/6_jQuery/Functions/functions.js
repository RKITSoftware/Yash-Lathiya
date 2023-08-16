$(document).ready(function () {
  //Implementation of Map
  $("#btnSubmit").on("click", function (event) {
    event.preventDefault();
    $("input").map(function () {
      console.log($(this)[0]);
      console.log($(this).val());
    });
  });

  //Grep Function
  var array = [20, 50, 80, 110, 140, 170, 200];
  var filteredArray = $.grep(array, function (value, index) {
    if (value > 100 && index < 6) {
      return true;
    }
  });
  console.log("Filtered Array: ", filteredArray);

  //Object Declarataion
  var object1 = {
    firstName: "Yash",
    lastName: "Lathiya",
    subjects: { subject1: "ML", subject2: "AI" },
  };
  var object2 = {
    enrollment: "2002001070950",
    subjects: { subject3: "CD" },
  };

  //Implementation of extend function
  var object3 = $.extend(true, object1, object2);
  console.log("Object 3 :", object3);

  //Each function on object
  $.each(object3, function (propertyName, propertyValue) {
    console.log(propertyName, " : ", propertyValue);
  });

  //Array Declaration
  var array1 = [10, 20, 30, 40, 50];
  var array2 = [60, 70, 80, 90, 100];

  //Implementation of merge function
  $.merge(array1, array2);
  console.log("Array1", array1);

  //Each function on array
  $.each(array1, function (index, value) {
    console.log("array1 [ " + index + " ] = " + value);
  });
});

export default function showQuery() {
  $("#content").remove();
  $(".container").append("<div id='content'></div>");

  $("#content").append(`
  <div id='heading'></div>
  <div class='row'>
    <div id='selectBox'></div>
  </div>`);

  $("#heading").dxButton({
    text: "Query",
    onClick: () => {
      console.log(processedArray);
    },
  });

  var dataObjects = [
    { name: "Amelia", birthYear: 1991, gender: "female" },
    { name: "Benjamin", birthYear: 1983, gender: "male" },
    { name: "Daniela", birthYear: 1987, gender: "female" },
    { name: "Lee", birthYear: 1981, gender: "male" },
  ];

  var processedArray = DevExpress.data
    .query(dataObjects)
    .filter(["gender", "=", "female"])
    .sortBy("birthYear")
    .select("name", "birthYear")
    .toArray();

  var step = function (total, itemData) {
    return total + itemData;
  };

  var finalize = function (total) {
    return total / 1000;
  };

  DevExpress.data
    .query([10, 20, 30, 40, 50])
    .aggregate(0, step, finalize)
    .done(function (result) {
      console.log("aggregate (0, step, finalize)", result); // outputs 0.15
    });

  var step = function (total, itemData) {
    return total + itemData;
  };

  DevExpress.data
    .query([10, 20, 30, 40, 50])
    .aggregate(step)
    .done(function (result) {
      console.log("aggregate (step)", result); // outputs 150
    });

  var priceList = [
    {
      id: 1,
      price: 1250,
    },
    {
      id: 2,
      price: 1050,
    },
    {
      id: 3,
      price: 250,
    },
  ];

  DevExpress.data
    .query(priceList)
    .select("price")
    .avg()
    .done(function (result) {
      console.log("avg", result); // outputs the average price
    });

  DevExpress.data
    .query([10, 20, 30, 40, 50])
    .count()
    .done(function (result) {
      console.log(result); // outputs 5
    });

  // DevExpress.data
  //   .query("http://mydomain.com/MyDataService", queryOptions)
  //   .enumerate()
  //   .done(function (result) {
  //     console.log("enumerate", result); // outputs the obtained array
  //   });

  var dataObjects = [
    { id: 1, name: "Alice", price: 300 },
    { id: 2, name: "Bob", price: 600 },
    { id: 3, name: "Charlie", price: 400 },
    { id: 4, name: "David", price: 200 },
  ];

  var filteredData = DevExpress.data
    .query(dataObjects)
    .filter(["price", "<", 500])
    .toArray();

  console.log("filter", filteredData);

  var dataObjects = [
    { name: "Alice", gender: "female" },
    { name: "Bob", gender: "male" },
    { name: "Charlie", gender: "male" },
    { name: "David", gender: "male" },
  ];

  var groupedData = DevExpress.data
    .query(dataObjects)
    .groupBy("gender")
    .toArray();

  console.log("groupedData", groupedData);

  var dataObjects = [
    { id: 1, price: 300 },
    { id: 2, price: 600 },
    { id: 3, price: 400 },
    { id: 4, price: 200 },
  ];

  DevExpress.data
    .query(dataObjects)
    .select("price")
    .max()
    .done(function (result) {
      console.log("max", result); // Output: 600 (maximum price)
    });

  DevExpress.data
    .query(dataObjects)
    .select("price")
    .min()
    .done(function (result) {
      console.log("min", result); // Output: 200 (minimum price)
    });

  var dataObjects = [
    { name: "Alice", birthYear: 1990, gender: "female" },
    { name: "Bob", birthYear: 1985, gender: "male" },
    { name: "Charlie", birthYear: 1988, gender: "male" },
  ];

  var selectedData = DevExpress.data
    .query(dataObjects)
    .select("name", "birthYear")
    .toArray();

  console.log("select", selectedData);

  var subset = DevExpress.data.query(dataObjects).slice(1, 2).toArray();

  console.log("slice", subset);

  var sortedData = DevExpress.data
    .query(dataObjects)
    .sortBy("birthYear")
    .toArray();

  console.log("sortBy", sortedData);

  var dataObjects = [
    { id: 1, price: 300 },
    { id: 2, price: 600 },
    { id: 3, price: 400 },
  ];

  DevExpress.data
    .query(dataObjects)
    .select("price")
    .sum()
    .done(function (result) {
      console.log(result);
    });

    
}

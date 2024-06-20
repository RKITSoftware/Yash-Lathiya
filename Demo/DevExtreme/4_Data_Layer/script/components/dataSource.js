export default function showDataSourceDemo() {
  $("#content").remove();
  $(".container").append("<div id='content'></div>");

  $("#content").append(
    `<div id='heading'></div>
    <div class='row'>
      <div id='cancel'></div>
    </div>
    <div class='row'>
      <div id='dispose'></div>
    </div>
    <div class='row'>
      <div id='filter'></div>
    </div>
    <div class='row'>
      <div id='group'></div>
    </div>
    <div class='row'>
      <div id='isLastPage'></div>
    </div>
    <div class='row'>
      <div id='isLoading'></div>
    </div>
    <div class='row'>
      <div id='items'></div>
    </div>
    <div class='row'>
      <div id='key'></div>
    </div>
    <div class='row'>
      <div id='load'></div>
    </div>
    <div class='row'>
      <div id='loaOptions'></div>
    </div>
    <div class='row'>
      <div id='pageIndex'></div>
    </div>
    <div class='row'>
      <div id='pageSize'></div>
    </div>
    <div class='row'>
      <div id='paginate'></div>
    </div>
    <div class='row'>
      <div id='reload'></div>
    </div>
    <div class='row'>
      <div id='searchValue'></div>
    </div>
    <div class='row'>
      <div id='sort'></div>
    </div>
    <div class='row'>
      <div id='totalCount'></div>
    </div>`
  );

  var productList = [
    {
      ProductID: 1,
      ProductName: "Chai",
      SupplierID: 1,
      CategoryID: 1,
      QuantityPerUnit: "10 boxes x 20 bags",
      UnitPrice: 18,
      UnitsInStock: 39,
      UnitsOnOrder: 0,
      ReorderLevel: 10,
      Discontinued: false,
    },
    {
      ProductID: 2,
      ProductName: "Chang",
      SupplierID: 1,
      CategoryID: 1,
      QuantityPerUnit: "24 - 12 oz bottles",
      UnitPrice: 19,
      UnitsInStock: 17,
      UnitsOnOrder: 40,
      ReorderLevel: 25,
      Discontinued: false,
    },
    {
      ProductID: 3,
      ProductName: "Aniseed Syrup",
      SupplierID: 1,
      CategoryID: 2,
      QuantityPerUnit: "12 - 550 ml bottles",
      UnitPrice: 10,
      UnitsInStock: 13,
      UnitsOnOrder: 70,
      ReorderLevel: 25,
      Discontinued: false,
    },
    {
      ProductID: 4,
      ProductName: "Chef Anton's Cajun Seasoning",
      SupplierID: 2,
      CategoryID: 2,
      QuantityPerUnit: "48 - 6 oz jars",
      UnitPrice: 22,
      UnitsInStock: 53,
      UnitsOnOrder: 0,
      ReorderLevel: 0,
      Discontinued: false,
    },
    {
      ProductID: 5,
      ProductName: "Chef Anton's Gumbo Mix",
      SupplierID: 2,
      CategoryID: 2,
      QuantityPerUnit: "36 boxes",
      UnitPrice: 21.35,
      UnitsInStock: 0,
      UnitsOnOrder: 0,
      ReorderLevel: 0,
      Discontinued: true,
    },
    {
      ProductID: 6,
      ProductName: "Grandma's Boysenberry Spread",
      SupplierID: 3,
      CategoryID: 2,
      QuantityPerUnit: "12 - 8 oz jars",
      UnitPrice: 25,
      UnitsInStock: 120,
      UnitsOnOrder: 0,
      ReorderLevel: 25,
      Discontinued: false,
    },
    {
      ProductID: 7,
      ProductName: "Uncle Bob's Organic Dried Pears",
      SupplierID: 3,
      CategoryID: 7,
      QuantityPerUnit: "12 - 1 lb pkgs.",
      UnitPrice: 30,
      UnitsInStock: 15,
      UnitsOnOrder: 0,
      ReorderLevel: 10,
      Discontinued: false,
    },
    {
      ProductID: 8,
      ProductName: "Northwoods Cranberry Sauce",
      SupplierID: 3,
      CategoryID: 2,
      QuantityPerUnit: "12 - 12 oz jars",
      UnitPrice: 40,
      UnitsInStock: 6,
      UnitsOnOrder: 0,
      ReorderLevel: 0,
      Discontinued: false,
    },
    {
      ProductID: 9,
      ProductName: "Mishi Kobe Niku",
      SupplierID: 4,
      CategoryID: 6,
      QuantityPerUnit: "18 - 500 g pkgs.",
      UnitPrice: 97,
      UnitsInStock: 29,
      UnitsOnOrder: 0,
      ReorderLevel: 0,
      Discontinued: true,
    },
    {
      ProductID: 10,
      ProductName: "Ikura",
      SupplierID: 4,
      CategoryID: 8,
      QuantityPerUnit: "12 - 200 ml jars",
      UnitPrice: 31,
      UnitsInStock: 31,
      UnitsOnOrder: 0,
      ReorderLevel: 0,
      Discontinued: false,
    },
    {
      ProductID: 11,
      ProductName: "Queso Cabrales",
      SupplierID: 5,
      CategoryID: 4,
      QuantityPerUnit: "1 kg pkg.",
      UnitPrice: 21,
      UnitsInStock: 22,
      UnitsOnOrder: 30,
      ReorderLevel: 30,
      Discontinued: false,
    },
    {
      ProductID: 12,
      ProductName: "Queso Manchego La Pastora",
      SupplierID: 5,
      CategoryID: 4,
      QuantityPerUnit: "10 - 500 g pkgs.",
      UnitPrice: 38,
      UnitsInStock: 86,
      UnitsOnOrder: 0,
      ReorderLevel: 0,
      Discontinued: false,
    },
    {
      ProductID: 13,
      ProductName: "Konbu",
      SupplierID: 6,
      CategoryID: 8,
      QuantityPerUnit: "2 kg box",
      UnitPrice: 6,
      UnitsInStock: 24,
      UnitsOnOrder: 0,
      ReorderLevel: 5,
      Discontinued: false,
    },
    {
      ProductID: 14,
      ProductName: "Tofu",
      SupplierID: 6,
      CategoryID: 7,
      QuantityPerUnit: "40 - 100 g pkgs.",
      UnitPrice: 23.25,
      UnitsInStock: 35,
      UnitsOnOrder: 0,
      ReorderLevel: 0,
      Discontinued: false,
    },
    {
      ProductID: 15,
      ProductName: "Genen Shouyu",
      SupplierID: 6,
      CategoryID: 2,
      QuantityPerUnit: "24 - 250 ml bottles",
      UnitPrice: 15.5,
      UnitsInStock: 39,
      UnitsOnOrder: 0,
      ReorderLevel: 5,
      Discontinued: false,
    },
    {
      ProductID: 16,
      ProductName: "Pavlova",
      SupplierID: 7,
      CategoryID: 3,
      QuantityPerUnit: "32 - 500 g boxes",
      UnitPrice: 17.45,
      UnitsInStock: 29,
      UnitsOnOrder: 0,
      ReorderLevel: 10,
      Discontinued: false,
    },
    {
      ProductID: 17,
      ProductName: "Alice Mutton",
      SupplierID: 7,
      CategoryID: 6,
      QuantityPerUnit: "20 - 1 kg tins",
      UnitPrice: 39,
      UnitsInStock: 0,
      UnitsOnOrder: 0,
      ReorderLevel: 0,
      Discontinued: true,
    },
    {
      ProductID: 18,
      ProductName: "Carnarvon Tigers",
      SupplierID: 7,
      CategoryID: 8,
      QuantityPerUnit: "16 kg pkg.",
      UnitPrice: 62.5,
      UnitsInStock: 42,
      UnitsOnOrder: 0,
      ReorderLevel: 0,
      Discontinued: false,
    },
    {
      ProductID: 19,
      ProductName: "Teatime Chocolate Biscuits",
      SupplierID: 8,
      CategoryID: 3,
      QuantityPerUnit: "10 boxes x 12 pieces",
      UnitPrice: 9.2,
      UnitsInStock: 25,
      UnitsOnOrder: 0,
      ReorderLevel: 5,
      Discontinued: false,
    },
    {
      ProductID: 20,
      ProductName: "Sir Rodney's Marmalade",
      SupplierID: 8,
      CategoryID: 3,
      QuantityPerUnit: "30 gift boxes",
      UnitPrice: 81,
      UnitsInStock: 40,
      UnitsOnOrder: 0,
      ReorderLevel: 0,
      Discontinued: false,
    },
  ];

  var dataSource = new DevExpress.data.DataSource({
    // store: new DevExpress{
    //   key: "ProductID",
    //   data: productList,
    //   name: "myLocalStore",
    //   type: "local",
    // },

    store: productList,

    // binary filter
    // filter: ["CategoryID", "=", 3],

    // unary filter
    // filter: ["!", ["CategoryID", "=", 3]],

    // complex filter
    // filter: [
    //   ["SupplierID", "=", 8],
    //   "and",
    //   [["CategoryID", "<", 3], "or", ["CategoryID", ">", 8]],
    // ],

    group1: {
      selector: "ProductName",
      desc: true,
    },

    // pageSize: 5,

    // paginate: true,

    // requireTotalCount: true,

    // Specifies whether to reapply sorting, filtering, grouping, and other data processing operations after receiving a push.
    // reshapeOnPush: true, // default -> false

    searchExpr1: ["ProductID", "ProductName"],

    // accepted -> = <> > < <= >= startswith endswith contains notcontains
    searchOperation1: "contains", // default -> contains,

    // select -> specifies the fields to select from data objects

    sort1: [
      "Position",
      {
        selector: "ProductID",
        desc: true,
      },
    ],

    // select: ["ProductID", "ProductName", "UnitPrice", "UnitsInStock"],

    map1: (dataItem) => {
      return {
        currentStockValue: dataItem.UnitsInStock * dataItem.UnitPrice,
      };
    },

    onChanged: () => {
      console.log("*onChanged");
    },

    onLoadError: (err) => {
      console.log("*onLoadError", err.message);
    },

    onLoadingChanged: (isLoading) => {
      console.log("isLoading", isLoading);
    },

    postProcess: (data) => {
      console.log("postProcess", data);
    },
  });

  $("#heading").dxButton({
    text: "Data Source",
    onClick: () => {
      console.log(dataSource);
    },
  });

  // $("#cancel").dxButton({
  //   text: "Cancel",
  //   onClick: () => {
  //     var loadPromise = dataSource.load();
  //     loadPromise.done(function (result) {
  //       // ...
  //     });

  //     dataSource.cancel(loadPromise.operationId);
  //   },
  // });

  $("#dispose").dxButton({
    text: "Dispose",
    onClick: () => {
      dataSource.dispose();
    },
  });

  $("#filter").dxTextBox({
    placeholder: "Filter by Product Name",
    onValueChanged: (e) => {
      dataSource.filter(["ProductName", "contains", e.value]);
    },
  });

  $("#group").dxButton({
    text: "Group",
    onClick: () => {
      dataSource.group("CategoryID");
    },
  });

  $("#isLastPage").dxButton({
    text: "Is Last Page",
    onClick: () => {
      console.log(dataSource.isLastPage());
    },
  });

  $("#isLoading").dxButton({
    text: "Is Loading",
    onClick: () => {
      console.log(dataSource.isLoading());
    },
  });

  $("#items").dxButton({
    text: "Items",
    onClick: () => {
      // Check if DataSource is loading
      if (dataSource.isLoading) {
        console.log("Data is still loading...");
      }
      // Get the items asynchronously
      dataSource
        .load()
        .done((data) => {
          console.log("****", data);
          console.log(dataSource.items());
        })
        .fail((err) => {
          console.error("Error loading data:", err.message);
        });
    },
  });

  $("#key").dxButton({
    text: "Key",
    onClick: () => {
      console.log(dataSource.key());
    },
  });

  $("#load").dxButton({
    text: "Load",
    onClick: () => {
      console.log("%%");
      dataSource
        .load()
        .done((data) => {
          console.log("Data loaded successfully:", data);
        })
        .fail((error) => {
          console.error("Error loading data:", error);
        });
    },
  });

  $("#loaOptions").dxButton({
    text: "Load Options",
    onClick: () => {
      console.log(dataSource.loadOptions());
    },
  });

  $("#pageIndex").dxButton({
    text: "Page Index",
    onClick: () => {
      console.log(dataSource.pageIndex());
    },
  });

  $("#pageSize").dxButton({
    text: "Page Size",
    onClick: () => {
      console.log(dataSource.pageSize());
    },
  });

  $("#paginate").dxButton({
    text: "Paginate",
    onClick: () => {
      dataSource.paginate(!dataSource.paginate());
    },
  });

  $("#reload").dxButton({
    text: "Reload",
    onClick: () => {
      dataSource.reload();
    },
  });

  $("#searchValue").dxTextBox({
    placeholder: "Search by Product ID or Name",
    onValueChanged: (e) => {
      dataSource.searchValue(e.value);
    },
  });

  $("#sort").dxButton({
    text: "Sort",
    onClick: () => {
      dataSource.sort("ProductName");
    },
  });

  $("#totalCount").dxButton({
    text: "Total Count",
    onClick: () => {
      console.log(dataSource.totalCount());
    },
  });
}

# DevExtreme CustomStore Implementation

- Implement code snippets to

```
https://js.devexpress.com/jQuery/Demos/WidgetsGallery/Demo/DataGrid/CustomDataSource/MaterialBlueLight/
```

# remoteOpeartion : false

- All operation will be performed by the client side.

```javascript
$(() => {
  function isNotEmpty(value) {
    return value !== undefined && value !== null && value !== '';
  }
  
  const store = new DevExpress.data.CustomStore({
    key: 'OrderNumber',
    loadMode: "row",
    load(loadOptions) {
      return $.get("https://js.devexpress.com/Demos/WidgetsGalleryDataService/api/orders");
   	}
  });

  $('#gridContainer').dxDataGrid({
    dataSource: store,
    showBorders: true,
    remoteOperations: false,
    paging: {
      pageSize: 12,
    },
    pager: {
      showPageSizeSelector: true,
      allowedPageSizes: [8, 12, 20],
    },
    columns: [{
      dataField: 'OrderNumber',
      dataType: 'number',
    }, {
      dataField: 'OrderDate',
      dataType: 'date',
    }, {
      dataField: 'StoreCity',
      dataType: 'string',
    }, {
      dataField: 'StoreState',
      dataType: 'string',
    }, {
      dataField: 'Employee',
      dataType: 'string',
    }, {
      dataField: 'SaleAmount',
      dataType: 'number',
      format: 'currency',
    }],
  }).dxDataGrid('instance');
});
```

# remoteOperation : true

- All operations will be performed by the server side.
- Client will request by sending soadOptions.

```javascript
$(() => {
  function isNotEmpty(value) {
    return value !== undefined && value !== null && value !== '';
  }
  const store = new DevExpress.data.CustomStore({
    key: 'OrderNumber',
    loadMode : "processed",
    load(loadOptions) {
      const deferred = $.Deferred();

      const paramNames = [
        'skip', 'take', 'requireTotalCount', 'requireGroupCount',
        'sort', 'filter', 'totalSummary', 'group', 'groupSummary',
      ];

      const args = {};

      paramNames
        .filter((paramName) => isNotEmpty(loadOptions[paramName]))
        .forEach((paramName) => { args[paramName] = JSON.stringify(loadOptions[paramName]); });

      $.ajax({
        url: 'https://js.devexpress.com/Demos/WidgetsGalleryDataService/api/orders',
        dataType: 'json',
        data: args,
        success(result) {
          deferred.resolve(result.data, {
            totalCount: result.totalCount,
            summary: result.summary,
            groupCount: result.groupCount,
          });
        },
        error() {
          deferred.reject('Data Loading Error');
        },
        timeout: 5000,
      });

      return deferred.promise();
    },
  });

  $('#gridContainer').dxDataGrid({
    dataSource: store,
    showBorders: true,
    remoteOperations: true,
    paging: {
      pageSize: 12,
    },
    pager: {
      showPageSizeSelector: true,
      allowedPageSizes: [8, 12, 20],
    },
    // sorting
    sorting: {
      mode : "multiple"
    },
    // filtering
    headerFilter : {
      visible : true
    },
    // group
    group : ["StoreState", "StoreState"],
    grouping : {
      autoExpandAll : false
    },
    // summary
    summary : {
      totalItems : [
        {
          column: "SaleAmount",
          summaryType : "sum"
        }
      ],
      groupItems : [
        {
          column : "SaleAmount",
          summaryType : "sum",
          showInGroupFooter : true
        }
      ]
    },
    columns: [{
      dataField: 'OrderNumber',
      dataType: 'number',
    }, {
      dataField: 'OrderDate',
      dataType: 'date',
    }, {
      dataField: 'StoreCity',
      dataType: 'string',
      groupIndex : 1
    }, {
      dataField: 'StoreState',
      dataType: 'string',
      groupIndex : 0
    }, {
      dataField: 'Employee',
      dataType: 'string',
    }, {
      dataField: 'SaleAmount',
      dataType: 'number',
      format: 'currency',
      sortOrder : "asc"
    }],
  }).dxDataGrid('instance');
});
```

- Request Payload  
![alt text](Demo/DevExtreme/4_Data_Layer/Images/payload.PNG?raw=true)

- Response Preview
![alt text](Demo/DevExtreme/4_Data_Layer/Images/responsePreview.PNG?raw=true)




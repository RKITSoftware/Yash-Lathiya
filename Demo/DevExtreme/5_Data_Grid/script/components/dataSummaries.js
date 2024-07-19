export default function showDataSummaries() {
    $("#content").remove();
    $(".container").append("<div id='content'><h1>Total Summary</h1><div id='totalSummaries'></div><h1>Group Summary</h1><div id='groupSummaries'></div><h1>Custom Summary</h1><div id='customSummaries'></div></div>");
  
    $.ajax({
      url : "../script/data/orders.json",
      method : "GET",
      dataType : "json",
      success : (orders) => {
        let datagrid = $("#totalSummaries").dxDataGrid({
          dataSource : orders,
          keyExpr : "ID",
          showBorders : true,
          selection: {
            mode: 'single',
          },
          paging : {
            pageSize : 10
          },
          columns: [{
            dataField: 'OrderNumber',
            width: 130,
            caption: 'Invoice Number',
          }, {
            dataField: 'OrderDate',
            dataType: 'date',
          },
          'Employee', {
            caption: 'City',
            dataField: 'CustomerStoreCity',
          }, {
            caption: 'State',
            dataField: 'CustomerStoreState',
          }, {
            dataField: 'SaleAmount',
            alignment: 'right',
            format: 'currency',
            width: 160,
          },
          ],
          summary: {
             // total summaries 
            totalItems: [{
              column: 'OrderNumber',
              summaryType: 'count',
            }, {
              column: 'OrderDate',
              summaryType: 'min',
              customizeText(itemInfo) {
                return `First: ${DevExpress.localization.formatDate(itemInfo.value, 'MMM dd, yyyy')}`;
              },
            }, {
              column: 'SaleAmount',
              summaryType: 'sum',
              valueFormat: 'currency',
            }],
          },
        })
          .dxDataGrid("instance");
      },
      error : () => {
        console.log("error to fetch employees from ajax request")
      }
    })

    $.ajax({
      url : "../script/data/orders.json",
      method : "GET",
      dataType : "json",
      success : (orders) => {
        $("#groupSummaries").dxDataGrid({
          dataSource : orders,
          keyExpr : "ID",
          showBorders : true,
          paging : {
            pageSize : 10
          },
          columns: [{
            dataField: 'OrderNumber',
            width: 130,
            caption: 'Invoice Number',
          }, {
            dataField: 'OrderDate',
            dataType: 'date',
          }, {
            dataField: 'Employee',
            groupIndex: 0,
          }, {
            caption: 'City',
            dataField: 'CustomerStoreCity',
          }, {
            caption: 'State',
            dataField: 'CustomerStoreState',
          }, {
            dataField: 'SaleAmount',
            width: 160,
            alignment: 'right',
            format: 'currency',
          }, {
            dataField: 'TotalAmount',
            width: 160,
            alignment: 'right',
            format: 'currency',
          },
          ],
          sortByGroupSummaryInfo: [{
            summaryItem: 'count',
          }],
          summary: {
            groupItems: [{
              column: 'OrderNumber',
              summaryType: 'count',
              displayFormat: '{0} orders',
            }, {
              column: 'SaleAmount',
              summaryType: 'max',
              valueFormat: 'currency',
              showInGroupFooter: false,
              alignByColumn: true,
            }, {
              column: 'TotalAmount',
              summaryType: 'max',
              valueFormat: 'currency',
              showInGroupFooter: false,
              alignByColumn: true,
            }, {
              column: 'TotalAmount',
              summaryType: 'sum',
              valueFormat: 'currency',
              displayFormat: 'Total: {0}',
              showInGroupFooter: true,
            }],
          },
        })
      },
      error : () => {
        console.log("error to fetch employees from ajax request")
      }
    })

    $.ajax({
      url : "../script/data/orders.json",
      method : "GET",
      dataType : "json",
      success : (employees) => {
        let datagrid = $("#customSummaries").dxDataGrid({
          dataSource : employees,
          keyExpr : "ID",
          showBorders : true,
          paging : {
            pageSize : 10
          },
          selection: {
            mode: 'multiple',
          },
          columns: [{
            dataField: 'OrderNumber',
            width: 130,
            caption: 'Invoice Number',
          }, {
            dataField: 'OrderDate',
            dataType: 'date',
          },
          'Employee', {
            caption: 'City',
            dataField: 'CustomerStoreCity',
          }, {
            caption: 'State',
            dataField: 'CustomerStoreState',
          }, {
            dataField: 'SaleAmount',
            alignment: 'right',
            format: 'currency',
            width: 160,
          },
          ],
          selectedRowKeys: [1, 4, 7],
          onSelectionChanged(e) {
            e.component.refresh(true);
          },
          summary: {
            totalItems: [{
              name: 'SelectedRowsSummary',
              showInColumn: 'SaleAmount',
              displayFormat: 'Sum: {0}',
              valueFormat: 'currency',
              summaryType: 'custom',
            },
            ],
            calculateCustomSummary(options) {
              if (options.name === 'SelectedRowsSummary') {
                if (options.summaryProcess === 'start') {
                  options.totalValue = 0;
                }
                if (options.summaryProcess === 'calculate') {
                  if (options.component.isRowSelected(options.value.ID)) {
                    options.totalValue += options.value.SaleAmount;
                  }
                }
              }
            },
          },
        })
          .dxDataGrid("instance");
      },
      error : () => {
        console.log("error to fetch employees from ajax request")
      }
    })
  }
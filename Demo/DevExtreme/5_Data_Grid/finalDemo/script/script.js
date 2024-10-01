$(document).ready(function () {
    
    $.ajax({
        url: "../assets/orders.json",
        method: "GET",
        success: function(res, status, xhr) {
            orders = res

            // Function to get index by key
            function getIndexByKey(key) {
                for (var i = 0; i < orders.length; i++) {
                    if (orders[i]["Order ID"] === key) {
                        return i;
                    }
                }
                return -1;
            }

            // custom store
            var ordersStore = new DevExpress.data.CustomStore({
                key : "Order ID",
                load : () => {
                    return orders
                },
                insert : (values) => {
                    console.log(values)
                    values["Order ID"] = orders.length + 1
                    orders.push(values)
                    return values
                },
                update : (key, values) => {
                    var index = getIndexByKey(key)
                    if(index >=0) {
                        $.extend(true, orders[index], values) // true --> new values will overwrite previous values
                    }
                    return values
                },
                remove : (key) => {
                    var index = getIndexByKey(key)
                    if(index >= 0){
                        orders.splice(index, 1) // remove one element from STARTING INDEX index.
                    }
                }
            })

            $("#content").dxDataGrid({
                dataSource : {
                    store :ordersStore,
                    group : ["Product", "catégorie"]
                },
                showBorders : true,
                height : 600,
                
                // remote operations
                // loadMode : "processed",
                // remoteOperations:{
                //     summary : true,
                // },

                // paging
                paging : {
                    pageSize : 10
                },
                pager : {
                    visible : true,
                    showInfo : true,
                    showNavigationButtons : true,
                    displayMode : "full"
                },
                
                // scrolling
                scrolling : {
                    mode : "virtual",
                    useNative : false,
                    scrollByContent : false,
                    scrollByThumb : true,
                    showScrollbar : "onHover"
                },
                
                // editing
                editing : {
                    allowUpdating : true,
                    allowAdding : true,
                    allowDeleting : true,
                    mode : "popup",
                    popup : {
                        height : 400,
                        width : 800
                    },
                    useIcons : true
                },

                // grouping
                grouping : {
                    autoExpandAll : true
                },

                // filtering
                filterRow : {
                    visible : true,
                },
                headerFilter : {
                    visible : true
                },
                searchPanel : {
                    visible : true
                },
                filterPanel : {
                    visible : true
                },
                filterSyncEnabled : true, // synchronizes all filter operation performed by filter-panel, filter-header etc.

                // sorting
                sorting : {
                    mode : "multiple"
                },

                // selection
                selection : {
                    mode : "multiple",
                    selectAllMode: "all",
                    showCheckBoxesMode : "always"
                },
                onSelectionChanged : (selectedItems) => { 
                    // console.log(selectedItems)
                    let customerIds = []
                    selectedItems.selectedRowsData.forEach(element => {
                        // console.log(element.CustomerID)
                        if(!customerIds.includes(element.CustomerID)){
                            customerIds.push(element.CustomerID)
                        }
                    })
                    // console.log(customerIds)
                    let customers = []
                    $.get(
                        "../assets/customers.json",
                        res => {
                            // console.log(res)
                            res.forEach(customer => {
                                console.log(customer.CustomerID)
                                if(customerIds.includes(customer.CustomerID)){
                                    console.log("*")
                                    customers.push(customer)
                                }
                            })
                            
                            console.log(customers)

                            $("#footer").dxDataGrid({
                                dataSource : customers,
                                columns : [
                                    {
                                        dataField : "Photo",
                                        cellTemplate :  (element, itemData) => {
                                            $("<img>")
                                                .attr("src", itemData.value)
                                                .css({width : 30, height : 30})
                                                .appendTo(element)
                                        },
                                        width : 50
                                    },
                                    "CustomerID",
                                    "FullName",
                                    "Address",
                                    "City",
                                    "Region",
                                    "PostalCode",
                                    "Country",
                                    "HomePhone",
                                    "Extension",
                                ]
                            })
                        }
                    )
                    
                },

                // state persistance
                stateStoring : {
                    enabled : true,
                    type : "localStorage",
                    storageKey : "dxOrderDataGrid"
                },

                // appearance
                showColumnLines : true,
                showRowLines: true,
                rowAlternationEnabled : false,
                showBorders : true,

                // column customization
                allowColumnResizing : true,
                allowColumnReordering : true,
                columnAutoWidth : true,
                columnChooser : {
                    enabled : true
                },
                customizeColumns : (columns) => {
                    columns[0].width = 100
                },
                columns : [
                    {
                        dataField : "Order ID",
                        allowEditing : false,
                        sortOrder : "asc"
                    },
                    {
                        dataField : "Order Date",
                        caption : "Order Time",
                        calculateCellValue(data){
                            // console.log(data)
                            return data["Order Date"]
                        },
                    },
                    "CustomerID",
                    {
                        dataField : "Product",
                        groupIndex : 1
                    },
                    {
                        dataField : "catégorie",
                        caption : "Category",
                        groupIndex : 0
                    },
                    "Quantity Ordered",
                    {
                        caption : "Order Economics",
                        columns : [
                            {
                                dataField : "Price Each",
                                caption : "Price",
                                format : "currency"
                            },
                            {
                                dataField : "Cost price",
                                caption : "Cost" ,
                                format : "currency"
                            },
                            "turnover",
                            "margin"
                        ]
                    }
                ],

                // masterDetail
                masterDetail : {
                    enabled :true,
                    template(container, option){
                        const currentOrderData = option.data
                        $("<div>")
                            .text(`Purchase Address :  ${currentOrderData["Purchase Address"]}`)
                            .appendTo(container)
                    }
                },

                // export
                export : {
                    enabled :true,
                    allowExportSelectedData : true
                },
                onExporting(e) {
                    const workbook = new ExcelJS.Workbook();
                    const worksheet = workbook.addWorksheet('Employees');

                    DevExpress.excelExporter.exportDataGrid({
                        component: e.component,
                        worksheet,
                        autoFilterEnabled: true,
                    })
                    .then(() => {
                        workbook.xlsx.writeBuffer().then((buffer) => {
                        saveAs(new Blob([buffer], { type: 'application/octet-stream' }), 'Orders.xlsx')});
                    });
                },

                // adaptibility
                columnHidingEnabled : true,

                // data summary
                summary : {
                    groupItems : [
                        {
                            column: "Price Each",
                            summaryType: "sum",
                            valueFormat: "currency",
                            displayFormat: "Total Sell: {0}",
                            showInGroupFooter: true,
                        }
                    ]
                }
            })

        },
        error: function(xhr, status, error) {
            console.log(xhr, status, error)
        }
    }); 
    
})
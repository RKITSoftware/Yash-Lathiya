window.jsPDF = window.jspdf.jsPDF;
export default function showExport() {
    $("#content").remove();
    $(".container").append("<div id='content'></div>");
  
    $.ajax({
      url : "../script/data/employees.json",
      method : "GET",
      dataType : "json",
      success : (employees) => {
        let datagrid = $("#content").dxDataGrid({
          dataSource : employees,
          keyExpr : "EmployeeID",
          showBorders : true,
          allowColumnReordering: true,
          paging : {
            pageSize : 10
          },
          selection : {
            mode : "multiple"
          },
          columns : [
            {
              dataField : 'EmployeeID',
              allowEditing : false,
              sortOrder: 'asc',
            },
            {
              dataField : "FullName",
            },
            {
              dataField : "Position"
            },
            {
              dataField : "TitleOfCourtesy",
            },
            {
              dataField : "BirthDate"
            },
            {
              dataField : "Photo",
            },
            {
              dataField : "Country",
            }
          ],
          export : {
            enabled : true,

            // formats is not supported in version 21.1
            // formats : ['.pdf'],

            allowExportSelectedData : true,
          },
          onExporting(e) {
            console.log(e)

            // pdf export for higher versions of dev extreme 

            // const doc = new jsPDF();
            // console.log(doc)
            // DevExpress.pdfExporter.exportDataGrid({
            //     jsPDFDocument: doc,
            //     component: e.component,
            //     indent: 5,
            //   }).then(() => {
            //     doc.save('Companies.pdf');
            //   });

            const workbook = new ExcelJS.Workbook();
            const worksheet = workbook.addWorksheet('Employees');

            DevExpress.excelExporter.exportDataGrid({
                component: e.component,
                worksheet,
                autoFilterEnabled: true,
            })
                .then(() => {
                    workbook.xlsx.writeBuffer().then((buffer) => {
                    saveAs(new Blob([buffer], { type: 'application/octet-stream' }), 'Employees.xlsx');
                });
      });
          }
        })
          .dxDataGrid("instance");
      },
      error : () => {
        console.log("error to fetch employees from ajax request")
      }
    })
  }
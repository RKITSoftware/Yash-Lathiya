export default function showEditing() {
    $("#content").remove();
    $(".container").append("<div id='content'></div>");
  
    var popup = $("#popupContainer").dxPopup({
      deferRendering: false, // Render the popup immediately
      contentTemplate: function() {
        return $('<div>').append(
            $("<img>").attr("src", "")
        );
      },
      width : 500,
      height : 500
    })
      .dxPopup("instance");

    $.ajax({
      url : "../script/data/employees.json",
      method : "GET",
      dataType : "json",
      success : (employees) => {
        $("#content").dxDataGrid({
          dataSource : employees,
          keyExpr : "EmployeeID",
          editing : {
            allowUpdating : true,
            allowAdding : true,
            allowDeleting : true,
            mode : "row", // accepts batch, cell, form, popup
            popup : {
              height : 500,
              width : 500
            },
          },
          onCellClick : (e) => {
            if(e.columnIndex == 5){
              console.log(e)
              var imageUrl = e.value; // Assuming e.value contains the URL of the photo
                popup.option("contentTemplate", function() {
                    return $('<div>').append(
                        $("<img>").attr("src", imageUrl)
                    );
                });
              popup.show();
            }
          },
          onRowUpdating: function(e) {
            console.log("Row updating", e);
          },
          onRowInserting: function(e) {
            console.log("Row inserting", e);
          },
          onRowRemoving: function(e) {
            console.log("Row removing", e);
          },
          allowColumnResizing : true,
          columns : [
            {
              dataField : 'EmployeeID',
              allowEditing : false
            },
            {
              dataField : "FullName",
              validationRules : [
                {
                  type : "required",
                  message : "Full Name is required."
                },
                {
                  type : "stringLength",
                  min : 3,
                  message : "Full Name should be minimum of 3 chars."
                }
              ]
            },
            {
              dataField : "Position"
            },
            {
              dataField : "TitleOfCourtesy",
              lookup : {
                dataSource : ["Mr.", "Dr.", "Ms", "Mrs."]
              }
            },
            {
              dataField : "BirthDate"
            },
            {
              dataField : "Photo",
              cellTemplate : (element, itemData) => {
                // console.log(itemData, element)
                $("<img>")
                .attr("src", itemData.value) // Assuming options.value is the URL of the photo
                .css({ width: 30, height: 30 }) // Adjust size as needed
                .appendTo(element);
              },
            },
            {
              dataField : "ReportsTo"
            }
          ]
        });
      },
      error : () => {
        console.log("error to fetch employees from ajax request")
      }
    })
    
  }
  
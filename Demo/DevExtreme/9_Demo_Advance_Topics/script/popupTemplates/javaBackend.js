import saveTreeNodesInSessionStorage from "./../popupTemplates/saveTreeNodesInSessionStorage.js";
import getConfiguredProjectsFromSessionStorage from "../sessionstorage/getConfiguredProjectsFromSessionStorage.js";

export default function popupTemplateForJavaBackend(container) {
    $(container).append(`
        <div id="template" style="display: flex; flex-direction: column; height: 100%;">
            <div id='treeview-container' style="flex: 1; overflow-y: auto;"></div>
            <div id='configureBtn' style="margin: 10px; text-align: center;"></div>
        </div>`
    );


    $.get("../assets/data/projectConfigurations/javaBackend.json", configurations => {
        console.log(configurations)
        const treeView = 
            $("#treeview-container").dxTreeView({
                dataSource: configurations,
                idField: "id",
                displayField: "text",
                selectionMode : "multiple", // Allows multiple selections
                showCheckBoxesMode: "normal", // Shows checkboxes for items
                expandNodesRecursive: true, // Automatically expand nodes
                // Optionally add selection handling or other configurations
                // onItemSelectionChanged: function(e) { /* handle selection */ }
            })
            .dxTreeView("instance");
        
        treeView.expandAll()

        let btnIndicator
        const configureBtn = 
            $("#configureBtn")
            .dxButton({
                text : "Configure",
                width: 200, 
                height: 40,
                type: "success",
                template(data, container){
                    $(`<div id='btnIndicator'></div>
                       <span class='dx-button-text'>${data.text}</span>'`)
                        .appendTo(container)
                    
                    btnIndicator = container
                                    .find("#btnIndicator")
                                    .dxLoadIndicator({
                                        visible : false,
                                        width : 25,
                                        height : 25
                                    })
                                    .dxLoadIndicator("instance")
                },
                onClick : () => {
                    saveTreeNodesInSessionStorage(treeView)

                    const configuredProjects = getConfiguredProjectsFromSessionStorage()
                    
                    configureBtn.option("text", "")

                    btnIndicator.option("visible", true)
                    setTimeout(() => {
                        btnIndicator.option("visible", false)
                        
                        configureBtn.option("text", "Configure")
                        
                        // hide popup
                        $("#projectConfigurationPopup")
                        .dxPopup("instance")
                        .hide()

                    }, 1000)

                    // reload datagrid
                    $("#configuredProjects")
                        .dxDataGrid("instance")
                        .option("dataSource", configuredProjects)
                }
            })
            .dxButton("instance")
    })
    
}

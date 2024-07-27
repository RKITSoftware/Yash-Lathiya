import popupTemplateForWithoutFramework from "./popupTemplates/forWithoutFramework.js";
import popupTemplateForFramework from "./popupTemplates/withFramework.js";
import popupTemplateForJavaBackend from "./popupTemplates/javaBackend.js";
import popupTemplateForDotNetBackend from "./popupTemplates/dotnetBackend.js";

$(document).ready(function(){
    $("#content")
        .append(`
            <div id='projectMenu'></div>
            <div id='projectConfigurationPopup'></div>
            <div id='configuredProjects'></div>   
        `)

    $.get("../assets/data/projectTypes.json", (projectMenu) => {
        // console.log(projectMenu)
        $("#projectMenu")
            .dxMenu({
                dataSource : projectMenu,
                displayExpr : "name",
                onItemClick(data){
                    const project = data.itemData
                    const projectId = project.id
                    
                    // if project type is selected open popup for project configuration
                    if(projectId.includes("_")){
                        // as per projectId assign popup template
                        switch(projectId){
                            case "1_1" : projectConfigurationPopup.option("contentTemplate", popupTemplateForWithoutFramework)
                                         break;
                            case "1_2" : projectConfigurationPopup.option("contentTemplate", popupTemplateForFramework)
                                         break;
                            case "2_1" : projectConfigurationPopup.option("contentTemplate", popupTemplateForJavaBackend)
                                         break;
                            case "2_2" : projectConfigurationPopup.option("contentTemplate", popupTemplateForDotNetBackend)
                                         break;
                        }
                        projectConfigurationPopup.show()
                    }
                }
            })
    })

    const projectConfigurationPopup = $("#projectConfigurationPopup")
        .dxPopup({
            // contentTemplate : popupTemplateForDotNetBackend,
            showTitle : true,
            title : "Configure Your Project",
            showCloseButton : true,
            width : 500
        })
        .dxPopup("instance")

    // session storage
    // console.log(sessionStorage)
    const configuredProject = []
    for(let i=0; i<sessionStorage.length; i++){
        // if project configuration
        if(sessionStorage.key(i).startsWith("projectConfigurations__")){
            configuredProject.push({
                "Created On" : sessionStorage.key(i).split("__")[1],
                "Project Configurations" : JSON.parse(sessionStorage.getItem(sessionStorage.key(i))).selectedData
            })
        }
    } 

    const dataGrid = $("#configuredProjects")
        .dxDataGrid({
            dataSource : configuredProject,
            columnAutoWidth : true,
            showBorders : true,
            columns: [
                {
                    "dataField" : "Created On",
                },
                {
                    "dataField" : "Project Configurations"
                }
            ]
        })
        .dxDataGrid("instance")
    
})
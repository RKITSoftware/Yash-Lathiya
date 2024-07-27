export default function getConfiguredProjectsFromSessionStorage(){
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
    
    return configuredProject
}
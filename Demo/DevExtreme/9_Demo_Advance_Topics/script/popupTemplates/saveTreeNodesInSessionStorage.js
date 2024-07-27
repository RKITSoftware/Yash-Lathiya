export default function saveTreeNodesInSessionStorage(treeView) {
    
    // Get selected nodes from the treeView
    const selectedNodes = treeView.getSelectedNodes();

    // Extract necessary data from selected nodes
    const selectedData = selectedNodes.map(node => node.text);

    console.log(selectedData)
    const now = new Date()

    const key = 'projectConfigurations__' + now.toString()
    // Store the data in session storage
    sessionStorage.setItem(key, JSON.stringify({
        selectedData: selectedData
    }));

    const toast = 
    $("#toastContainer")
        .dxToast({
            message : "Your project is configured & key is " + key,
            type : "success",
            displayTime: 10000,

        })
        .dxToast("instance")

    toast.show()
}
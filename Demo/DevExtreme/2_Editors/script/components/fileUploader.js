export default function showFileUploader() {

  // remove "content" to delete previously loaded script
  $("#content").remove();

  // append again "content" to container 
  $(".container").append("<div id='content'></div>");

  /* added html components for demonstration */

  $("#content").append(`<div class='btn' id='selectImage'></div>`);

  $("#content").append(`<div class='left-right' id='dropDownArea'></div>`);

  // specified drop zone for file upload
  const dropZone = $("#dropDownArea")
    .dxButton({
      width: "500",
      text: "drop files here ...",
      height: "150",
      hoverStateEnabled: false,
      focusStateEnabled: false,
      activeStateEnabled: false,
    })
    .dxButton("instance");

  // by default select all types of files
  const selectImgBtn = $("#selectImage")
    .dxFileUploader({
      selectButtonText: "Select Image",
      labelText: "Or drop file here...",
      accept: "image/*",
      // allowedFileExtensions: ["jpg", "jpeg", "png", "gif", "svg"],
      allowCanceling: true, // by default : true
      multiple: true, // false -> single file upload & true -> multiple files can be uploaded
      uploadMode: "instantly", // accepts useForm, useButtons & instantly
      uploadUrl: "https://js.devexpress.com/Demos/NetCore/FileUploader/Upload",
      dropZone: $("#dropDownArea"),
      invalidFileExtensionMessage: "These file extensions are not supported ",
      invalidMaxFileSizeMessage: "Please reduce file size to upload", // default messgae --> file is too large
      showFileList: true, // by default : true
      uploadHeaders: {
        "My-custom-header": "My custom value",
      },
      uploadMethod: "POST", // accepts POST or PUT
      
      // when upload is aborted
      abortUpload: (file, uploadInfo) => {
        console.log("file", file);
        console.log("uploadInfo", uploadInfo);
      },

      // before starting the process of sending
      onBeforeSend: (e) => {
        e.request.withCredentials = true;
      },

      // when selected files dragged into drop zone 
      onDropZoneEnter: () => {
        DevExpress.ui.notify({
          message: "Drop your files here",
        });
      },

      // when seleccted files leaves drop zone
      onDropZoneLeave: () => {
        DevExpress.ui.notify({
          message: "Leaved drop zone ... ",
        });
      },

      // when file uploadtion is in progress
      onProgress: () => {
        DevExpress.ui.notify({
          message: "File(s) are uploading",
        });
      },
      
      // when file(s) are uploaded 
      onFilesUploaded: () => {
        DevExpress.ui.dialog.alert("File(s) are successfully uploaded");
      },

      // on upload error occured
      onUploadError: () => {
        console.log("upload error");
      },

      // when multiple files are uploaded and removed some files after it
      onValueChanged: () => {
        console.log("files are changed");
      },
    })
    .dxFileUploader("instance");
}
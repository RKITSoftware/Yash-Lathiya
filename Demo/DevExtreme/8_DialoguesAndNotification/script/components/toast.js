export default function showToast() {
  $("#content").remove();
  $(".container").append("<div id='content'></div>");

  const toast = $("#content")
    .dxToast({
      diaplayTime : 600,
      message : "Toast Message",
      type : "success" // accepts success & error
    })
    .dxToast("instance")

  toast.show()
}
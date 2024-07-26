export default function showPopup() {
    $("#content").remove();
    $(".container").append(`
      <div id='content'>
        <div id ='loginBtn'></div>
        <div id ='loginPopup'></div>
      </div>`);

    // login popup template 
    const popupContentTemplate = (container) => {
      $(container).append(
        $(`
          <div class='left-right '>
            <div class='left'>Username</div>
            <div class='right' id='username'></div>
          </div>`
        ),
        $(`
          <div class='left-right '>
            <div class='left'>Password</div>
            <div class='right' id='password'></div>
          </div>`
        ),
        $(`
          <div id='authorize'></div>`
        )
      )

      $("#username")
        .dxTextBox({
          placeholder: "Enter your username",
          showClearButton: true,  
        })

      $("#password")
        .dxTextBox({
          showClearButton: true,
          mode: "password", 
          placeholder: "Enter your password",
        })

      $("#authorize")
        .dxButton({
          text : "Authorize",
          type : "success",
          onClick(){
            loginPopup.hide()
          }
        })
    }

    const loginPopup = $("#loginPopup")
      .dxPopup({
        contentTemplate : popupContentTemplate,
        width : 500,
        height : 500,
        // container : "dx-viewport",
        showTitle : true,
        title : "Enter Your Credential",
        dragEnabled : false,
        showCloseButton : true
      })
      .dxPopup("instance")

    $("#loginBtn")
      .dxButton({
        text : "Login",
        type : "success",
        onClick(){
          loginPopup.show();
        }
      })
    
  }
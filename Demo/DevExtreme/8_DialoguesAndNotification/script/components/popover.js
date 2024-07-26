export default function showPopover() {
    $("#content").remove();
    $(".container").append(`
      <div id='content'>
        <div class='left-right '>
          <div class='left'>Dafault Mode</div>
          <div class='right'>
            <a id='defaultPopoverLink'>details</a>
          </div>
        </div>
        <div id="defaultPopover"> The designs for new brochures and website have been approved. Launch date is set for Feb 28. </div>
        <div class='left-right '>
          <div class='left'>With Title</div>
          <div class='right'>
            <a id='titlePopoverLink'>details</a>
          </div>
        </div>
        <div id="titlePopover"> The designs for new brochures and website have been approved. Launch date is set for Feb 28. </div>
        <div class='left-right '>
          <div class='left'>With Animation</div>
          <div class='right'>
            <a id='animationPopoverLink'>details</a>
          </div>
        </div>
        <div id="animationPopover"> The designs for new brochures and website have been approved. Launch date is set for Feb 28. </div>
        <div class='left-right '>
          <div class='left'>With Overlay</div>
          <div class='right'>
            <a id='overlayPopoverLink'>details</a>
          </div>
        </div>
        <div id="overlayPopover"> Kindly double click outside. </div>
      </div>`);
    
    $("#defaultPopover")
      .dxPopover({
        target : "#defaultPopoverLink",
        showEvent : "mouseenter",
        hideEvent : "mouseleave",
        position : "top",
        width : 300
      })

    $("#titlePopover")
      .dxPopover({
        target : "#titlePopoverLink",
        showEvent : "mouseenter",
        hideEvent : "mouseleave",
        position : "top",
        width : 300,
        showTitle : true,
        title : "Popover"
      })
  
    $("#animationPopover")
      .dxPopover({
        target : "#animationPopoverLink",
        showEvent : "mouseenter",
        hideEvent : "mouseleave",
        position : "top",
        width : 300,
        animation: {
          show: {
            type: 'pop',
            from: { scale: 0 },
            to: { scale: 1 },
          },
          hide: {
            type: 'fade',
            from: 1,
            to: 0,
          },
        },
      })
    
    $("#overlayPopover")
      .dxPopover({
        target : "#overlayPopoverLink",
        showEvent: "mouseenter",
        position : "top",
        width : 300,
        shading: true,
        shadingColor: 'rgba(0, 0, 0, 0.5)',
      })
  }   
export default function showLoadIndicator() {
    $("#content").remove();
    $(".container").append(`
      <div id='content'>
        <h2>Loading Indicator</h2>
          <div id='indicator'></div>
          <div id='sizeSlider'></div>
        <h2>Image Loading Indicator</h2>  
          <div id='imageIndicator'></div>
        <h2>Btn Loading</h2>
          <div id='btn'></div>
        <h2>Chart Indicator</h2>
          <div id='chartContainer'></div>
      </div>`);

    // loading indicator resizing by slider 
    let sizeSlider = $("#sizeSlider").dxSlider({
      min : 0,
      max : 100,
      step : 10,
      value : 20,
      showRange : true,
      onValueChanged(){
        indicator.option("height", sizeSlider.option("value"))
        indicator.option("width", sizeSlider.option("value"))
      }
    })
      .dxSlider("instance")

    let indicator = $("#indicator").dxLoadIndicator({
      height : 20,
      width : 20,
    })
      .dxLoadIndicator("instance")

    // Chart Loading 
    var chart = $("#chartContainer").dxChart({
      loadingIndicator : {
        enabled : true
      }
    })
      .dxChart("instance")

    chart.showLoadingIndicator();
      
    // Image Indicator
    $("#imageIndicator").dxLoadIndicator({
      indicatorSrc : "../assets/images/loading-fast.gif",
    })

    // Button Loading
    let btnIndicator;
    $("#btn")
      .dxButton({
        text : "UPLOAD",
        height : 50,
        width : 230,
        template(data, container){
          $(`<div id='btnIndicator'></div><span class='dx-button-text'>${data.text}</span>'`)
            .appendTo(container)
          btnIndicator = container.find("#btnIndicator")
                                  .dxLoadIndicator({
                                    visible : false
                                  })
                                  .dxLoadIndicator("instance")
        },
        onClick(data){
          data.component.option("text", "")
          btnIndicator.option("visible", true)
          setTimeout(() => {
            btnIndicator.option("visible", false)
            data.component.option("text", "UPLOAD")
          }, 2000)
        }
      })

  }
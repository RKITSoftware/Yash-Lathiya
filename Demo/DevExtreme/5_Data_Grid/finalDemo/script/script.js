$.ajax({
    url: "https://literate-space-waddle-jvr4475rq6v2j57r-5246.app.github.dev/api/Orders/Hello",
    method: "GET",
    success: function(data, status, xhr) {
      // Handle success response
      console.log(data);
    },
    error: function(xhr, status, error) {
      if (xhr.status === 302) {
        // Get the redirected URL from the Location header
        let redirectedUrl = xhr.getResponseHeader('Location');
        // Make another AJAX request to the redirected URL
        $.ajax({
          url: redirectedUrl,
          method: "GET",
          success: function(data) {
            console.log(data); // Handle the data from the redirected response
          },
          error: function(xhr, status, error) {
            console.error('Error:', error);
          }
        });
      } else {
        console.error('Error:', error);
      }
    }
  });

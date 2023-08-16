$(document).ready(function () {
  //Deferred object declared
  var deferredObject = $.Deferred();
  var promise = deferredObject.promise();

  //Random number is generated
  let number = Math.floor(Math.random() * 1000);
  console.log(number);

  console.log(deferredObject.state());

  //If number is even deferred object is resolved otherwise rejected
  if (number % 2 == 0) {
    deferredObject.resolve();
  } else {
    deferredObject.reject();
  }

  console.log(deferredObject.state());

  //If object resolved then print "Object Resolved"
  //If object rejected then print "Object Rejected"
  promise.done(() => {
    console.log("Object Resolved");
  });
  promise.fail(() => {
    console.log("Object Rejected");
  });
});

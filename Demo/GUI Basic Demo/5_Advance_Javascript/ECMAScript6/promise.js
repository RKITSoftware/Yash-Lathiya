//If number is odd prints success else print failure

let promise = new Promise(function (success, fail) {
  console.log("Producing code of promise");
  const number = Math.floor(Math.random() * 1000);
  console.log(number);
  if (number % 2 == 0) {
    fail();
  }
  success();
  fail();
});
promise.then(
  function () {
    console.log("Success | Number is odd");
  },
  function () {
    console.log("Failure | Number is even");
  }
);

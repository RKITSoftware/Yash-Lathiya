//async function is a function which returns a promise.
async function function1() {
  console.log("Function 1 started");

  const a = 2;
  a = 3;

  return "function1";
}

function1().then(
  () => {
    console.log("Function 1 executed successfully");
  },
  () => {
    console.log("Function 1 failed to execute");
  }
);

//await is keyword which wait to resolve promise.

function wait(ms) {
  return new Promise((timeOut) => {
    setTimeout(timeOut, ms);
  });
}
async function asyncFunction() {
  console.log("async function started");

  console.log("Wait for 2 seconds");
  await wait(2000);
  console.log("2 second completed");

  console.log("Wait for 3 seconds");
  await wait(2000);
  console.log("3 second completed");
}
asyncFunction();

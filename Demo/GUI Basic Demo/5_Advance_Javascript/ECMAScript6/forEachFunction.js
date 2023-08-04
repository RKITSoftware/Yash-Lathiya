const array = ["y", "a", "s", "h", "L", "a", "t", "h", "i", "y", "a"];
let fullName = "";

//Order of arguments must be maintained
function printValue(value, index, array) {
  fullName += value;
}

//If we want to use only value
// function printValue(value) {
//   fullName += value;
// }

array.forEach(printValue);

console.log(fullName);

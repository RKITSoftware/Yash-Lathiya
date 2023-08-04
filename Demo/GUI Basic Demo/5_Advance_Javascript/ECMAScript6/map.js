//How to create a Map ?

const employeeList = new Map([
  [1001, "employee1"],
  [1002, "employee2"],
  [1003, "employee3"],
  [1004, "employee4"],
]);

//Add pairs in map

employeeList.set(1005, "employee5");
employeeList.set(1006, "employee6");

// get values by key

console.log("EMployeeID 1001 : " + employeeList.get(1001));

//Size of map

console.log("Size of map : " + employeeList.size);

//Delete single pair in map

employeeList.delete(1006);

//Check key is present in map or not

if (employeeList.has(1006)) {
  console.log("EMployeeID 1006 is present");
} else {
  console.log("EMployeeID 1006 is not present");
}

//All entries

console.log(employeeList.entries());

//All keys

console.log(employeeList.keys());

//All Values

console.log(employeeList.values());

//Delete all pairs in map

employeeList.clear();

//*************************/
//Set implimentation is also similar just difference is that it contains only unique values.
//*************************/

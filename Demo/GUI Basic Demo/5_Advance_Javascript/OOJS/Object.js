//How to create a object ?

const employee = {
  id: 1,
  firstName: "Yash",
  lastName: "Lathiya",
  profile: "Full Stack Developer",
  tasks: {
    task1: "HTML",
    task2: "Javascript",
    task3: "CSS",
  },
  get firstNameValue() {
    return this.firstName;
  },
  set firstNameValue(firstName) {
    this.firstName = firstName;
  },
  fullName: function () {
    return this.firstName + " " + this.lastName;
  },
};
employee.company = "RKIT";
// employee.firstNameValue = "Arth";
console.log(employee.fullName());
console.log(employee.id);
console.log(employee["company"]);
console.log("tasks :" + Object.entries(employee.tasks));

//Objects are mutable, they are addressed by reference, not value.

const employeeCopy = employee;
employee.profile = "Full Stack Web Developer";
console.log(employeeCopy.profile);

//Display value of objects

//By iteration
let employeeValues = "";
for (employeeProperty in employee) {
  employeeValues = employeeValues + employee[employeeProperty] + " ";
}
console.log("**" + employeeValues + "**");

//By Object.values() method
const emplyeeValueArray = Object.values(employee);
console.log(emplyeeValueArray);

//By JSON.stringify method
console.log(JSON.stringify(employee));

//Deletion of object properties
// delete keyword can delete only properties, it can't affect variable or methods.

delete employee.company;
console.log(employee.company);

delete employee.fullName();
console.log(employee.fullName());

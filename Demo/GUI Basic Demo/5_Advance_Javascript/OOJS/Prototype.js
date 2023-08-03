//Object which shows personPrototype

const personPrototype = {
  who() {
    console.log("Im Person");
  },
  firstName: "Yash",
  lastName: "Lathiya",
};

//Assign personPrototype to newly intialized object employee by create method

const employee = Object.create(personPrototype);

//Now employee contains all inherited properties from personPrototype
//It'll override if any clashes with prototype.

employee.who = () => {
  console.log("Im Employee");
};
console.log(employee.firstName);
console.log(employee.lastName);
employee.who();

//Assigning prototype to object by assign method

function student(studentId) {
  this.studentId = studentId;
}
const student1 = new student("1001");
Object.assign(student.prototype, personPrototype);

console.log(student1.firstName);

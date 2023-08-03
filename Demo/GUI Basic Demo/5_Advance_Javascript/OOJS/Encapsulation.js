class Person {
  constructor(firstName, lastName) {
    this.firstName = firstName;
    this.lastName = lastName;
  }
  who() {
    console.log("Im Person");
  }
}
class Employee extends Person {
  #companyName;
  #companyInformation() {
    console.log("This company is situated in Rajkot");
  }
  constructor(firstName, lastName, companyName) {
    super(firstName, lastName);
    this.#companyName = companyName;
  }
  who() {
    console.log("Im Employee of " + this.#companyName);
  }
}
const employee1 = new Employee("Yash", "Lathiya", "RKIT");
employee1.who();

//throws error because companyName is private property
console.log(employee1.#companyName);
employee1.#companyInformation();

//prints 'undefined' or 'function not found' as it cant access
console.log(employee1.companyName);
employee1.#companyInformation();

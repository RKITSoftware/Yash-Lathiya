// Class with static variables and static method

class Employee {
  constructor(id, firstName, lastName) {
    this.id = id;
    this.firstName = firstName;
    this.lastName = lastName;
  }
  static companyName = "RKIT";
  fullName() {
    return this.firstName + " " + this.lastName;
  }
  static printCompanyName() {
    console.log(this.companyName);
  }
}

//Instances of Employee class

const emp1 = new Employee(1, "Yash", "Lathiya");
emp1.company = "RKIT";

const emp2 = new Employee(2, "Sachin", "Tendulkar");

console.log("Name : " + emp1.fullName());
console.log("Comapny : " + emp1.company);
console.log("Name : " + emp2.fullName());

//Use of static keyword

//Direct class can access static members only
Employee.printCompanyName();

//Prints undefined as it has no aceess of static variable
console.log(emp2.companyName);

//returns error 'not a function' due to static keyword
// emp2.printCompanyName();

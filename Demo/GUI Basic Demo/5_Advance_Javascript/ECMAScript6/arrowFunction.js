//Working of normal function

export const employee1 = {
  firstName: "Yash",
  lastName: "Lathiya",
  fullName: function () {
    //this refers to employee1
    return this.firstName + this.lastName;
  },
};

// export { emploee1 };

//Print fullname of employee1
console.log(employee1.fullName());

//Arrow Function

const employee2 = {
  firstName: "Sachin",
  lastName: "Tendulkar",
  fullName: () => {
    //this refers to object of function
    // return this.firstName + this.lastName;
  },
};

//fullName function has not any properties like firstName & lastName
//So it'll not print full name of employee2
console.log(employee2.fullName());

//Export arrow function

export default (a) => {
  console.log(a);
};

class ObjectOrientedProgramming
{
    static void Main(string[] args)
    {
        encapsulation();

        polymorphism();

        useOfSealedClass();

        abstraction();

        implementationOfInterface();
    }

    static void encapsulation()
    {
        Person person = new Person();
        person.MobileNumber = 7046985354;
        Console.WriteLine("Mobile Number : " + person.MobileNumber);
        person.FirstName = "Yash";
        Console.WriteLine("First Name : " + person.FirstName);
    }

    static void polymorphism()
    {
        Employee employee = new Employee();
        employee.getProfileDetails();

        WebDesigner webDesigner = new WebDesigner();
        webDesigner.getProfileDetails();

        FullStackDeveloper fullStackDeveloper = new FullStackDeveloper();
        fullStackDeveloper.getProfileDetails();
        fullStackDeveloper.getProfileDetails("Yash Lathiya");

        Coordinator coordinator = new Coordinator();
        coordinator.getProfileDetails();
    }

    static void useOfSealedClass()
    {
        try
        {
            ParentClass parent = new ParentClass();
            //SubClass sub = new SubClass();
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
        }
    }

    static void abstraction()
    {
        DerivedClass derivedClass = new DerivedClass();
        derivedClass.regularMethod();
        derivedClass.abstractMethod();
    }

    static void implementationOfInterface()
    {
        Tiger tiger = new Tiger();
        tiger.animalName();
        tiger.isFoundInIndia();
    }
}

//Implementation of Encapsulation
class Person
{
    //Private field is _mobileNumber, get and set methods
    private long _mobileNumber;
    public long MobileNumber
    {
        get { return _mobileNumber; }
        set { _mobileNumber = value; }
    }

    //by default get set methods
    public string FirstName
    {
        get; set;
    }
}

//Implementation of Polymorphism

//Base Class
class Employee
{
    public virtual void getProfileDetails()
    {
        Console.WriteLine("I am emplyee of the company.");
    }
}

//Derived Class
class WebDesigner : Employee
{
    public override void getProfileDetails()
    {
        Console.WriteLine("I am web designer.");
    }
}

//Derived Class
class FullStackDeveloper : Employee
{
    //Method Overloading
    public void getProfileDetails()
    {
        Console.WriteLine("I am full stack developer.");
    }

    public void getProfileDetails(string name)
    {
        Console.WriteLine("I am full stack developer. My name is "+name);
    }
}

//Derived Class
class Coordinator : Employee
{
    public override void getProfileDetails()
    {
        Console.WriteLine("I am project coordinator.");
    }
}

//This class does not allow Inheritance
public sealed class ParentClass
{
    public ParentClass()
    {
        Console.WriteLine("Hello Im Parent Class, I don't allow another class to inherit my properties..");
    }
}

//It will generate errors, because sealed class cannot be inherited..
//class SubClass : ParentClass
//{

//}

//Implementation of Abstraction

abstract class AbstractClass
{
    public abstract void abstractMethod();

    public void regularMethod()
    {
        Console.WriteLine("Hello, Im regular method");
    }
}

class DerivedClass : AbstractClass
{
    //If abstractMethod body is not defined here --> It will generate error.
    public override void abstractMethod()
    {
        Console.WriteLine("Hello, Im abstract method");
    }
}

//Implementation of Interface

interface IAnimal
{
    void animalName();
    void isFoundInIndia();
}
interface IBirds
{
    void birdName();
    void isFoundInIndia();
}

class Tiger : IAnimal, IBirds
{
    public void animalName()
    {
        Console.WriteLine("Hello, I am Tiger");
    }

    //Method which implements multiple inheritance
    public void isFoundInIndia()
    {
        Console.WriteLine("Yes, I'm leaving in India");
    }
    public void birdName()
    {
        Console.WriteLine("But, Im not bird..");
    }
}
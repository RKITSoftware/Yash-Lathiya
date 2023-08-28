//Accessibility Modifiers
using ClassLibrary;
class AccessibilityModifiers
{
    static void Main(string[] args)
    {
        privateImplementation();

        protectedImplementation();

        internalImplementation();
    }

    static void privateImplementation()
    {
        Person person = new Person();
        Console.WriteLine("Aadhar Number : " + person.getAadharNumber());
    }

    static void protectedImplementation()
    {
        Student student = new Student();
        Console.WriteLine(student.getProfession());
    }

    static void internalImplementation()
    {
        PublicClass publicClass = new PublicClass();

        //Internal class is not accessible because it contains different assembly.

        //InternalClass internalClass = new InternalClass();
    }
}

//Private   --> Accessible in only class
//Public    --> Accessible in same or another assembly
//protected --> Accessible in same or derived class
//internal  --> Accessible in same assembly only

class Person
{
    private readonly long _aadharNumber = 123456781234;

    public long getAadharNumber()
    {
        return _aadharNumber;
    }
}

class Profession
{
    protected string firstName = "Yash";
    protected string lastName = "Lathiya";
    protected string profession = "My profession can be anything!!";
}

class Student : Profession
{
    public Student()
    {
        profession = "Im student";
    }

    public string getProfession()
    {
        return profession;
    }
}
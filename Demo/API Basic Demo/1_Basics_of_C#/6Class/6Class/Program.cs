class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Main Method Execution Started");

        //Created instances of the class Person 

        Person person = new Person();
        Person yash = new Person("Yash");
        Person yashLathiya = new Person("Yash", "Lathiya");

        Console.WriteLine("Identity : "+person.identity);
        Console.WriteLine("Full Name: " + yashLathiya.getFullName());

        //Change values of properties in object
        yash.identity = "Person with firstName initialization";
        Console.WriteLine("Identity : " + yash.getIdentity());

        person.hasExtra();

        person.hasExtra("Extra section added");

        person.hasExtra();

        Console.WriteLine("Main Method Execution Ended");

    }
}
class Person
{
    //Variables
    public string identity = "Person";
    string firstName;
    string lastName;
    string extra;

    //Constructor Overloading 
    public Person()
    {
       
    }
    public Person(string firstName)
    {
        this.firstName = firstName;
    }
    public Person(string firstName, string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
    }

    //Methods
    public string getFullName()
    {
        return this.firstName + " " + this.lastName; 
    }
    public string getIdentity()
    {
        return this.identity;
    }
    //Method Overloading
    public void hasExtra()
    {
        if(this.extra != null)
        {
            Console.WriteLine(this.extra);
        }
        else
        {
            Console.WriteLine("No extra section added");
        }
    }
    public void hasExtra(string extra)
    {
        this.extra += extra;
        Console.WriteLine(this.extra);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;

class Collection
{
    public static void Main(string[] args)
    {
        list();

        dictionary();

        stack();

        queue();

        hashTable();

        customCollection();
    }

    public static void list()
    {
        //Collection --> List

        //Create List

        List<string> list = new List<string>();
        list.Add("Yash Lathiya");
        list.Add("Sachin Tendulkar");
        list.Add("Virat Kohli");
        list.Add("Yash Lathiya");

        var myNewList = new List<string> {
            "India",
            "Pakistan",
            "Shirlanka",
            "Bhutan"
        };

        //list of object
        var listOfPerson = new List<Person>();
        listOfPerson.Add(new Person("Yash Lathiya", 18));
        listOfPerson.Add(new Person("Arth Lathiya"));

        //Update data into list

        myNewList[3] = "China";

        //Remove Specific element from list

        //Remove first occurance if multiple occurances are found..
        list.Remove(list[2]);
        list.Remove("Yash Lathiya");

        //Sorting of list
        myNewList.Sort();

        //Print List items

        foreach (string item in list)
        {
            Console.WriteLine(item);
        }

        for (int i = 0; i < myNewList.Count; i++)
        {
            Console.WriteLine(myNewList[i]);
        }

        foreach(Person person in listOfPerson)
        {
            person.printDetails();
        }

        //Clear List
        list.Clear();
    }

    public static void dictionary()
    {
        // Collection --> dictionary

        //Create Dictionary

        Dictionary<long, string> students = new Dictionary<long, string>();

        //Add data into dictionary
        students.Add(200200107095, "Yash Lathiya");
        students.Add(200200107096, "Raj Koradiya");
        students.Add(200200107097, "Rathi Soneji");

        //Update data into dictonary
        students[200200107095] = "Arth Lathiya";

        //Find specific value from dictionary's index
        if (students.ContainsKey(200200107095))
        {
            Console.WriteLine(students[200200107095]);
        }

        //Find specific key from dictionary's value
        foreach(var student in  students)
        {
            if(student.Value == "Rathi Soneji")
            {
                Console.WriteLine(student.Key);
                break;
            }
        }

        //Print dictionary
        foreach(var student in students)
        {
            Console.WriteLine("Enrollment : " + student.Key + ", Name : " + student.Value);
        }
    }

    public static void stack()
    {
        // Collection --> Stack

        //create stack

        var stack = new Stack<int>();

        //Push operation

        stack.Push(33);
        stack.Push(34);
        stack.Push(35);
        stack.Push(36);
        stack.Push(37);

        //Pop operation

        stack.Pop();
        stack.Pop();

        //Peek operation --> accessing element on the peek without removing it..

        Console.WriteLine(stack.Peek());

        //print stack

        foreach(var number in stack)
        {
            Console.WriteLine(number);
        }

    }

    public static void queue()
    {
        // Collection --> Queue

        //create queue

        var queue = new Queue<string>();

        //Enqueue operation

        queue.Enqueue("First Element");
        queue.Enqueue("Second Element");
        queue.Enqueue("Third Element");
        queue.Enqueue("Fourth Element");
        queue.Enqueue("Fifth Element");

        //Dequeue operation

        queue.Dequeue();
        queue.Dequeue();

        //Peek operation --> accessing element on the peek without removing it..

        Console.WriteLine(queue.Peek());

        //Form array with help of queue

        var arrayOfQueueElements = queue.ToArray();

        foreach(var element in arrayOfQueueElements)
        {
            Console.WriteLine(element);
        }

        //print queue

        foreach(var item in queue)
        {
            Console.WriteLine(item);
        }
    }

    public static void hashTable()
    {
        // Collection --> Hash Table

        //Create hashtable

        Hashtable hashTable = new Hashtable();

        hashTable.Add("1001", "Sachin Tendulkar");
        hashTable.Add("1002", "Virat Kohli");
        hashTable.Add("1003", "Mahendra Singh Dhoni");
        hashTable.Add(1004, "Ravindra Jadeja");

        //Contains --> hashtable contains specific key or not

        Console.WriteLine("Hashtable contains key 1002(string) : " + hashTable.Contains("1002"));

        //ContainsKey --> hashtable contains specific key or not

        Console.WriteLine("Hashtable contains key 1005(int) : " + hashTable.ContainsKey(1005));

        //ContainsValue --> hashtable contains specific value or not

        Console.WriteLine("Hashtable contains value Ravindra Jadeja : " + hashTable.ContainsValue("Ravindra Jadeja"));

        //Print hashtable

        foreach(DictionaryEntry item in hashTable)
        {
            Console.WriteLine(item.Key + " " + item.Value);
        }

        //Remove data in hashtable

        hashTable.Remove(1004);
    }

    public static void customCollection()
    {
        // Collection --> Custom Collection

        var vehicles = new AllVehicles();

        //foreach loop internally calls GetEnumerator() method in AllVehicles class
        //Then it call MoveNext() method for accessing next item
        //It will call Current for accessing current item

        foreach(Vehicle vehicle in vehicles)
        {
            Console.WriteLine(vehicle.VehicleName);
        }

    }
}

class Person
{
    string name;
    int age;

    public Person(string name)
    {
        this.name = name;
    }
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public void printDetails()
    {
        Console.WriteLine("Name : " + this.name);
        Console.WriteLine("Age : " + this.age);
    }

}

// Vehicle Class which contains vehicleName property
class Vehicle
{
    public string VehicleName
    {
        get; set;
    }
}

//All vehicle is a collection classs which is used for vehicle
class AllVehicles : System.Collections.IEnumerable
{
    //Initialize array of vehicles by adding 3 vehicles by default
    private Vehicle[] _vehicles =
    {
        new Vehicle() {VehicleName = "Car"},
        new Vehicle() {VehicleName = "Bike"},
        new Vehicle() {VehicleName = "Truck"}
    };
    public System.Collections.IEnumerator GetEnumerator()
    {
        return new VehicleEnumerator(_vehicles);
    }

    class VehicleEnumerator : System.Collections.IEnumerator
    {
        private Vehicle[] _vehicles;
        private int _index = -1;

        public VehicleEnumerator(Vehicle[] vehicles)
        {
            _vehicles = vehicles;
        }

        //Accessing Current Vehicle
        object System.Collections.IEnumerator.Current
        {
            get
            {
                return _vehicles[_index];
            }
        }

        //Accessing next element until collection ends
        bool System.Collections.IEnumerator.MoveNext()
        {
            _index++;
            return (_index < _vehicles.Length);
        }

        //Directly not using this method.. 
        //But important to initilize with default values
        void System.Collections.IEnumerator.Reset()
        {
            _index = -1;
        }
    }
}
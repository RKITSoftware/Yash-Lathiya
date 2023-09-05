using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;

class Collection
{
    #region Public Methods
    public static void Main(string[] args)
    {
        ListImplementation();

        DictionaryImplementation();

        StackImplementation();

        QueueImplementation();

        HashTableImplementation();

        CustomCollection();
    }

    /// <summary>
    /// Demonstration of list collection with its operation
    /// </summary>
    public static void ListImplementation()
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
            person.PrintDetails();
        }

        //Clear List
        list.Clear();
    }

    /// <summary>
    /// Demonstration of dictionary collection with its operation
    /// </summary>
    public static void DictionaryImplementation()
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

    /// <summary>
    /// Demonstration of stack collection with its operation
    /// </summary>
    public static void StackImplementation()
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

    /// <summary>
    /// Demonstration of queue collection with its operation
    /// </summary>
    public static void QueueImplementation()
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

    /// <summary>
    /// Demonstration of hashtable collection with its operation
    /// </summary>
    public static void HashTableImplementation()
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

    /// <summary>
    /// Demonstration of custom collection with its basic implementation
    /// </summary>
    public static void CustomCollection()
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

    #endregion
}

/// <summary>
/// class which contains name and age of person
/// </summary>
class Person
{
    #region Class Variables

    string name;
    int age;

    #endregion

    #region Constructors

    public Person(string name)
    {
        this.name = name;
    }
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Prints Name and age of the Person object
    /// </summary>
    public void PrintDetails()
    {
        Console.WriteLine("Name : " + this.name);
        Console.WriteLine("Age : " + this.age);
    }

    #endregion
}

/// <summary>
/// Vehicle Class which contains vehicleName property
/// </summary>
class Vehicle
{
    #region Public Methods

    /// <summary>
    /// get, set method for VehicleName
    /// </summary>
    public string VehicleName
    {
        get; set;
    }

    #endregion
}

/// <summary>
/// All vehicle is a collection classs which is used for vehicle
/// </summary>
class AllVehicles : System.Collections.IEnumerable
{
    #region Private Members

    //Initialize array of vehicles by adding 3 vehicles by default
    private Vehicle[] _vehicles =
    {
        new Vehicle() {VehicleName = "Car"},
        new Vehicle() {VehicleName = "Bike"},
        new Vehicle() {VehicleName = "Truck"}
    };

    #endregion

    #region Public Methods
    public System.Collections.IEnumerator GetEnumerator()
    {
        return new VehicleEnumerator(_vehicles);
    }

    #endregion

    class VehicleEnumerator : System.Collections.IEnumerator
    {
        #region Private Members

        private Vehicle[] _vehicles;
        private int _index = -1;

        #endregion

        #region Constructor

        public VehicleEnumerator(Vehicle[] vehicles)
        {
            _vehicles = vehicles;
        }

        #endregion

        #region Methods

        //Accessing Current Vehicle
        object System.Collections.IEnumerator.Current
        {
            get
            {
                return _vehicles[_index];
            }
        }

        /// <summary>
        /// Accessing next element until collection ends
        /// </summary>
        /// <returns> Next item's index in collection</returns>
        bool System.Collections.IEnumerator.MoveNext()
        {
            _index++;
            return (_index < _vehicles.Length);
        }

        /// <summary>
        /// Directly not using this method.. But important to initilize with default values 
        /// </summary>
        void System.Collections.IEnumerator.Reset()
        {
            _index = -1;
        }

        #endregion
    }
}
class DateTimeImplementation
{
    #region Methods
    static void Main(string[] args)
    {
        InitializeDate();

        DifferentFormatsOfDate();

        AdditionSubstractionInDate();

        CheckLeapYear();

        DateAndString();
    }

    /// <summary>
    /// Create object of date
    /// </summary>
    static void InitializeDate()
    {
        DateTime date = new DateTime(2003, 03, 22);
        Console.WriteLine(date);

        DateTime dateAndTime = new DateTime(2003,03,22,22,1,0);
        Console.WriteLine(dateAndTime);

        DateTime emptyDate = new DateTime();
        Console.WriteLine(emptyDate);

    }

    /// <summary>
    /// Demonstrates different formats of the date
    /// </summary>

    static void DifferentFormatsOfDate()
    {
        DateTime date = new DateTime(2003, 03, 22);
        Console.WriteLine(date);

        //All Formats of the date

        String[] formatsOfDate = date.GetDateTimeFormats();

        foreach(String format in formatsOfDate)
        {
            Console.WriteLine(format);
        }
    }

    /// <summary>
    /// How to make changes in date by adding or subtracting time..S
    /// </summary>
    static void AdditionSubstractionInDate()
    {
        DateTime date = new DateTime(2003, 03, 22);

        //Addition

        date.AddYears(15);
        date.AddMonths(3);
        date.AddDays(17);
        date.AddHours(20);
        date.AddMinutes(30);
        date.AddSeconds(30);
        date.AddMilliseconds(2000);

        DateTime now = DateTime.Now;

        //Calculate Age of the person

        DateTime birthDate = new DateTime(2003, 03, 22);
        DateTime today = DateTime.Today;

        int ageInYears = today.Year - birthDate.Year;

        Console.WriteLine("Age : " + ageInYears + " Years");
    }

    /// <summary>
    /// Checks the year is leap year or not.
    /// </summary>
    static void CheckLeapYear()
    {
        DateTime today = DateTime.Today;

        if (DateTime.IsLeapYear(today.Year))
        {
            Console.WriteLine("This is a leap year");
        }
        else
        {
            Console.WriteLine("This is not a leap year");
        }
    }

    /// <summary>
    /// Convert date to string vice-versa
    /// </summary>
    static void DateAndString()
    {
        string dateInString = "2003-03-22T20:12:45-5:00";

        //String to date

        DateTime date = DateTime.Parse(dateInString);
        Console.WriteLine(date);

        //Date to String

        Console.WriteLine("String : " + date.ToString());

    }

    #endregion
}
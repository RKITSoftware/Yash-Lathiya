using System;
using System.Globalization;

class ExceptionHandling
{
    #region Class Methods
    static void Main(string[] args)
    {
        BasicFlowOfException();

        ImplementCustomException();
        
    }

    /// <summary>
    /// Performs Devision Operation
    /// </summary>
    /// <param name="a">Numerator</param>
    /// <param name="b">Denominator</param>
    /// <returns> a devide by b </returns>
    static int Division(int a, int b)
    {
        return a / b;
    }

    /// <summary>
    /// It shows execution flow of try, catch and finally block. 
    /// </summary>
    static void BasicFlowOfException()
    {
        // try block where exception can be arrived
        try
        {
            Console.WriteLine("I'm performing division by 0");

            int ans = Division(5, 0);
        }

        //to catch that exception
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
        }

        //this block will call in both cases --> Exception omitted or not
        finally
        {
            Console.WriteLine("I've tried to perform devision");
        }
    }

    /// <summary>
    /// custom exception to remove white spaces from username..
    /// </summary>
    static void ImplementCustomException()
    {
        string userName = "yash lathiya";
        Console.WriteLine("Username entered by user :" + userName);

        try
        {
            //If username contains whitespace --> throw ContainsWhiteSpace
            checkWhiteSpace(userName);
        }

        // this catch block removes white spaces from usernmame..

        catch(ContainsWhiteSpace ex)
        {
            Console.WriteLine(ex);
            userName = userName.Replace(" ", "");
        }
        
        // If it is specific exception

        catch(Exception ex) when ( ex is StackOverflowException || ex is NullReferenceException) 
        {
            Console.WriteLine(ex.StackTrace);
            throw ex; //throw keyword stops execution of program with throw of exception
        }

        //Another catch block for unexpected exception..

        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
            throw; //throw exception as it is not handled
        }

        // prints username accepted by program..

        finally
        {
            Console.WriteLine("Username accepted by program : " + userName);
        }
    }

    /// <summary>
    /// If whitespace found in string --> will throw ContainsWhiteSpace Exception
    /// </summary>
    /// <param name="str"> A field in which checks whitespace or not</param>
    /// <exception cref="ContainsWhiteSpace"> Deal with ContainsWhiteSpace </exception>
    static void checkWhiteSpace(string str)
    {
        foreach (char c in str.ToCharArray())
        {
            if(c == ' ')
            {
                throw new ContainsWhiteSpace("this field contains whitespace");
            }
        }
    }

    #endregion
}

// Implement custom exception --> ContainsWhiteSpace
class ContainsWhiteSpace : Exception
{
    #region Constructor
    public ContainsWhiteSpace(string value)
    {
        Console.WriteLine("This is ContainsWhiteSpace Exception");
    }
    #endregion
}
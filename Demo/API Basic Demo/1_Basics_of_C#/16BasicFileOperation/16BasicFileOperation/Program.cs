using System;
using System.IO;
class BasicFileOperation
{
    static void Main(String[] args)
    {
        FileReading();

        FileWriting();
    }

    /// <summary>
    /// Demonstration of file writing
    /// </summary>
    static void FileWriting()
    {
        StreamWriter sw = new StreamWriter("D:\\RKIT\\Github Repo\\Demo\\API Basic Demo\\1_Basics_of_C#\\16BasicFileOperation\\16BasicFileOperation\\textFile.txt");

        sw.WriteLine("Hello, I am writing file");
        sw.WriteLine("Hello, I am second line");

        sw.Flush();

        sw.Close();
    }

    /// <summary>
    /// Demonstation of file reading
    /// </summary>
    static void FileReading()
    {
        StreamReader sr = new StreamReader("D:\\RKIT\\Github Repo\\Demo\\API Basic Demo\\1_Basics_of_C#\\16BasicFileOperation\\16BasicFileOperation\\textFile.txt");

        sr.BaseStream.Seek(0, SeekOrigin.Begin);

        string str = sr.ReadLine();

        while(str != null)
        {
            Console.WriteLine(str);
            str = sr.ReadLine();
        }

        Console.ReadLine();

        sr.Close();
    }
}
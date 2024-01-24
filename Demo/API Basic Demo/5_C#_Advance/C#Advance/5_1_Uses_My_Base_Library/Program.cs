using _5_Document_Generator_Base_Library;
using _5_Document_Generator_Base_Library._5_Automatic_Document_Generation_Library;

namespace _5_1_Uses_My_Base_Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string solutionPath = @"C:\Users\yash.l\source\repos\Yash-Lathiya\Demo\API Basic Demo\5_C#_Advance\C#Advance\C#Advance.sln";

            // Specify the output directory for documentation files
            string outputDirectory = @"C:\Users\yash.l\source\repos\Yash-Lathiya\Demo\API Basic Demo\5_C#_Advance\C#Advance\5_1_Uses_My_Base_Library\Output\";

            // Generate documentation for the solution
            DocumentationGenerator.GenerateDocumentation(solutionPath, outputDirectory);
        }
    }
}
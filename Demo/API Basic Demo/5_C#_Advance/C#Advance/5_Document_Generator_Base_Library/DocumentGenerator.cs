using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;

namespace _5_Document_Generator_Base_Library
{
   
    namespace _5_Automatic_Document_Generation_Library
    {
        /// <summary>
        /// Utility class for generating documentation for methods in a C# solution.
        /// </summary>
        public class DocumentationGenerator
        {
            /// <summary>
            /// Generates documentation for all methods in a C# solution and saves it to files.
            /// </summary>
            /// <param name="solutionPath">Path to the C# solution file.</param>
            /// <param name="outputDirectory">Path to the directory where documentation files will be saved.</param>
            public static void GenerateDocumentation(string solutionPath, string outputDirectory)
            {
                // Create an MSBuild workspace
                MSBuildWorkspace workspace = MSBuildWorkspace.Create();

                // Load the solution
                Solution solution = workspace.OpenSolutionAsync(solutionPath).Result;

                // Iterate through each project in the solution
                foreach (Project project in solution.Projects)
                {
                    // Iterate through each document in the project
                    foreach (Document document in project.Documents)
                    {
                        // Get the syntax tree for the document
                        SyntaxTree syntaxTree = document.GetSyntaxTreeAsync().Result;

                        // Generate documentation for the syntax tree
                        GenerateDocumentationForSyntaxTree(syntaxTree, outputDirectory);
                    }
                }
            }

            /// <summary>
            /// Generates documentation for methods in a syntax tree and saves it to files.
            /// </summary>
            /// <param name="syntaxTree">Syntax tree representing the code.</param>
            /// <param name="outputDirectory">Path to the directory where documentation files will be saved.</param>
            private static void GenerateDocumentationForSyntaxTree(SyntaxTree syntaxTree, string outputDirectory)
            {
                // Get the root of the syntax tree
                var root = syntaxTree.GetRoot();

                // Extract all method declarations from the syntax tree
                var methods = root.DescendantNodes().OfType<MethodDeclarationSyntax>();

                // Iterate through each method
                foreach (var method in methods)
                {
                    // Generate documentation for each method
                    var documentation = GenerateMethodDocumentation(method);

                    // Save documentation to a file
                    var fileName = $"{method.Identifier.ValueText}_Documentation.txt";
                    var filePath = Path.Combine(outputDirectory, fileName);

                    File.WriteAllText(filePath, documentation);
                }
            }

            /// <summary>
            /// Generates documentation for a method.
            /// </summary>
            /// <param name="method">Method declaration syntax node.</param>
            /// <returns>Documentation text for the method.</returns>
            private static string GenerateMethodDocumentation(MethodDeclarationSyntax method)
            {
                // Extract method name and parameters for documentation
                var methodName = method.Identifier.ValueText;
                var parameters = method.ParameterList.Parameters.Select(p => p.Identifier.ValueText);

                // Generate documentation text
                var documentation = $"### {methodName}\n\n";
                documentation += $"**Parameters:** {string.Join(", ", parameters)}\n\n";
                documentation += "Add detailed description of the method here.";

                return documentation;
            }
        }
    }
}

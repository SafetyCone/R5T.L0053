using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.L0053.Implementations
{
    [FunctionalityMarker]
    public partial interface IDocumentationFilePathOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Get all XML documentation files in the executable directory assuming all XML files are documentation files.
        /// </summary>
        public IEnumerable<string> Enumerate_DocumentationFilePaths_AssumeAllXmls(
            string directoryPath)
        {
            return Instances.FileSystemOperator.Enumerate_DllFiles(directoryPath);
        }

        /// <summary>
        /// Get all XML documentation files in the executable directory assuming all XML files are documentation files.
        /// </summary>
        public IEnumerable<string> Enumerate_DocumentationFilePaths_AssemblyPaired(
            string directoryPath)
        {
            var assemblyFilePaths = Instances.AssemblyFilePathOperator.Enumerate_AssemblyFilePaths(directoryPath);

            var allXmlFilePaths = this.Enumerate_DocumentationFilePaths_AssumeAllXmls(directoryPath);

            // Now which of the XML file paths are paired with an assembly file path?
            var exepectedAssemblyDocumentationFilePaths = assemblyFilePaths
                .Select(assemblyFilePath => Instances.DocumentationFilePathOperator.Get_DocumentationFilePath_ForAssemblyFilePath(
                    assemblyFilePath))
                ;

            var pairedDocumentationFilePaths = allXmlFilePaths
                .Intersect(exepectedAssemblyDocumentationFilePaths)
                ;

            return pairedDocumentationFilePaths;
        }

        /// <inheritdoc cref="Enumerate_DocumentationFilePaths_AssemblyPaired(string)"/>
        public string[] Get_DocumentationFilePaths_AssemblyPaired(
            string directoryPath)
        {
            var output = this.Enumerate_DocumentationFilePaths_AssemblyPaired(directoryPath)
                .ToArray();

            return output;
        }
    }
}

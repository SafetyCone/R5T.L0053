using System;
using System.Collections.Generic;

using R5T.T0132;


namespace R5T.L0053.Implementations
{
    [FunctionalityMarker]
    public partial interface IAssemblyFilePathOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Get all DLL assembly files in the directory assuming all DLL files are assembly files.
        /// </summary>
        public IEnumerable<string> Enumerate_AssemblyFilePaths_AssumeAllDlls(string directoryPath)
        {
            return Instances.FileSystemOperator.Enumerate_DllFiles(directoryPath);
        }
    }
}

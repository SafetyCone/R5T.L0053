using System;
using System.Collections.Generic;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IAssemblyFilePathOperator : IFunctionalityMarker
    {
        private static Implementations.IAssemblyFilePathOperator Implementations => L0053.Implementations.AssemblyFilePathOperator.Instance;


        /// <inheritdoc cref="Implementations.IAssemblyFilePathOperator.Enumerate_AssemblyFilePaths_AssumeAllDlls(string)"/>
        public IEnumerable<string> Enumerate_AssemblyFilePaths(string directoryPath)
        {
            return Implementations.Enumerate_AssemblyFilePaths_AssumeAllDlls(directoryPath);
        }

        public string Get_AssemblyName(string assemblyFilePath)
        {
            var fileName = Instances.PathOperator.Get_FileName(assemblyFilePath);

            var output = Instances.AssemblyFileNameOperator.Get_AssemblyName(fileName);
            return output;
        }
    }
}

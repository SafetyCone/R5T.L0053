using System;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IAssemblyFileOperator : IFunctionalityMarker
    {
        /// <inheritdoc cref="IAssemblyFilePathOperator.Get_AssemblyFilePaths_InAssemblyDirectory(string)"/>
        public string[] Get_AssemblyFilePaths_InAssemblyDirectory(string assemblyFilePath)
        {
            return Instances.AssemblyFilePathOperator.Get_AssemblyFilePaths_InAssemblyDirectory(assemblyFilePath);
        }
    }
}

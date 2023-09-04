using System;
using System.Reflection;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IAssemblyOperator : IFunctionalityMarker
    {
        public AssemblyName Get_AssemblyName(string assemblyFilePath)
        {
            var output = AssemblyName.GetAssemblyName(assemblyFilePath);
            return output;
        }

        public string Get_FullAssemblyName(AssemblyName assemblyName)
        {
            return assemblyName.FullName;
        }

        public string Get_FullAssemblyName(string assemblyFilePath)
        {
            var assemblyName = this.Get_AssemblyName(assemblyFilePath);

            var output = this.Get_FullAssemblyName(assemblyName);
            return output;
        }

        public string Get_AssemblyNameValue(AssemblyName assemblyName)
        {
            var output = assemblyName.FullName;
            return output;
        }

        public string Get_AssemblyNameValue(string assemblyFilePath)
        {
            var assemblyName = this.Get_AssemblyName(assemblyFilePath);

            var output = this.Get_AssemblyNameValue(assemblyName);
            return output;
        }
    }
}

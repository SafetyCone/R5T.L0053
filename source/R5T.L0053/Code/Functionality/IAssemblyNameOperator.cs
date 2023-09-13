using System;
using System.Reflection;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IAssemblyNameOperator : IFunctionalityMarker
    {
        public AssemblyName Get_AssemblyName(string assemblyFilePath)
        {
            var output = AssemblyName.GetAssemblyName(assemblyFilePath);
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

        public string Get_FullAssemblyName(AssemblyName assemblyName)
        {
            return assemblyName.FullName;
        }

        /// <summary>
        /// Gets the full assembly name (e.g. "R5T.T0213, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null").
        /// </summary>
        public string Get_FullAssemblyName(
            string assemblyName,
            string version,
            string culture,
            string publicKeyToken)
        {
            var output = $"{assemblyName}, Version={version}, Culture={culture}, PublicKeyToken={publicKeyToken}";
            return output;
        }

        public string Get_FullAssemblyName(string assemblyFilePath)
        {
            var assemblyName = this.Get_AssemblyName(assemblyFilePath);

            var output = this.Get_FullAssemblyName(assemblyName);
            return output;
        }
    }
}

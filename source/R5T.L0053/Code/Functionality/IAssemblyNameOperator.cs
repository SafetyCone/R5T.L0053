using System;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IAssemblyNameOperator : IFunctionalityMarker
    {
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
            var output = Instances.AssemblyOperator.Get_FullAssemblyName(assemblyFilePath);
            return output;
        }
    }
}

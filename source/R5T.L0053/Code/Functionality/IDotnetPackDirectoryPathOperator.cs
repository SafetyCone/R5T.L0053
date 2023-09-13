using System;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IDotnetPackDirectoryPathOperator : IFunctionalityMarker
    {
        public string Get_DotnetPackDirectoryPath(
            string dotnetPackName,
            Version dotnetVersion,
            string targetFrameworkMoniker)
        {
            throw new NotImplementedException();
        }
    }
}

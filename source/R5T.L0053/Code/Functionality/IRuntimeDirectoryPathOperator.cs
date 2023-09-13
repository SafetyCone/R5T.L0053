using System;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IRuntimeDirectoryPathOperator : IFunctionalityMarker
    {
        public string Get_RuntimeDirectoryName(string runtimeName)
        {
            // The runtime directory name is just the runtime name.
            var output = runtimeName;
            return output;
        }

        public string Get_RuntimeDirectoryPath(
            string runtimeName,
            Version runtimeVersion)
        {
            var runtimeDirectoryName = this.Get_RuntimeDirectoryName(runtimeName);

            var versionDirectoryName = Instances.DirectoryNameOperator.Get_DirectoryName(runtimeVersion);

            var output = Instances.PathOperator.Get_DirectoryPath(
                Instances.Paths.DotnetSharedDirectoryPath,
                runtimeDirectoryName,
                versionDirectoryName);

            return output;
        }
    }
}

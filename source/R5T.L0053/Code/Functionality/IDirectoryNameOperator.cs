using System;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IDirectoryNameOperator : IFunctionalityMarker,
        L0066.IDirectoryNameOperator
    {
        /// <summary>
        /// Chooses <see cref="Get_DirectoryName_Standard(Version)"/> as the default.
        /// </summary>
        public string Get_DirectoryName(Version version)
        {
            var output = this.Get_DirectoryName_Standard(version);
            return output;
        }

        /// <summary>
        /// Provides the standard directory name.
        /// The standard is Major.Minor.Build.
        /// </summary>
        public string Get_DirectoryName_Standard(Version version)
        {
            var output = Instances.VersionOperator.ToString_Major_Minor_Build(version);
            return output;
        }
    }
}

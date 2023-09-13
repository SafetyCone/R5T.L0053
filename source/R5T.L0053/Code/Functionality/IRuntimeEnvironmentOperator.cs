using System;
using System.Linq;
using System.Runtime.InteropServices;

using R5T.T0132;

using R5T.L0053.Extensions;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IRuntimeEnvironmentOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Returns the path of the core assembly for the currently executing runtime.
        /// </summary>
        public string[] Get_CurrentlyExecutingRuntime_AssemblyFilePaths()
        {
            var runtimeDirectoryPath = this.Get_RuntimeDirectoryPath();

            var output = Instances.AssemblyFilePathOperator.Get_AssemblyFilePaths(runtimeDirectoryPath);
            return output;
        }

        /// <summary>
        /// Returns the path of the core assembly for the currently executing runtime.
        /// (Example: <inheritdoc cref="Y0000.Documentation.Example_CoreAssemblyFilePath" path="/summary"/>
        /// </summary>
        public string Get_CurrentlyExecutingRuntime_CoreAssemblyFilePath()
        {
            // "C:\Program Files\dotnet\shared\Microsoft.NETCore.App\6.0.21\System.Private.CoreLib.dll"
            var assemblyFilePath = typeof(string).Assembly.Location;

            return assemblyFilePath;
        }

        /// <summary>
        /// Gets the currently executing runtime name. (Example: <inheritdoc cref="Y0000.Documentation.Example_RuntimeName" path="/summary"/>)
        /// </summary>
        /// <remarks>
        /// Using the currently executing runtime, get the runtime name from the runtime directory path.
        /// </remarks>
        public string Get_CurrentlyExecutingRuntimeName()
        {
            // C:\Program Files\dotnet\shared\Microsoft.NETCore.App\6.0.21\
            var runtimeDirectoryPath = Instances.RuntimeEnvironmentOperator.Get_RuntimeDirectoryPath();

            var pathParts = Instances.PathOperator.Get_DirectoryPathParts(runtimeDirectoryPath);

            var output = pathParts.SecondFromEnd();
            return output;
        }

        /// <summary>
        /// Gets the currently executing runtime version. (Example: <inheritdoc cref="Y0000.Documentation.Example_RuntimeVersion" path="/summary"/>)
        /// </summary>
        /// <remarks>
        /// Using the currently executing runtime, get the runtime version from the runtime directory path.
        /// </remarks>
        public string Get_CurrentlyExecutingRuntimeVersion_String()
        {
            // C:\Program Files\dotnet\shared\Microsoft.NETCore.App\6.0.21\
            var runtimeDirectoryPath = Instances.RuntimeEnvironmentOperator.Get_RuntimeDirectoryPath();

            var pathParts = Instances.PathOperator.Get_DirectoryPathParts(runtimeDirectoryPath);

            var output = pathParts.Last();
            return output;
        }

        public Version Get_CurrentlyExecutingRuntimeVersion()
        {
            var versionString = this.Get_CurrentlyExecutingRuntimeVersion_String();

            var output = Instances.VersionOperator.Parse(versionString);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="RuntimeEnvironment.GetRuntimeDirectory" path="/summary"/>
        /// <para>Example: <inheritdoc cref="Y0000.Documentation.Example_RuntimeDirectoryPath" path="/summary"/></para>
        /// </summary>
        public string Get_RuntimeDirectoryPath()
        {
            var output = RuntimeEnvironment.GetRuntimeDirectory();
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="RuntimeEnvironment.GetSystemVersion" path="/summary"/>
        /// <para>Example: v4.0.30319</para>
        /// </summary>
        public string Get_CommonLanguageRuntimeVersion_String()
        {
            var output = RuntimeEnvironment.GetSystemVersion();
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Get_CommonLanguageRuntimeVersion_String" path="/summary"/>
        /// </summary>
        public Version Get_CommonLanguageRuntimeVersion()
        {
            var versionString = this.Get_CommonLanguageRuntimeVersion_String();

            var output = Instances.VersionOperator.Parse(versionString);
            return output;
        }
    }
}

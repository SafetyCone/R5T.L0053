using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IAssemblyFilePathOperator : IFunctionalityMarker
    {
        private static Implementations.IAssemblyFilePathOperator Implementations => L0053.Implementations.AssemblyFilePathOperator.Instance;


        public IEnumerable<string> Enumerate_AssemblyFilePaths(IEnumerable<string> directoryPaths)
        {
            var output = directoryPaths
                .SelectMany(directoryPath => this.Enumerate_AssemblyFilePaths(directoryPath))
                ;

            return output;
        }

        public IEnumerable<string> Enumerate_AssemblyFilePaths(params string[] directoryPaths)
        {
            return this.Get_AssemblyFilePaths(directoryPaths.AsEnumerable());
        }

        /// <summary>
        /// Enumerate all assembly files that are in the same directory as a given assembly file.
        /// </summary>
        public IEnumerable<string> Enumerate_AssemblyFilePaths_InAssemblyDirectory(string assemblyFilePath)
        {
            var assemblyDirectoryPath = this.Get_AssemblyDirectoryPath(assemblyFilePath);

            var output = this.Enumerate_AssemblyFilePaths(assemblyDirectoryPath);
            return output;
        }

        /// <inheritdoc cref="Implementations.IAssemblyFilePathOperator.Enumerate_AssemblyFilePaths_AssumeAllDlls(string)"/>
        public IEnumerable<string> Enumerate_AssemblyFilePaths(string directoryPath)
        {
            return Implementations.Enumerate_AssemblyFilePaths_AssumeAllDlls(directoryPath);
        }

        public string Get_AssemblyDirectoryPath(string assemblyFilePath)
        {
            var output = Instances.PathOperator.Get_ParentDirectoryPath_ForFile(assemblyFilePath);
            return output;
        }

        public string[] Get_AssemblyFilePaths(string directoryPath)
        {
            var output = this.Enumerate_AssemblyFilePaths(directoryPath)
                .Now();

            return output;
        }

        public string[] Get_AssemblyFilePaths(IEnumerable<string> directoryPaths)
        {
            var output = this.Enumerate_AssemblyFilePaths(directoryPaths)
                .Now();

            return output;
        }

        public string[] Get_AssemblyFilePaths(params string[] directoryPaths)
        {
            return this.Get_AssemblyFilePaths(directoryPaths.AsEnumerable());
        }

        /// <summary>
        /// Get all assembly files that are in the same directory as a given assembly file.
        /// </summary>
        public string[] Get_AssemblyFilePaths_InAssemblyDirectory(string assemblyFilePath)
        {
            var output = this.Enumerate_AssemblyFilePaths_InAssemblyDirectory(assemblyFilePath)
                .Now();

            return output;
        }

        public string Get_AssemblyName(string assemblyFilePath)
        {
            var fileName = Instances.PathOperator.Get_FileName(assemblyFilePath);

            var output = Instances.AssemblyFileNameOperator.Get_AssemblyName(fileName);
            return output;
        }

        /// <summary>
        /// Returns all assembly file paths in both the assembly file's directory and the runtime directory
        /// (these are the assembly's dependency file paths).
        /// Inclusive in the sense that the specified assembly file is included in the output.
        /// </summary>
        public string[] Get_AllDependencyAssemblyFilePaths_Inclusive(
            string assemblyFilePath,
            string runtimeDirectoryPath)
        {
            var assemblyDirectoryPath = this.Get_AssemblyDirectoryPath(assemblyFilePath);

            var output = this.Get_AssemblyFilePaths(
                assemblyDirectoryPath,
                runtimeDirectoryPath);

            return output;
        }

        public IEnumerable<string> Enumerate_DistinctAssemblies(IEnumerable<string> assemblyFilePaths)
        {
            var output = assemblyFilePaths
                // Only deal with distinct file paths.
                .Distinct()
                // Group by file name.
                .GroupBy(assemblyFilePath => Instances.PathOperator.Get_FileName(assemblyFilePath))
                // For each grouping, only return the first.
                .Select(group => group.First())
                //// Now get the full assembly name of each.
                //.Select(assemblyFilePath =>
                //{
                //    // For some assemblies (like in the runtime directory)
                //    var fullAssemblyName = Instances.AssemblyOperator.Get_FullAssemblyName(assemblyFilePath);

                //    return (fullAssemblyName, assemblyFilePath);
                //})
                //// Get distinct assemblies by their full assembly name.
                //.Distinct(
                //    (x, y) => x.fullAssemblyName == y.fullAssemblyName,
                //    x => x.fullAssemblyName.GetHashCode())
                //// Just return the assembly file path, not the full assembly name.
                //.Select(x => x.assemblyFilePath)
                ;

            return output;
        }

        /// <inheritdoc cref="Get_AllDependencyAssemblyFilePaths_Inclusive(string, string)"/>
        public string[] Get_AllDependencyAssemblyFilePaths_Inclusive(
            string assemblyFilePath,
            bool includeRuntimeDirectory = true)
        {
            if(includeRuntimeDirectory)
            {
                var runtimeDirectoryPath = Instances.RuntimeEnvironmentOperator.Get_RuntimeDirectoryPath();

                var output = this.Get_AllDependencyAssemblyFilePaths_Inclusive(
                    assemblyFilePath,
                    runtimeDirectoryPath);

                return output;
            }
            else
            {
                var assemblyDirectoryPath = this.Get_AssemblyDirectoryPath(assemblyFilePath);

                var output = this.Get_AssemblyFilePaths(assemblyDirectoryPath);
                return output;
            }
        }

        /// <summary>
        /// Returns only the distinct assembly files.
        /// </summary>
        public string[] Get_DependencyAssemblyFilePaths_Inclusive(
            string assemblyFilePath,
            bool includeRuntimeDirectory = true)
        {
            var allAssemblyFilePaths = this.Get_AllDependencyAssemblyFilePaths_Inclusive(
                assemblyFilePath,
                includeRuntimeDirectory);

            var output = this.Get_DistinctAssemblies(allAssemblyFilePaths);
            return output;
        }

        /// <inheritdoc cref="Get_AllDependencyAssemblyFilePaths_Inclusive(string, string)"/>
        public string[] Get_DependencyAssemblyFilePaths_ForDotnetPack_Inclusive(
            string assemblyFilePath,
            string dotnetPackName,
            Version runtimeVersion,
            string targetFrameworkMoniker)
        {
            var dotnetPackDirectoryPath = Instances.DotnetPackDirectoryPathOperator.Get_DotnetPackDirectoryPath(
                dotnetPackName,
                runtimeVersion,
                targetFrameworkMoniker);

            var output = this.Get_AllDependencyAssemblyFilePaths_Inclusive(
                assemblyFilePath,
                dotnetPackDirectoryPath);

            return output;
        }

        public string[] Get_DependencyAssemblyFilePaths_ForRuntime_Inclusive(
            string assemblyFilePath,
            string runtimeName,
            Version runtimeVersion)
        {
            var runtimeDirectoryPath = Instances.RuntimeDirectoryPathOperator.Get_RuntimeDirectoryPath(
                runtimeName,
                runtimeVersion);

            var output = this.Get_AllDependencyAssemblyFilePaths_Inclusive(
                assemblyFilePath,
                runtimeDirectoryPath);

            return output;
        }

        public string[] Get_DistinctAssemblies(IEnumerable<string> assemblyFilePaths)
        {
            var output = this.Enumerate_DistinctAssemblies(assemblyFilePaths)
                .Now();

            return output;
        }
    }
}

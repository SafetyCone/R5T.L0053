using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.L0053.N000
{
    /// <summary>
    /// General utility operator, with functions independent of particular file extensions.
    /// </summary>
    [FunctionalityMarker]
    public partial interface IFileSystemOperator : IFunctionalityMarker
    {
        /// <summary>
        /// <inheritdoc cref="Y0000.Documentation.Clearing_File" path="/summary"/>
        /// </summary>
        public async Task Clear_File(string filePath)
        {
            await File.WriteAllTextAsync(
                filePath,
                Instances.Strings.Empty);
        }

        /// <summary>
        /// <inheritdoc cref="Y0000.Documentation.Clearing_File" path="/summary"/>
        /// </summary>
        public void Clear_File_Synchronous(string filePath)
        {
            File.WriteAllText(
                filePath,
                Instances.Strings.Empty);
        }

        /// <summary>
        /// Copies a directory.
        /// </summary>
        /// <remarks>
        /// It is BONKERS that C# does not have a built-in implementation of copying directories. Wut?!?
        /// </remarks>
        public void Copy_Directory(
            string sourceDirectoryPath,
            string destinationDirectoryPath,
            bool recursive = true)
        {
            /// Adapted from: https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories

            // Get information about the source directory
            var directory = new DirectoryInfo(sourceDirectoryPath);

            // Check if the source directory exists
            if (!directory.Exists)
            {
                throw new DirectoryNotFoundException($"Source directory not found: {directory.FullName}");
            }

            // Cache directories before we start copying.
            DirectoryInfo[] subDirectories = directory.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDirectoryPath);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in directory.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDirectoryPath, file.Name);
                file.CopyTo(targetFilePath);
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDirectory in subDirectories)
                {
                    string newDestinationDirectoryPath = Path.Combine(destinationDirectoryPath, subDirectory.Name);

                    this.Copy_Directory(subDirectory.FullName, newDestinationDirectoryPath, true);
                }
            }
        }

        /// <summary>
        /// Enumerates child directories in the directory (not including in any sub-directories).
        /// </summary>
        public IEnumerable<string> Enumerate_ChildDirectoryPaths(
            string directoryPath)
        {
            var output = Directory.EnumerateDirectories(directoryPath);
            return output;
        }

        /// <inheritdoc cref="Enumerate_ChildDirectoryPaths(string)"/>
        public IEnumerable<string> Enumerate_ChildDirectoryPaths(
            string directoryPath,
            string searchPattern)
        {
            var output = Directory.EnumerateDirectories(
                directoryPath,
                searchPattern);

            return output;
        }

        /// <summary>
        /// Enumerates child files in the directory and any sub-directories.
        /// </summary>
        public IEnumerable<string> Enumerate_DescendantFilePaths(string directoryPath)
        {
            var output = Directory.EnumerateFiles(
                directoryPath,
                Instances.SearchPatterns.All,
                SearchOption.AllDirectories);

            return output;
        }

        /// <inheritdoc cref="Enumerate_DescendantFilePaths(string)"/>
        public IEnumerable<string> Enumerate_DescendantFilePaths(
            string directoryPath,
            string searchPattern)
        {
            var output = Directory.EnumerateFiles(
                directoryPath,
                searchPattern,
                SearchOption.AllDirectories);

            return output;
        }

        public void Make_ReadOnly(string filePath)
        {
            var fileAttributes = File.GetAttributes(filePath);

            fileAttributes |= FileAttributes.ReadOnly;

            File.SetAttributes(
                filePath,
                fileAttributes);
        }
    }
}

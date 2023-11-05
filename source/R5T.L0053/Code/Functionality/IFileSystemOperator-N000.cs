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
        /// Chooses <see cref="Copy_File_OverwriteAllowed(string, string)"/> as the default.
        /// </summary>
        public void Copy_File(
            string sourceFilePath,
            string destinationFilePath)
        {
            this.Copy_File_OverwriteAllowed(
                sourceFilePath,
                destinationFilePath);
        }

        public void Copy_File_OverwriteAllowed(
            string sourceFilePath,
            string destinationFilePath)
        {
            File.Copy(
                sourceFilePath,
                destinationFilePath,
                true);
        }

        public void Copy_File_OverwriteForbidden(
            string sourceFilePath,
            string destinationFilePath)
        {
            File.Copy(
                sourceFilePath,
                destinationFilePath,
                false);
        }

        /// <summary>
        /// Creates a directory idempotently (meaning there is no problem with issuing the command multiple times). 
        /// Note: The system method <see cref="Directory.CreateDirectory(string)"/> does not throw an exception if you create a directory that already exists. However, it's hard to remember this fact. Thus, this method name makes that fact explicit.
        /// </summary>
        public void Create_Directory_OkIfAlreadyExists(string directoryPath)
        {
            // Does not throw an exception if a directory already exists.
            // See proof at: https://github.com/MinexAutomation/Public/blob/a8c302415b56fb8903c751436cbeef3eae8e1692/Source/Experiments/CSharp/ExaminingCSharp/ExaminingCSharp/Code/Experiments/IOExperiments.cs#L24
            Directory.CreateDirectory(directoryPath);
        }

        public void Ensure_DirectoryExists_ForFilePath(string filePath)
        {
            var directoryPath = PathOperator.Instance.Get_ParentDirectoryPath_ForFile(filePath);

            this.Create_Directory_OkIfAlreadyExists(directoryPath);
        }

        /// <summary>
        /// Enumerates files in the directory (not including in any sub-directories).
        /// </summary>
        public IEnumerable<string> Enumerate_FilePaths(string directoryPath)
        {
            return this.Enumerate_ChildFilePaths(directoryPath);
        }

        /// <summary>
        /// Enumerates files in the directory (not including in any sub-directories).
        /// </summary>
        public IEnumerable<string> Enumerate_FilePaths_ByFileExtension(
            string directoryPath,
            string fileExtension)
        {
            return this.Enumerate_ChildFilePaths_ByFileExtension(
                directoryPath,
                fileExtension);
        }

        public bool Exists_File(string filePath)
        {
            var output = File.Exists(filePath);
            return output;
        }

        public Func<string, IEnumerable<string>> Get_Enumerate_FilePaths_ByFileExtension(string fileExtension)
        {
            return directoryPath => this.Enumerate_ChildFilePaths_ByFileExtension(
                directoryPath,
                fileExtension);
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
        /// Enumerates child files in the directory (not including in any sub-directories).
        /// </summary>
        public IEnumerable<string> Enumerate_ChildFilePaths(string directoryPath)
        {
            var output = Directory.EnumerateFiles(directoryPath);
            return output;
        }

        /// <inheritdoc cref="Enumerate_ChildFilePaths(string)"/>
        public IEnumerable<string> Enumerate_ChildFilePaths(
            string directoryPath,
            string searchPattern)
        {
            var output = Directory.EnumerateFiles(
                directoryPath,
                searchPattern);

            return output;
        }

        /// <inheritdoc cref="Enumerate_ChildFilePaths(string)"/>
        public IEnumerable<string> Enumerate_ChildFilePaths_ByFileExtension(
            string directoryPath,
            string fileExtension)
        {
            var searchPattern = Instances.SearchPatternGenerator.Files_WithExtension(fileExtension);

            return this.Enumerate_ChildFilePaths(
                directoryPath,
                searchPattern);
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

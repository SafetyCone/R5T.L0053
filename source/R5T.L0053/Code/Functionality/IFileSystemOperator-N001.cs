using System;
using System.Collections.Generic;

using R5T.T0132;


namespace R5T.L0053.N001
{
    /// <summary>
    /// File-extension specific file system operator.
    /// </summary>
    [FunctionalityMarker]
    public partial interface IFileSystemOperator : IFunctionalityMarker
    {
        private static N000.IFileSystemOperator N000 => L0053.N000.FileSystemOperator.Instance;


        /// <inheritdoc cref="Enumerate_ChildDllFiles"/>
        public IEnumerable<string> Enumerate_DllFiles(string directoryPath)
        {
            return this.Enumerate_ChildDllFiles(directoryPath);
        }

        /// <summary>
        /// Enumerates child DLL files in the directory.
        /// </summary>
        public IEnumerable<string> Enumerate_ChildDllFiles(string directoryPath)
        {
            return N000.Enumerate_ChildFilePaths_ByFileExtension(
                directoryPath,
                Instances.FileExtensions.Dll);
        }

        /// <inheritdoc cref="Enumerate_ChildTextFiles"/>
        public IEnumerable<string> Enumerate_TextFiles(string directoryPath)
        {
            return this.Enumerate_ChildTextFiles(directoryPath);
        }

        /// <summary>
        /// Enumerates child text files in the directory.
        /// </summary>
        public IEnumerable<string> Enumerate_ChildTextFiles(string directoryPath)
        {
            return N000.Enumerate_ChildFilePaths_ByFileExtension(
                directoryPath,
                Instances.FileExtensions.Text);
        }

        /// <inheritdoc cref="Enumerate_ChildXmlFiles"/>
        public IEnumerable<string> Enumerate_XmlFiles(string directoryPath)
        {
            return this.Enumerate_ChildXmlFiles(directoryPath);
        }

        /// <summary>
        /// Enumerates child XML files in the directory.
        /// </summary>
        public IEnumerable<string> Enumerate_ChildXmlFiles(string directoryPath)
        {
            return N000.Enumerate_ChildFilePaths_ByFileExtension(
                directoryPath,
                Instances.FileExtensions.Xml);
        }
    }
}

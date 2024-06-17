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

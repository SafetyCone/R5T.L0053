using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IPathOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public Internal.IPathOperator _Internal => Internal.PathOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public char Detect_DirectorySeparator(
            string path,
            char defaultDirectorySeparator)
        {
            var directorySeparators = Instances.DirectorySeparators.Both;

            var indexOfFirstDirectorySeparatorOrNotFound = Instances.StringOperator.Get_IndexOfAny_OrNotFound(
                path,
                directorySeparators);

            var directorySeparatorFound = Instances.StringOperator.Is_Found(indexOfFirstDirectorySeparatorOrNotFound);

            var output = directorySeparatorFound
                ? Instances.StringOperator.Get_Character(
                    path,
                    indexOfFirstDirectorySeparatorOrNotFound)
                : defaultDirectorySeparator
                ;

            return output;
        }

        public string Combine(params string[] pathParts)
        {
            var output = Path.Combine(pathParts);
            return output;
        }

        public string Combine(IEnumerable<string> pathParts)
        {
            var pathPartsArray = pathParts.ToArray();

            var output = this.Combine(pathPartsArray);
            return output;
        }

        public char Detect_DirectorySeparator(string path)
        {
            return this.Detect_DirectorySeparator(
                path,
                Instances.DirectorySeparators.Standard);
        }

        public string Ensure_DirectoryIndicated(
            string directoryPath,
            char defaultDirectorySeparator)
        {
            var isDirectoryIndicated = this.Is_DirectoryIndicated(directoryPath);
            if(isDirectoryIndicated)
            {
                return directoryPath;
            }

            // Else.
            var directorySeparator = this.Detect_DirectorySeparator(
                directoryPath,
                defaultDirectorySeparator);

            var output = this._Internal.Make_DirectoryIndicated_Unchecked(
                directoryPath,
                directorySeparator);

            return output;
        }

        public string Ensure_DirectoryIndicated(string directoryPath)
        {
            return this.Ensure_DirectoryIndicated(
                directoryPath,
                Instances.DirectorySeparators.Standard);
        }

        /// <summary>
        /// Gets both directory separators.
        /// (<see cref="IDirectorySeparators.Both"/>)
        /// </summary>
        public char[] Get_DirectorySeparators()
        {
            return Instances.DirectorySeparators.Both;
        }

        public string Get_FileName(string filePath)
        {
            var output = new FileInfo(filePath).Name;
            return output;
        }

        public string Get_Path(
            string basePath,
            string path_BasePathRelative)
        {
            var output = Path.Combine(
                basePath,
                path_BasePathRelative);

            return output;
        }

        public string Get_DirectoryPath(IEnumerable<string> pathParts)
        {
            var combined = this.Combine(pathParts);

            var output = this.Ensure_DirectoryIndicated(combined);
            return output;
        }

        public string Get_DirectoryPath(params string[] pathParts)
        {
            return this.Get_DirectoryPath(pathParts.AsEnumerable());
        }

        public string[] Get_DirectoryPathParts(string directoryPath)
        {
            var directoryInfo = Instances.DirectoryInfoOperator.From(directoryPath);

            var output = Instances.DirectoryInfoOperator.Get_PathParts(directoryInfo);
            return output;
        }

        /// <summary>
        /// Gets the (directory-indicated) path of the directory containing a specified file.
        /// </summary>
        /// <returns>The directory-indicated directory path of the file's parent directory.</returns>
        /// <remarks>
        /// Uses the <see cref="FileInfo"/> class.
        /// </remarks>
        public string Get_ParentDirectoryPath_ForFile(string filePath)
        {
            var fileInfo = new FileInfo(filePath);

            var parentDirectoryPath = fileInfo.Directory.FullName;

            // Unchecked, since we know the directory full name is *not* directory indicated.
            var output = Instances.PathOperator._Internal.Make_DirectoryIndicated_Unchecked(parentDirectoryPath);
            return output;
        }

        /// <summary>
        /// Gets the directory path of the directory containing a specified directory.
        /// </summary>
        /// <returns>The non-directory indicated directory path of the file's parent directory.</returns>
        /// <remarks>
        /// Uses the <see cref="DirectoryInfo"/> class.
        /// </remarks>
        public string Get_ParentDirectoryPath_ForDirectory(string directoryPath)
        {
            var directoryInfo = new DirectoryInfo(directoryPath);

            var parentDirectoryPath = directoryInfo.Parent.FullName;
            return parentDirectoryPath;
        }

        /// <summary>
        /// Is the path directory indicated (ends with one of the two directory separator characters).
        /// </summary>
        public bool Is_DirectoryIndicated(string directoryPath)
        {
            var lastCharacter = Instances.StringOperator.Get_LastCharacter(directoryPath);

            // Is directory separator.
            var output = this.Is_DirectorySeparator(lastCharacter);
            return output;
        }

        /// <summary>
        /// Is the character one of the two directory separators?
        /// (<see cref="IDirectorySeparators.Both"/>)
        /// </summary>
        public bool Is_DirectorySeparator(char character)
        {
            var directorySeparators = this.Get_DirectorySeparators();

            var output = directorySeparators.Contains(character);
            return output;
        }

        /// <summary>
        /// Is the path file indicated (does <em>not</em> end with one of the two directory separator characters).
        /// </summary>
        public bool Is_FileIndicated(string filePath)
        {
            // File-indicated is the opposite of directory indicated.
            var isDirectoryIndicated = this.Is_DirectoryIndicated(filePath);

            var output = !isDirectoryIndicated;
            return output;
        }

        //public bool Make_DirectoryIndicated(
        //    string directoryPath,
        //    char directorySeparator)
        //{
        //    // Verify that the directory path is *not* directory indicated.

        //    // Verify that the directory separator *is* one of the valid directory separators.
        //}
    }
}

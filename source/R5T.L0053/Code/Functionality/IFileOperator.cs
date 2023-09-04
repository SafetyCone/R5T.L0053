using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IFileOperator : IFunctionalityMarker
    {
        public FileAttributes Get_FileAttributes(string filePath)
        {
            var output = File.GetAttributes(filePath);
            return output;
        }

        //public bool Is_ReadOnly(string filePath)
        //{
        //    var fileAttributes = this.Get_FileAttributes(filePath);

        //    var output = fileAttributes & FileAttributes.ReadOnly;
        //    return output;
        //}

        /// <summary>
        /// Writes the provided lines (and only the provided lines, with no trailing blank line) to a file.
        /// </summary>
        public Task Write_Lines(
            string textFilePath,
            IEnumerable<string> lines)
        {
            FileSystemOperator.Instance.Ensure_DirectoryExists_ForFilePath(textFilePath);

            var text = Instances.StringOperator.Join(
                Instances.Characters.NewLine,
                lines);

            return File.WriteAllTextAsync(
                textFilePath,
                text);
        }

        public Task<byte[]> Read_Bytes(string filePath)
        {
            var output = File.ReadAllBytesAsync(filePath);
            return output;
        }

        public byte[] Read_Bytes_Synchronous(string filePath)
        {
            var fileBytes = File.ReadAllBytes(filePath);
            return fileBytes;
        }

        /// <inheritdoc cref="Write_Lines(string, IEnumerable{string})"/>
        public void Write_Lines_Synchronous(
            string textFilePath,
            params string[] lines)
        {
            this.Write_Lines_Synchronous(
                textFilePath,
                lines.AsEnumerable());
        }

        /// <inheritdoc cref="Write_Lines(string, IEnumerable{string})"/>
        public void Write_Lines_Synchronous(
            string textFilePath,
            IEnumerable<string> lines)
        {
            Instances.FileSystemOperator.Ensure_DirectoryExists_ForFilePath(textFilePath);

            var text = Instances.StringOperator.Join(
                Instances.Characters.NewLine,
                lines);

            File.WriteAllText(
                textFilePath,
                text);
        }

        public void Write_Text_Synchronous(
            string textFilePath,
            string text)
        {
            Instances.FileSystemOperator.Ensure_DirectoryExists_ForFilePath(textFilePath);

            File.WriteAllText(
                textFilePath,
                text);
        }
    }
}

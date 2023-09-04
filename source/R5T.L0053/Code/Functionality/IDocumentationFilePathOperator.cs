using System;
using System.Collections.Generic;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IDocumentationFilePathOperator : IFunctionalityMarker
    {
        public string Get_DocumentationFilePath_ForAssemblyFilePath(string assemblyFilePath)
        {
            var assemblyFileName = Instances.PathOperator.Get_FileName(assemblyFilePath);
            var assemblyDirectoryPath = Instances.PathOperator.Get_ParentDirectoryPath_ForFile(assemblyFilePath);

            var documentationFileName = Instances.DocumentationFileNameOperator.Get_AssemblyDocumentationFileName_FromAssemblyFileName(
                assemblyFileName);

            var documentationFilePath = Instances.PathOperator.Get_Path(
                assemblyDirectoryPath,
                documentationFileName);

            return documentationFilePath;
        }
    }
}

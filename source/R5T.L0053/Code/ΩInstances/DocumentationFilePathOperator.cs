using System;


namespace R5T.L0053
{
    public class DocumentationFilePathOperator : IDocumentationFilePathOperator
    {
        #region Infrastructure

        public static IDocumentationFilePathOperator Instance { get; } = new DocumentationFilePathOperator();


        private DocumentationFilePathOperator()
        {
        }

        #endregion
    }
}


namespace R5T.L0053.Implementations
{
    public class DocumentationFilePathOperator : IDocumentationFilePathOperator
    {
        #region Infrastructure

        public static IDocumentationFilePathOperator Instance { get; } = new DocumentationFilePathOperator();


        private DocumentationFilePathOperator()
        {
        }

        #endregion
    }
}

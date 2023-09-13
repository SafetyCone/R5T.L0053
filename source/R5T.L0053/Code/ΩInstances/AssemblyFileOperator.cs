using System;


namespace R5T.L0053
{
    public class AssemblyFileOperator : IAssemblyFileOperator
    {
        #region Infrastructure

        public static IAssemblyFileOperator Instance { get; } = new AssemblyFileOperator();


        private AssemblyFileOperator()
        {
        }

        #endregion
    }
}

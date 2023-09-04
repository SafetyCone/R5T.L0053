using System;


namespace R5T.L0053
{
    public class AssemblyFileNameOperator : IAssemblyFileNameOperator
    {
        #region Infrastructure

        public static IAssemblyFileNameOperator Instance { get; } = new AssemblyFileNameOperator();


        private AssemblyFileNameOperator()
        {
        }

        #endregion
    }
}

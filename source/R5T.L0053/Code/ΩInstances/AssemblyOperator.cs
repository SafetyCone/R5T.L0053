using System;


namespace R5T.L0053
{
    public class AssemblyOperator : IAssemblyOperator
    {
        #region Infrastructure

        public static IAssemblyOperator Instance { get; } = new AssemblyOperator();


        private AssemblyOperator()
        {
        }

        #endregion
    }
}

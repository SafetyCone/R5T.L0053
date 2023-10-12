using System;


namespace R5T.L0053
{
    public class MethodBaseOperator : IMethodBaseOperator
    {
        #region Infrastructure

        public static IMethodBaseOperator Instance { get; } = new MethodBaseOperator();


        private MethodBaseOperator()
        {
        }

        #endregion
    }
}

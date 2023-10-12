using System;


namespace R5T.L0053
{
    public class MethodNameOperator : IMethodNameOperator
    {
        #region Infrastructure

        public static IMethodNameOperator Instance { get; } = new MethodNameOperator();


        private MethodNameOperator()
        {
        }

        #endregion
    }
}

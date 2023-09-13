using System;


namespace R5T.L0053
{
    public class MethodInfoOperator : IMethodInfoOperator
    {
        #region Infrastructure

        public static IMethodInfoOperator Instance { get; } = new MethodInfoOperator();


        private MethodInfoOperator()
        {
        }

        #endregion
    }
}

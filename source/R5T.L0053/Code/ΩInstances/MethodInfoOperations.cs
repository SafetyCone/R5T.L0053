using System;


namespace R5T.L0053
{
    public class MethodInfoOperations : IMethodInfoOperations
    {
        #region Infrastructure

        public static IMethodInfoOperations Instance { get; } = new MethodInfoOperations();


        private MethodInfoOperations()
        {
        }

        #endregion
    }
}

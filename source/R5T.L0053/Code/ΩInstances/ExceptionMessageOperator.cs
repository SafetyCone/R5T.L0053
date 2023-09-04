using System;


namespace R5T.L0053
{
    public class ExceptionMessageOperator : IExceptionMessageOperator
    {
        #region Infrastructure

        public static IExceptionMessageOperator Instance { get; } = new ExceptionMessageOperator();


        private ExceptionMessageOperator()
        {
        }

        #endregion
    }
}

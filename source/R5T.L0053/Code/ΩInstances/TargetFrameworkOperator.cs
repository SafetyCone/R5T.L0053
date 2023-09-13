using System;


namespace R5T.L0053
{
    public class TargetFrameworkOperator : ITargetFrameworkOperator
    {
        #region Infrastructure

        public static ITargetFrameworkOperator Instance { get; } = new TargetFrameworkOperator();


        private TargetFrameworkOperator()
        {
        }

        #endregion
    }
}

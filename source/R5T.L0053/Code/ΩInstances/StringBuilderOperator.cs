using System;


namespace R5T.L0053
{
    public class StringBuilderOperator : IStringBuilderOperator
    {
        #region Infrastructure

        public static IStringBuilderOperator Instance { get; } = new StringBuilderOperator();


        private StringBuilderOperator()
        {
        }

        #endregion
    }
}

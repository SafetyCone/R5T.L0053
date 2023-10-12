using System;


namespace R5T.L0053
{
    public class ValueOperator : IValueOperator
    {
        #region Infrastructure

        public static IValueOperator Instance { get; } = new ValueOperator();


        private ValueOperator()
        {
        }

        #endregion
    }
}

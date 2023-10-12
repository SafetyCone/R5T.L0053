using System;


namespace R5T.L0053
{
    public class RangeOperator : IRangeOperator
    {
        #region Infrastructure

        public static IRangeOperator Instance { get; } = new RangeOperator();


        private RangeOperator()
        {
        }

        #endregion
    }
}

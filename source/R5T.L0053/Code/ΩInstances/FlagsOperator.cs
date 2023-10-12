using System;


namespace R5T.L0053
{
    public class FlagsOperator : IFlagsOperator
    {
        #region Infrastructure

        public static IFlagsOperator Instance { get; } = new FlagsOperator();


        private FlagsOperator()
        {
        }

        #endregion
    }
}

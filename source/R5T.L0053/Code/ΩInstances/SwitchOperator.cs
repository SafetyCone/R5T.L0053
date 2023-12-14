using System;


namespace R5T.L0053
{
    public class SwitchOperator : ISwitchOperator
    {
        #region Infrastructure

        public static ISwitchOperator Instance { get; } = new SwitchOperator();


        private SwitchOperator()
        {
        }

        #endregion
    }
}

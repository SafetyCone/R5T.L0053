using System;


namespace R5T.L0053
{
    public class ActionOperator : IActionOperator
    {
        #region Infrastructure

        public static IActionOperator Instance { get; } = new ActionOperator();


        private ActionOperator()
        {
        }

        #endregion
    }
}

using System;


namespace R5T.L0053
{
    public class EventInfoOperator : IEventInfoOperator
    {
        #region Infrastructure

        public static IEventInfoOperator Instance { get; } = new EventInfoOperator();


        private EventInfoOperator()
        {
        }

        #endregion
    }
}

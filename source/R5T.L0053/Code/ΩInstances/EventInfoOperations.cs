using System;


namespace R5T.L0053
{
    public class EventInfoOperations : IEventInfoOperations
    {
        #region Infrastructure

        public static IEventInfoOperations Instance { get; } = new EventInfoOperations();


        private EventInfoOperations()
        {
        }

        #endregion
    }
}

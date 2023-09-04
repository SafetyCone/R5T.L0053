using System;


namespace R5T.L0053
{
    public class Messages : IMessages
    {
        #region Infrastructure

        public static IMessages Instance { get; } = new Messages();


        private Messages()
        {
        }

        #endregion
    }
}

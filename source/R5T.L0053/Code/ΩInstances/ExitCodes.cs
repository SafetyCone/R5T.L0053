using System;


namespace R5T.L0053
{
    public class ExitCodes : IExitCodes
    {
        #region Infrastructure

        public static IExitCodes Instance { get; } = new ExitCodes();


        private ExitCodes()
        {
        }

        #endregion
    }
}

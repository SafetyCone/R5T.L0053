using System;


namespace R5T.L0053
{
    public class CancellationTokens : ICancellationTokens
    {
        #region Infrastructure

        public static ICancellationTokens Instance { get; } = new CancellationTokens();


        private CancellationTokens()
        {
        }

        #endregion
    }
}

using System;


namespace R5T.L0053
{
    public class TargetFrameworkMonikerTokens : ITargetFrameworkMonikerTokens
    {
        #region Infrastructure

        public static ITargetFrameworkMonikerTokens Instance { get; } = new TargetFrameworkMonikerTokens();


        private TargetFrameworkMonikerTokens()
        {
        }

        #endregion
    }
}

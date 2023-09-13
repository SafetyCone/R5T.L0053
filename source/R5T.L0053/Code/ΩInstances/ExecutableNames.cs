using System;


namespace R5T.L0053
{
    public class ExecutableNames : IExecutableNames
    {
        #region Infrastructure

        public static IExecutableNames Instance { get; } = new ExecutableNames();


        private ExecutableNames()
        {
        }

        #endregion
    }
}

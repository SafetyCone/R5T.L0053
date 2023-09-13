using System;


namespace R5T.L0053
{
    public class RuntimeNames : IRuntimeNames
    {
        #region Infrastructure

        public static IRuntimeNames Instance { get; } = new RuntimeNames();


        private RuntimeNames()
        {
        }

        #endregion
    }
}

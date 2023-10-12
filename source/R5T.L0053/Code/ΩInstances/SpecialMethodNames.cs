using System;


namespace R5T.L0053
{
    public class SpecialMethodNames : ISpecialMethodNames
    {
        #region Infrastructure

        public static ISpecialMethodNames Instance { get; } = new SpecialMethodNames();


        private SpecialMethodNames()
        {
        }

        #endregion
    }
}

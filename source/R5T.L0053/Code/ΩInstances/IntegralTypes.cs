using System;


namespace R5T.L0053
{
    public class IntegralTypes : IIntegralTypes
    {
        #region Infrastructure

        public static IIntegralTypes Instance { get; } = new IntegralTypes();


        private IntegralTypes()
        {
        }

        #endregion
    }
}

using System;


namespace R5T.L0053
{
    public class EnumerationUnderlyingTypes : IEnumerationUnderlyingTypes
    {
        #region Infrastructure

        public static IEnumerationUnderlyingTypes Instance { get; } = new EnumerationUnderlyingTypes();


        private EnumerationUnderlyingTypes()
        {
        }

        #endregion
    }
}

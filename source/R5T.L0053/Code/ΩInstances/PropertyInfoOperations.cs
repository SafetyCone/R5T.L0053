using System;


namespace R5T.L0053
{
    public class PropertyInfoOperations : IPropertyInfoOperations
    {
        #region Infrastructure

        public static IPropertyInfoOperations Instance { get; } = new PropertyInfoOperations();


        private PropertyInfoOperations()
        {
        }

        #endregion
    }
}

using System;


namespace R5T.L0053
{
    public class PropertyInfoOperator : IPropertyInfoOperator
    {
        #region Infrastructure

        public static IPropertyInfoOperator Instance { get; } = new PropertyInfoOperator();


        private PropertyInfoOperator()
        {
        }

        #endregion
    }
}

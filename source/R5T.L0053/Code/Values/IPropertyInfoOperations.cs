using System;
using System.Reflection;

using R5T.T0131;


namespace R5T.L0053
{
    [ValuesMarker]
    public partial interface IPropertyInfoOperations : IValuesMarker
    {
        public Func<PropertyInfo, bool> Name_Is(string propertyName)
        {
            bool Internal(PropertyInfo property)
            {
                var output = Instances.PropertyInfoOperator.Is_Name(
                    property,
                    propertyName);

                return output;
            }

            return Internal;
        }
    }
}

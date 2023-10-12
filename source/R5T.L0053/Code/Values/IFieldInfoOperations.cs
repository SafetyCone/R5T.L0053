using System;
using System.Reflection;

using R5T.T0131;


namespace R5T.L0053
{
    [ValuesMarker]
    public partial interface IFieldInfoOperations : IValuesMarker
    {
        public Func<FieldInfo, bool> Name_Is(string fieldName)
        {
            bool Internal(FieldInfo field)
            {
                var output = Instances.FieldInfoOperator.Is_Name(
                    field,
                    fieldName);

                return output;
            }

            return Internal;
        }
    }
}

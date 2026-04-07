using System;
using System.Linq;
using System.Reflection;

using R5T.T0132;
using R5T.T0143;


namespace R5T.L0053
{
    /// <inheritdoc cref="F10Y.L0000.IFieldInfoOperator" path="/summary"/>
    /// <remarks>
    /// <inheritdoc cref="Documentation.Project_SelfDescription" path="/summary"/>
    /// </remarks>
    [FunctionalityMarker]
    public partial interface IFieldInfoOperator : IFunctionalityMarker,
        F10Y.L0000.IFieldInfoOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        F10Y.L0000.IFieldInfoOperator _F10Y_L0000 => F10Y.L0000.FieldInfoOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        string Get_FieldName(FieldInfo fieldInfo)
        {
            var output = fieldInfo.Name;
            return output;
        }

        FieldInfo Get_FieldOf(
            Type type,
            string fieldName)
        {
            var method = type.GetFields()
                .Where(Instances.FieldInfoOperations.Name_Is(fieldName))
                .Single();

            return method;
        }

        FieldInfo Get_FieldOf<T>(string fieldName)
        {
            var type = Instances.TypeOperator.Get_TypeOf<T>();

            var output = this.Get_FieldOf(
                type,
                fieldName);

            return output;
        }

        string Get_Name(FieldInfo field)
        {
            var output = field.Name;
            return output;
        }

        bool Is_Name(
            FieldInfo field,
            string fieldName)
        {
            var name = this.Get_Name(field);

            var output = name == fieldName;
            return output;
        }
    }
}

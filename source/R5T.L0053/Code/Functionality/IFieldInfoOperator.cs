using System;
using System.Linq;
using System.Reflection;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IFieldInfoOperator : IFunctionalityMarker
    {
        public Type Get_DeclaringType(FieldInfo fieldInfo)
        {
            var output = fieldInfo.DeclaringType;
            return output;
        }

        public Type Get_FieldType(FieldInfo fieldInfo)
        {
            var output = fieldInfo.FieldType;
            return output;
        }

        public string Get_FieldName(FieldInfo fieldInfo)
        {
            var output = fieldInfo.Name;
            return output;
        }

        public FieldInfo Get_FieldOf(
            Type type,
            string fieldName)
        {
            var method = type.GetFields()
                .Where(Instances.FieldInfoOperations.Name_Is(fieldName))
                .Single();

            return method;
        }

        public FieldInfo Get_FieldOf<T>(string fieldName)
        {
            var type = Instances.TypeOperator.Get_TypeOf<T>();

            var output = this.Get_FieldOf(
                type,
                fieldName);

            return output;
        }

        public string Get_Name(FieldInfo field)
        {
            var output = field.Name;
            return output;
        }

        public bool Is_Name(
            FieldInfo field,
            string fieldName)
        {
            var name = this.Get_Name(field);

            var output = name == fieldName;
            return output;
        }
    }
}

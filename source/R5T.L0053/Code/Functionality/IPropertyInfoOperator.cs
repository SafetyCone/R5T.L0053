using System;
using System.Linq;
using System.Reflection;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IPropertyInfoOperator : IFunctionalityMarker
    {
        public Type Get_DeclaringType(PropertyInfo propertyInfo)
        {
            var output = propertyInfo.DeclaringType;
            return output;
        }

        public MethodInfo Get_GetMethod(PropertyInfo propertyInfo)
        {
            var output = propertyInfo.GetMethod;
            return output;
        }

        /// <summary>
        /// Returns an empty array if there are no parameters.
        /// </summary>
        public ParameterInfo[] Get_IndexerParameters(PropertyInfo propertyInfo)
        {
            var output = propertyInfo.GetIndexParameters();
            return output;
        }

        public string Get_PropertyName(PropertyInfo propertyInfo)
        {
            var output = propertyInfo.Name;
            return output;
        }

        public PropertyInfo Get_PropertyOf(
            Type type,
            string propertyName)
        {
            var method = type.GetProperties()
                .Where(Instances.PropertyInfoOperations.Name_Is(propertyName))
                .Single();

            return method;
        }

        public PropertyInfo Get_PropertyOf<T>(string propertyName)
        {
            var type = Instances.TypeOperator.Get_TypeOf<T>();

            var output = this.Get_PropertyOf(
                type,
                propertyName);

            return output;
        }

        public Type Get_PropertyType(PropertyInfo propertyInfo)
        {
            var output = propertyInfo.PropertyType;
            return output;
        }

        /// <summary>
        /// Is the method an indexer method?
        /// (I.e. does the get-method for the property have input parameters?
        /// </summary>
        public bool Is_Indexer(PropertyInfo propertyInfo)
        {
            //var getMethod = this.Get_GetMethod(propertyInfo);

            //var anyInputParameters = Instances.MethodInfoOperator.Has_InputParameters(getMethod);

            var indexerParameters = this.Get_IndexerParameters(propertyInfo);

            var output = indexerParameters.Any();
            return output;
        }

        public bool Is_Name(
            PropertyInfo property,
            string propertyName)
        {
            var name = this.Get_PropertyName(property);

            var output = name == propertyName;
            return output;
        }
    }
}

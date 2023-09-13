using System;
using System.Linq;
using System.Reflection;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IPropertyInfoOperator : IFunctionalityMarker
    {
        public MethodInfo Get_GetMethod(PropertyInfo propertyInfo)
        {
            var output = propertyInfo.GetMethod;
            return output;
        }

        public ParameterInfo[] Get_IndexerParameters(PropertyInfo propertyInfo)
        {
            var output = propertyInfo.GetIndexParameters();
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
    }
}

using System;
using System.Reflection;

using R5T.T0131;


namespace R5T.L0053
{
    [ValuesMarker]
    public partial interface IMethodInfoOperations : IValuesMarker
    {
        public Func<MethodInfo, bool> Name_Is(string methodName)
        {
            bool Internal(MethodInfo method)
            {
                var output = Instances.MethodInfoOperator.Is_Name(
                    method,
                    methodName);

                return output;
            }

            return Internal;
        }

        public Func<MethodInfo, bool> Name_Is(
            string methodName,
            int genericTypeInputCount)
        {
            bool Internal(MethodInfo method)
            {
                var output = Instances.MethodInfoOperator.Is_Name(
                    method,
                    methodName,
                    genericTypeInputCount);

                return output;
            }

            return Internal;
        }
    }
}

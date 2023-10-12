using System;
using System.Reflection;

using R5T.T0131;


namespace R5T.L0053
{
    [ValuesMarker]
    public partial interface IEventInfoOperations : IValuesMarker
    {
        public Func<EventInfo, bool> Name_Is(string methodName)
        {
            bool Internal(EventInfo method)
            {
                var output = Instances.EventInfoOperator.Is_Name(
                    method,
                    methodName);

                return output;
            }

            return Internal;
        }
    }
}

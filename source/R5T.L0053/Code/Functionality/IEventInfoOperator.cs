using System;
using System.Linq;
using System.Reflection;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IEventInfoOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Returns the result of <see cref="MemberInfo.DeclaringType"/>.
        /// </summary>
        public Type Get_DeclaringType(EventInfo eventInfo)
        {
            var output = eventInfo.DeclaringType;
            return output;
        }

        /// <summary>
        /// Returns the result of <see cref="EventInfo.EventHandlerType"/>.
        /// </summary>
        public Type Get_EventHandlerType(EventInfo eventInfo)
        {
            var output = eventInfo.EventHandlerType;
            return output;
        }

        public EventInfo Get_EventOf(
            Type type,
            string eventName)
        {
            var method = type.GetEvents()
                .Where(Instances.EventInfoOperations.Name_Is(eventName))
                .Single();

            return method;
        }

        public EventInfo Get_EventOf<T>(string eventName)
        {
            var type = Instances.TypeOperator.Get_TypeOf<T>();

            var output = this.Get_EventOf(
                type,
                eventName);

            return output;
        }

        public string Get_EventName(EventInfo eventInfo)
        {
            var output = eventInfo.Name;
            return output;
        }

        public bool Is_Name(
            EventInfo eventInfo,
            string eventName)
        {
            var output = eventInfo.Name == eventName;
            return output;
        }
    }
}

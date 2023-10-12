using System;
using System.Diagnostics;
using System.Reflection;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IExceptionOperator : IFunctionalityMarker
    {
        public Exception Get_Exception(string message)
        {
            var output = new Exception(message);
            return output;
        }

        public Exception GetErrorDataReceivedException(DataReceivedEventArgs eventArgs)
        {
            var exception = new Exception(
                Instances.ExceptionMessageOperator.Get_Message_IfMessageIsNull(
                    eventArgs.Data,
                    Instances.Messages.EventDataReceivedWasNull));

            return exception;
        }

        public Exception Get_UnknownElementTypeRelationshipException()
        {
            var output = new Exception("Unknown element type relationship.");
            return output;
        }

        public Exception Get_UnrecognizedMemberTypeException(MemberInfo memberInfo)
        {
            var message = Instances.ExceptionMessageOperator.Get_UnrecognizedMemberTypeExceptionMessage(memberInfo);

            var output = this.Get_Exception(message);
            return output;
        }
    }
}

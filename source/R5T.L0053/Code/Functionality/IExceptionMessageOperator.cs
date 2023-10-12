using System;
using System.Reflection;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IExceptionMessageOperator : IFunctionalityMarker
    {
        public string Get_Message_IfMessageIsNull(
            string message,
            string messageIfNull)
        {
            var output = message ?? messageIfNull;
            return output;
        }

        public string Get_UnrecognizedMemberTypeExceptionMessage(MemberInfo memberInfo)
        {
            var output = $"Unrecognzed member info type: {memberInfo}";
            return output;
        }
    }
}

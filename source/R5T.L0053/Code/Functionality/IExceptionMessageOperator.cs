using System;
using System.Reflection;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IExceptionMessageOperator : IFunctionalityMarker,
        L0066.IExceptionMessageOperator
    {
        public string Get_UnrecognizedMemberTypeExceptionMessage(MemberInfo memberInfo)
        {
            var output = $"Unrecognzed member info type: {memberInfo}";
            return output;
        }
    }
}

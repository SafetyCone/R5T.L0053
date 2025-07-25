using System;
using System.Reflection;

using R5T.T0132;
using R5T.T0143;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IExceptionMessageOperator : IFunctionalityMarker,
        L0066.IExceptionMessageOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public L0066.IExceptionMessageOperator _L0066 => L0066.ExceptionMessageOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public string Get_UnrecognizedMemberTypeExceptionMessage(MemberInfo memberInfo)
        {
            var output = $"Unrecognzed member info type: {memberInfo}";
            return output;
        }
    }
}

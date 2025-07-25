using System;
using System.Reflection;

using R5T.T0132;
using R5T.T0143;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IExceptionOperator : IFunctionalityMarker,
        L0066.IExceptionOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public L0066.IExceptionOperator _L0066 => L0066.ExceptionOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


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

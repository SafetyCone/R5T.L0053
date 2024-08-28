using System;
using System.Reflection;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IMemberInfoOperator : IFunctionalityMarker,
        L0066.IMemberInfoOperator
    {
        public Assembly Get_Assembly(MemberInfo memberInfo)
        {
            // Can't use the declaring type of the member info, since the member info might be a type (and thus have no declaring type)!
            var output = memberInfo.Module.Assembly;
            return output;
        }

        /// <summary>
        /// Gets the raw name of a member (<see cref="MemberInfo.Name"/>),
        /// without any adjustements.
        /// </summary>
        public string Get_Name(MemberInfo memberInfo)
        {
            var output = memberInfo.Name;
            return output;
        }

        /// <summary>
        /// Member names that are explicitly implemented are the full namespaced typed name of the implemented member.
        /// Thus, they contain the namespaced token separator.
        /// </summary>
        public bool Is_ExplicitlyImplemented(MemberInfo memberInfo)
        {
            var rawName = this.Get_Name(memberInfo);

            var output = Instances.StringOperator.Contains(
                rawName,
                Instances.TokenSeparators.NamespaceTokenSeparator);

            return output;
        }
    }
}

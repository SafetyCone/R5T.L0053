using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IMemberInfoOperator : IFunctionalityMarker
    {
        public Assembly Get_Assembly(MemberInfo memberInfo)
        {
            // Can't use the declaring type of the member info, since the member info might be a type (and thus have no declaring type)!
            var output = memberInfo.Module.Assembly;
            return output;
        }

        /// <summary>
        /// Note: the <see cref="CustomAttributeData"/> type returned by <see cref="MemberInfo.CustomAttributes"/> is more useful than
        /// the <see cref="Attribute"/> type returned by <see cref="CustomAttributeExtensions.GetCustomAttributes(MemberInfo)"/>.
        /// </summary>
        public IEnumerable<CustomAttributeData> Get_Attributes(MemberInfo memberInfo)
        {
            var output = memberInfo.CustomAttributes;
            return output;
        }

        /// <summary>
        /// Returns the result of <see cref="MemberInfo.DeclaringType"/>.
        /// </summary>
        public Type Get_DeclaringType(MemberInfo memberInfo)
        {
            var output = memberInfo.DeclaringType;
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

        public bool Has_AttributeOfType(
            MemberInfo memberInfo,
            string attributeNamespacedTypeName,
            out CustomAttributeData attributeOrDefault)
        {
            attributeOrDefault = this.Get_Attributes(memberInfo)
                .Where(Instances.AttributeOperations.AttributeTypeNamespacedTypeName_Is(attributeNamespacedTypeName))
                // Choose first even though there might be multiple since this function is more like "Any()".
                .FirstOrDefault();

            var output = Instances.ValueOperator.Is_NotDefault(attributeOrDefault);
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

        public bool Is_Obsolete(MemberInfo memberInfo)
        {
            var hasObsoleteAttribute = this.Has_AttributeOfType(
                memberInfo,
                Instances.NamespacedTypeNames.System_ObsoleteAttribute,
                out _);

            return hasObsoleteAttribute;
        }
    }
}

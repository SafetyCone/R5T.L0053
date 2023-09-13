using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using R5T.T0132;

using R5T.L0053.Extensions;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IAssemblyOperator : IFunctionalityMarker
    {
        public void Foreach_Member(
            Assembly assembly,
            Action<MemberInfo> action)
        {
            var members = this.Enumerate_Members(assembly);

            foreach (var member in members)
            {
                action(member);
            }
        }

        public void Foreach_Type(
            Assembly assembly,
            Action<TypeInfo> action)
        {
            var types = this.Enumerate_Types(assembly);

            foreach (var typeInfo in types)
            {
                action(typeInfo);
            }
        }

        public IEnumerable<MemberInfo> Enumerate_Members(Assembly assembly)
        {
            var output = this.Enumerate_Types(assembly)
                .SelectMany(typeInfo => Instances.EnumerableOperator.Empty<MemberInfo>()
                    .Append(typeInfo)
                    .Append(
                        Instances.TypeInfoOperator.Get_MemberInfos(typeInfo)
                    )
                )
                ;

            return output;
        }

        /// <summary>
        /// Returns <see cref="Assembly.DefinedTypes"/>.
        /// </summary>
        public IEnumerable<TypeInfo> Enumerate_Types(Assembly assembly)
        {
            return assembly.DefinedTypes;
        }

        public MemberInfo[] Get_Members(Assembly assembly)
        {
            var output = this.Enumerate_Members(assembly)
                .Now();

            return output;
        }

        public TypeInfo[] Get_Types(Assembly assembly)
        {
            var output = this.Enumerate_Types(assembly)
                .Now();

            return output;
        }

        /// <inheritdoc cref="IAssemblyFilePathOperator.Get_AssemblyFilePaths_InAssemblyDirectory(string)"/>
        public string[] Get_AssemblyFilePaths_InAssemblyDirectory(string assemblyFilePath)
        {
            return Instances.AssemblyFilePathOperator.Get_AssemblyFilePaths_InAssemblyDirectory(assemblyFilePath);
        }
    }
}

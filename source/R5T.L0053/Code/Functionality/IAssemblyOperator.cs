using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IAssemblyOperator : IFunctionalityMarker,
        L0066.IAssemblyOperator
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

        public async Task Foreach_Member(
            Assembly assembly,
            Func<MemberInfo, Task> action)
        {
            var members = this.Enumerate_Members(assembly);

            foreach (var member in members)
            {
                await action(member);
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

        public string Get_AssemblyFilePath(Assembly assembly)
        {
            var output = assembly.Location;

            this.Verify_NotDefaultAssemblyFilePath(output);

            return output;
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

        /// <summary>
        /// The result of <see cref="Assembly.Location"/> when the assembly is loaded from a binary array or other non-file source is <see cref="IValues.Default_AssemblyFilePath"/>.
        /// </summary>
        public bool Is_DefaultAssemblyFilePath(string assemblyFilePath)
        {
            var output = assemblyFilePath == Instances.Values.Default_AssemblyFilePath;
            return output;
        }

        public void Verify_NotDefaultAssemblyFilePath(string assemblyFilePath)
        {
            var isDefaultAssemblyFilePath = this.Is_DefaultAssemblyFilePath(assemblyFilePath);
            if(isDefaultAssemblyFilePath)
            {
                throw new Exception("Assembly file path was the default assembly file path. (No file path found for assembly.)");
            }
        }
    }
}

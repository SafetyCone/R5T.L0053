using System;
using System.Reflection;


namespace R5T.L0053.Extensions
{
    public static class AssemblyExtensions
    {
        public static void Foreach_Type(this Assembly assembly,
            Action<TypeInfo> action)
        {
            Instances.AssemblyOperator.Foreach_Type(
                assembly,
                action);
        }
    }
}

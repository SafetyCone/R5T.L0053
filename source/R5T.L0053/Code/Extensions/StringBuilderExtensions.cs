using System;
using System.Text;


namespace R5T.L0053.Extensions
{
    public static class StringBuilderExtensions
    {
        public static void Remove_Last(this StringBuilder builder)
        {
            Instances.StringBuilderOperator.Remove_Last(builder);
        }
    }
}

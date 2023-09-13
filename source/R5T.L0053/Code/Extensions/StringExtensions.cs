using System;


namespace R5T.L0053.Extensions
{
    public static class StringExtensions
    {
        public static string Except_First(this string @string)
        {
            return Instances.StringOperator.ExceptFirst(@string);
        }
    }
}

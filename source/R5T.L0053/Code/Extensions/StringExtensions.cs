using System;
using System.Collections.Generic;
using System.Linq;


namespace R5T.L0053.Extensions
{
    public static class StringExtensions
    {
        public static string Append(this string @string,
            string appendix)
        {
            return Instances.StringOperator.Append(
                @string,
                appendix);
        }

        public static string Except_First(this string @string)
        {
            return Instances.StringOperator.Except_First(@string);
        }

        public static string Except_FirstTwo(this string @string)
        {
            return Instances.StringOperator.Except_FirstTwo(@string);
        }

        public static string Join(this IEnumerable<string> strings,
            char separator)
        {
            return Instances.StringOperator.Join(
                separator,
                strings);
        }

        public static string Join(this IEnumerable<string> strings,
            string separator)
        {
            return Instances.StringOperator.Join(
                separator,
                strings);
        }

        public static string Join(this IEnumerable<string> strings)
        {
            var output = strings.Join(Instances.Strings.Empty);
            return output;
        }

        public static IEnumerable<string> Remove_EmptyOrNull(this IEnumerable<string> strings)
        {
            return Instances.StringOperator.Remove_EmptyOrNull(strings);
        }

        public static IEnumerable<string> Trim(this IEnumerable<string> strings)
        {
            var output = strings
                .Select(Instances.StringOperator.Trim)
                ;

            return output;
        }

        public static string Wrap(this string @string,
            string prefix,
            string suffix)
        {
            return Instances.StringOperator.Wrap(
                @string,
                prefix,
                suffix);
        }

        public static string Wrap(this string @string,
            char prefix,
            char suffix)
        {
            return Instances.StringOperator.Wrap(
                @string,
                prefix,
                suffix);
        }
    }
}

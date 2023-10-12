using System;
using System.Collections.Generic;


namespace R5T.L0053.Extensions
{
    public static class CharacterExtensions
    {
        public static string Get_String(this IEnumerable<char> characters)
        {
            var output = Instances.CharacterOperator.Get_String(characters);
            return output;
        }

        public static string Get_String(this char[] characters)
        {
            var output = Instances.CharacterOperator.Get_String(characters);
            return output;
        }
    }
}

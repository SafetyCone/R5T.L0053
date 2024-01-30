using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;

using R5T.L0053.Extensions;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IStringOperator : IFunctionalityMarker,
        L0066.IStringOperator
    {
        public int CountOf(
            char character,
            string @string)
        {
            var output = @string
                .Where(c => c == character)
                .Count();

            return output;
        }

        public string Empty_IfNull(string @string)
        {
            var isNull = this.Is_Null(@string);

            var output = isNull
                ? Instances.Strings.Empty
                : @string
                ;

            return output;
        }

        public bool EndsWith_Any(
            string @string,
            params string[] endings)
        {
            foreach (var ending in endings)
            {
                var endsWithEnding = this.EndsWith(
                    @string,
                    ending);

                if (endsWithEnding)
                {
                    return true;
                }
            }

            return false;
        }

        public int[] Get_IndicesOf_OrEmpty(
            string @string,
            char character)
        {
            static IEnumerable<int> Internal(
                string @string,
                char specifiedCharacter)
            {
                var index = 0;
                foreach (var character in @string)
                {
                    if(character == specifiedCharacter)
                    {
                        yield return index;
                    }

                    index++;
                }
            }

            var output = Internal(
                @string,
                character)
                .ToArray();

            return output;
        }

        /// <summary>
        /// Get the index of the first token containing the specified character.
        /// If no token containing the specified character is found, return <see cref="L0066.IIndices.NotFound"/> (use with <see cref="L0066.IStringOperator.Is_Found(int)"/>).
        /// </summary>
        public int Get_TokenIndex_Containing_OrNotFound(
            IEnumerable<string> tokens,
            char character)
        {
            var counter = 0;
            foreach (var token in tokens)
            {
                var tokenContainsCharacter = Instances.StringOperator.Contains(
                    token,
                    character);

                if(tokenContainsCharacter)
                {
                    return counter;
                }
                else
                {
                    counter++;
                }
            }

            // If here, the character was not found.
            return Instances.Indices.NotFound;
        }

        /// <summary>
        /// Get the index of the first token containing the specified character.
        /// If no token containing the specified character is found, an <see cref="InvalidOperationException"/> is thrown.
        /// </summary>
        public int Get_TokenIndex_Containing(
            IEnumerable<string> tokens,
            char character)
        {
            var indexOrNotFound = this.Get_TokenIndex_Containing_OrNotFound(
                tokens,
                character);

            var isFound = this.Is_Found(indexOrNotFound);
            if(!isFound)
            {
                throw new InvalidOperationException($"{character}: character not found in any tokens.");
            }

            return indexOrNotFound;
        }

        

        public string Remove(
            string @string,
            char character)
        {
            var output = this.Remove_Character(
                @string,
                character);

            return output;
        }

        public string Remove_Character(
            string @string,
            char character)
        {
            var output = @string
                .Where(x => x != character)
                .Get_String();

            return output;
        }

        public IEnumerable<string> Remove_EmptyOrNull(IEnumerable<string> strings)
        {
            var output = strings
                .Where(this.Is_NullOrEmpty)
                ;

            return output;
        }

        public string[] Split(
            char separator,
            string @string)
        {
            var output = @string.Split(separator);
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Partition_Exclusive(int, string)"/> as the default.
        /// </summary>
        public (string firstPart, string secondPart) Split(
            int index,
            string @string)
        {
            return this.Partition_Exclusive(
                index,
                @string);
        }

        /// <summary>
        /// Chooses <see cref="Partition_Exclusive(int, string)"/> as the default.
        /// </summary>
        public (string firstPart, string secondPart) Partition(
            int index,
            string @string)
        {
            return this.Partition_Exclusive(
                index,
                @string);
        }

        /// <summary>
        /// Partitions the string based on an index,
        /// or returns the whole input string as the first part if the input index is the <see cref="L0066.IIndices.NotFound"/> value (as determined by <see cref="L0066.IStringOperator.Is_Found(int)"/>).
        /// </summary>
        public (string firstPart, string secondPart) Partition_OrFirstPartIfNotFound(
            int index,
            string @string)
        {
            var indexFound = this.Is_Found(index);
            if(!indexFound)
            {
                return (@string, null);
            }

            return this.Partition_Exclusive(
                index,
                @string);
        }

        /// <summary>
        /// Partition a string into parts given a splitting index.
        /// Exclusive in that the character at the specified index is not included in either output part.
        /// </summary>
        public (string firstPart, string secondPart) Partition_Exclusive(
            int index,
            string @string)
        {
            var firstPart = @string[0..index];
            var secondPart = @string[(index + 1)..];

            return (firstPart, secondPart);
        }

        /// <summary>
        /// Partition a string into parts given a splitting index.
        /// Inclusive in that the character at the specified index is included on the second part.
        /// </summary>
        public (string firstPart, string secondPart) Partition_Inclusive_OnSecondPart(
            int index,
            string @string)
        {
            var firstPart = @string[0..index];
            var secondPart = @string[index..];

            return (firstPart, secondPart);
        }

        /// <summary>
        /// Partition a string into parts given a splitting index.
        /// Inclusive in that the character at the specified index is included on the second part.
        /// If the index is not found, then the whole string is returned as the first part.
        /// </summary>
        public (string firstPart, string secondPart) Partition_Inclusive_OnSecondPart_OrFirstPartIfNotFound(
            int index,
            string @string)
        {
            var indexFound = this.Is_Found(index);
            if (!indexFound)
            {
                return (@string, null);
            }

            return this.Partition_Inclusive_OnSecondPart(
                index,
                @string);
        }
    }
}

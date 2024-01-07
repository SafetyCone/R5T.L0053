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
        private static Internal.IStringOperator Internal => L0053.Internal.StringOperator.Instance;


        /// <summary>
        /// Quality-of-life overload for <see cref="StartsWith(string, string)"/>.
        /// </summary>
        public bool BeginsWith(string @string, string start)
        {
            var output = this.StartsWith(@string, start);
            return output;
        }

        public bool Contains(
            string @string,
            char character)
        {
            var output = @string.Contains(character);
            return output;
        }

        public bool Contains(
            string @string,
            string subString)
        {
            var output = @string.Contains(subString);
            return output;
        }

        public bool Contains(
            string @string,
            string subString,
            StringComparison stringComparison)
        {
            var output = @string.Contains(
                subString,
                stringComparison);

            return output;
        }

        public bool ContainsAny(
            string @string,
            string[] searchStrings)
        {
            var index = this.Get_IndexOfAny_OrNotFound(
                @string,
                searchStrings);

            var wasFound = this.Was_Found(index);
            return wasFound;
        }

        public bool ContainsAny(
            string @string,
            char[] searchCharacters)
        {
            var index = this.Get_IndexOfAny_OrNotFound(
                @string,
                searchCharacters);

            var wasFound = this.Was_Found(index);
            return wasFound;
        }

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

        /// <summary>
        /// Note: supports endings that are longer than the string (returns false).
        /// </summary>
        public bool EndsWith(
            string @string,
            string ending)
        {
            var endingLength = ending.Length;

            var stringLength = @string.Length;
            var stringIsLongEnough = stringLength >= endingLength;
            if (!stringIsLongEnough)
            {
                return false;
            }

            var stringEnding = this.Get_LastNCharacters(
                @string,
                endingLength);

            var output = stringEnding == ending;
            return output;
        }

        public string Ensure_Enquoted(string @string)
        {
            var firstChar = @string.First();
            var lastChar = @string.Last();

            var firstQuoteToken = firstChar == Instances.Characters.Quote
                ? Instances.Strings.Empty
                : Instances.Strings.Quote
                ;

            var lastQuoteToken = lastChar == Instances.Characters.Quote
                ? Instances.Strings.Empty
                : Instances.Strings.Quote
                ;

            var output = $"{firstQuoteToken}{@string}{lastQuoteToken}";
            return output;
        }

        /// <summary>
        /// Robustly returns null or empty for null or empty (respectively).
        /// </summary>
        public string ExceptFirst_Robust(string @string)
        {
            var isNullOrEmpty = this.Is_NullOrEmpty(@string);
            if (isNullOrEmpty)
            {
                return @string;
            }

            var output = Internal.ExceptFirst_Unchecked(@string);
            return output;
        }

        /// <summary>
        /// Similar to the String.Length property and the LINQ Count() extension, throws an exception if the string is null or empty.
        /// </summary>
        public string Except_First_Strict(string @string)
        {
            var isNull = this.Is_Null(@string);
            if (isNull)
            {
                throw new ArgumentNullException(nameof(@string));
            }

            var isEmpty = this.Is_Empty(@string);
            if (isEmpty)
            {
                throw new ArgumentOutOfRangeException(nameof(@string), "Input string was empty.");
            }

            var output = Internal.ExceptFirst_Unchecked(@string);
            return output;
        }

        /// <summary>
        /// Returns the string, without the beginning.
        /// Strict in terms of the function throws an exception if the string does <strong>not</strong> start with the specified beginning.
        /// </summary>
        public string Except_Beginning_Strict(
            string @string,
            string beginning)
        {
            var startsWithBeginning = this.BeginsWith(
                @string,
                beginning);

            if (!startsWithBeginning)
            {
                throw new ArgumentException($"String '{@string}' did not start with beginning '{beginning}'.", nameof(@string));
            }

            var output = @string[beginning.Length..];
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Except_Beginning_Strict(string, string)"/>.
        /// </summary>
        public string Except_Beginning(
            string @string,
            string beginning)
        {
            var output = this.Except_Beginning_Strict(
                @string,
                beginning);

            return output;
        }

        /// <summary>
        /// Returns the string, without the ending.
        /// Robust in terms of the function does not care if the input actually ends with the ending.
        /// </summary>
        public string Except_Ending_Robust(
            string @string,
            string ending)
        {
            var output = @string[..^ending.Length];
            return output;
        }

        /// <summary>
        /// Returns the string, without the ending.
        /// Strict in terms of the function throws an exception if the string does <strong>not</strong> end with the specified ending.
        /// </summary>
        public string Except_Ending_Strict(
            string @string,
            string ending)
        {
            var endsWithEnding = this.EndsWith(
                @string,
                ending);

            if (!endsWithEnding)
            {
                throw new ArgumentException($"String '{@string}' did not end with ending '{ending}'.", nameof(@string));
            }

            var output = this.Except_Ending_Robust(
                @string,
                ending);

            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Except_Ending_Strict(string, string)"/>.
        /// </summary>
        public string Except_Ending(
            string @string,
            string ending)
        {
            var output = this.Except_Ending_Strict(
                @string,
                ending);

            return output;
        }

        /// <summary>
        /// Chooses <see cref="Except_First_Strict(string)"/> as the default.
        /// Check your string lengths!
        /// </summary>
        public string Except_First(string @string)
        {
            var output = this.Except_First_Strict(@string);
            return output;
        }

        public string Except_FirstTwo(string @string)
        {
            var output = @string[2..];
            return output;
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

        public string Replace_Character(
            string @string,
            char oldCharacter,
            char newCharacter)
        {
            var output = @string.Replace(
                oldCharacter,
                newCharacter);

            return output;
        }

        public string Replace(
            string @string,
            char newCharacter,
            IEnumerable<char> oldCharacters)
        {
            var currentString = @string;

            foreach (var oldCharacter in oldCharacters)
            {
                currentString = this.Replace_Character(
                    currentString,
                    oldCharacter,
                    newCharacter);
            }

            return currentString;
        }

        public string Replace_Characters(
            string @string,
            char newCharacter,
            params char[] oldCharacters)
        {
            var output = this.Replace(
                @string,
                newCharacter,
                oldCharacters.AsEnumerable());

            return output;
        }

        public string Replace(
            string @string,
            char newCharacter,
            params char[] oldCharacters)
        {
            var output = this.Replace_Characters(
                @string,
                newCharacter,
                oldCharacters);

            return output;
        }

        public string Replace_String(
            string @string,
            string oldString,
            string newString)
        {
            var output = @string.Replace(
                oldString,
                newString);

            return output;
        }

        public string Replace(
            string @string,
            string newString,
            IEnumerable<string> oldStrings)
        {
            var currentString = @string;

            foreach (var oldString in oldStrings)
            {
                currentString = this.Replace_String(
                    currentString,
                    oldString,
                    newString);
            }

            return currentString;
        }

        public string Replace_Strings(
            string @string,
            string newString,
            params string[] oldStrings)
        {
            var output = this.Replace(
                @string,
                newString,
                oldStrings.AsEnumerable());

            return output;
        }

        public string Replace(
            string @string,
            string newString,
            params string[] oldStrings)
        {
            var output = this.Replace_Strings(
                @string,
                newString,
                oldStrings);

            return output;
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

        public bool StartsWith(
            string @string,
            char character)
        {
            var output = @string[0] == character;
            return output;
        }

        public bool StartsWith(string @string, string start)
        {
            var isNull = @string is null;
            var startIsNull = start is null;

            if (isNull)
            {
                // If the string is null, then it all depends on the start. If the start is null, then true, else false.
                return startIsNull;
            }
            // Now we know the string is not null.

            if (startIsNull)
            {
                // If the string is not null, but the start is null, then false.
                return false;
            }
            // Now we know the start is not null.

            var isTooShort = @string.Length < start.Length;
            if (isTooShort)
            {
                return false;
            }
            // Now we know it is at least of the right length.

            // Use a span to avoid creating an extra string on the heap.
            var output = MemoryExtensions.Equals(
                @string.AsSpan(0, start.Length),
                start,
                StringComparison.Ordinal);

            return output;
        }

        /// <inheritdoc cref="System.String.Trim()"/>
        public string Trim(string @string)
        {
            var output = @string.Trim();
            return output;
        }

        /// <inheritdoc cref="Trim(string)"/>
        public IEnumerable<string> Trim(IEnumerable<string> strings)
        {
            var output = strings
                .Select(@string => this.Trim(@string))
                ;

            return output;
        }

        /// <inheritdoc cref="System.String.Trim(char[])"/>
        public string Trim(
            string @string,
            params char[] characters)
        {
            var output = @string.Trim(characters);
            return output;
        }

        /// <summary>
        /// Trims the ending (if it exists) from the end of the provided value.
        /// </summary>
        public string Trim_End(
            string value,
            string ending)
        {
            var output = value;

            while (true)
            {
                bool valueEndsWithEnding = this.EndsWith(
                    output,
                    ending);

                if (valueEndsWithEnding)
                {
                    output = this.Except_Ending(
                        output,
                        ending);
                }
                else
                {
                    break;
                }
            }

            return output;
        }

        /// <summary>
        /// Trims new-lines (both Windows and Non-Windows) from the start and end of a string.
        /// Does not trim tabs.
        /// </summary>
        /// <remarks>
        /// Useful for creating string-literal code fragments on their own lines (meaning the new-lines between the start-line and end-line must be removed.
        /// </remarks>
        public string Trim_NewLines(string value)
        {
            var output = value.Trim(
                Instances.Characters.NewLine,
                Instances.Characters.CarriageReturn);

            return output;
        }

        /// <summary>
        /// Trims the beginning (if it exists) from the start of the provided value.
        /// </summary>
        public string Trim_Start(
            string value,
            string beginning)
        {
            var output = value;

            while (true)
            {
                bool valueStartsWithBeginning = this.StartsWith(
                    value,
                    beginning);

                if (valueStartsWithBeginning)
                {
                    output = this.Except_Beginning(
                        output,
                        beginning);
                }
                else
                {
                    break;
                }
            }

            return output;
        }

        public string Wrap(
            string @string,
            string prefix,
            string suffix)
        {
            var output = $"{prefix}{@string}{suffix}";
            return output;
        }

        public string Wrap(
            string @string,
            char prefix,
            char suffix)
        {
            var output = this.Wrap(
                @string,
                prefix.ToString(),
                suffix.ToString());

            return output;
        }
    }
}

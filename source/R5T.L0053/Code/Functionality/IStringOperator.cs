using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;
using R5T.T0143;

using R5T.L0053.Extensions;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IStringOperator : IFunctionalityMarker,
        L0066.IStringOperator,
        F10Y.L0001.IStringOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public L0066.IStringOperator _L0066 => L0066.StringOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public bool EndsWith_Any(
            string @string,
            params string[] endings)
            => this.Ends_WithAny(
                @string,
                endings);    

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

        /// <summary>
        /// Chooses <see cref="F10Y.L0001.L000.IStringOperator.Partition_Exclusive(int, string)"/> as the default.
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
        /// Partitions the string based on an index,
        /// or returns the whole input string as the first part if the input index is the <see cref="L0066.IIndices.NotFound"/> value (as determined by <see cref="F10Y.L0000.IStringOperator.Is_Found(int)"/>).
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
    }
}

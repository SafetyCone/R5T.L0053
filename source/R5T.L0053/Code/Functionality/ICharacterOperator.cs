using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;
using R5T.T0143;

using R5T.L0053.Extensions;

using Glossary = R5T.Y0006.Glossary;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface ICharacterOperator : IFunctionalityMarker,
        F10Y.L0005.ICharacterOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0005.ICharacterOperator _F10Y_L0005 => F10Y.L0005.CharacterOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public string Get_String(IEnumerable<char> characters)
        {
            var charactersArray = characters.ToArray();

            var output = this.Get_String(charactersArray);
            return output;
        }

        public string Get_String(char[] characters)
        {
            var output = new string(characters);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.For_CharacterClasses.Alphanumeric" path="/definition"/>
        /// </summary>
        public bool Is_Alphanumeric(char character)
        {
            var output = Char.IsLetterOrDigit(character);
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Is_Uppercase(char)"/>.
        /// </summary>
        public bool Is_Capitalized(char character)
        {
            var output = this.Is_Uppercase(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.For_CharacterClasses.Character" path="/definition"/>
        /// </summary>
        public bool Is_Character(char character)
        {
            return true;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.For_CharacterClasses.Control" path="/definition"/>
        /// </summary>
        public bool Is_Control(char character)
        {
            var output = Char.IsControl(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.For_CharacterClasses.Letter" path="/definition"/>
        /// </summary>
        public bool Is_Letter(char character)
        {
            var output = Char.IsLetter(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.For_CharacterClasses.Alphanumeric" path="/definition"/>
        /// </summary>
        public bool Is_LetterOrDigit(char character)
        {
            var output = Char.IsLetterOrDigit(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.For_CharacterClasses.Lowercase" path="/definition"/>
        /// </summary>
        public bool Is_Lowercase(char character)
        {
            var output = Char.IsLower(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.For_CharacterClasses.None" path="/definition"/>
        /// </summary>
        public bool Is_None(char character)
        {
            return false;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.For_CharacterClasses.Number" path="/definition"/>
        /// </summary>
        public bool Is_Number(char character)
        {
            var output = Char.IsNumber(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.For_CharacterClasses.Punctuation" path="/definition"/>
        /// </summary>
        public bool Is_Punctuation(char character)
        {
            var output = Char.IsPunctuation(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.For_CharacterClasses.Separator" path="/definition"/>
        /// </summary>
        public bool Is_Separator(char character)
        {
            var output = Char.IsSeparator(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.For_CharacterClasses.Symbol" path="/definition"/>
        /// </summary>
        public bool Is_Symbol(char character)
        {
            var output = Char.IsSymbol(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.For_CharacterClasses.Uppercase" path="/definition"/>
        /// </summary>
        public bool Is_Uppercase(char character)
        {
            var output = Char.IsUpper(character);
            return output;
        }

        public string Join(IEnumerable<char> characters, string separator)
        {
            var characterStrings = characters
                .Select(character => character.ToString())
                ;

            var output = Instances.StringOperator.Join(
                separator,
                characterStrings);

            return output;
        }

        public string Join(IEnumerable<char> characters)
        {
            var separator = Instances.Strings.CommaSeparatedListSpacedSeparator;

            var output = this.Join(characters, separator);
            return output;
        }
    }
}

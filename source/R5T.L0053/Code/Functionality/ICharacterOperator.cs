using System;

using R5T.T0132;

using Glossary = R5T.Y0000.Glossary;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface ICharacterOperator : IFunctionalityMarker
    {
        /// <summary>
        /// <inheritdoc cref="Glossary.ForCharacterClasses.Alphanumeric" path="/definition"/>
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
        /// <inheritdoc cref="Glossary.ForCharacterClasses.Character" path="/definition"/>
        /// </summary>
        public bool Is_Character(char character)
        {
            return true;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.ForCharacterClasses.Control" path="/definition"/>
        /// </summary>
        public bool Is_Control(char character)
        {
            var output = Char.IsControl(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.ForCharacterClasses.Digit" path="/definition"/>
        /// </summary>
        public bool Is_Digit(char character)
        {
            var output = Char.IsDigit(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.ForCharacterClasses.Letter" path="/definition"/>
        /// </summary>
        public bool Is_Letter(char character)
        {
            var output = Char.IsLetter(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.ForCharacterClasses.Alphanumeric" path="/definition"/>
        /// </summary>
        public bool Is_LetterOrDigit(char character)
        {
            var output = Char.IsLetterOrDigit(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.ForCharacterClasses.Lowercase" path="/definition"/>
        /// </summary>
        public bool Is_Lowercase(char character)
        {
            var output = Char.IsLower(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.ForCharacterClasses.None" path="/definition"/>
        /// </summary>
        public bool Is_None(char character)
        {
            return false;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.ForCharacterClasses.Number" path="/definition"/>
        /// </summary>
        public bool Is_Number(char character)
        {
            var output = Char.IsNumber(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.ForCharacterClasses.Punctuation" path="/definition"/>
        /// </summary>
        public bool Is_Punctuation(char character)
        {
            var output = Char.IsPunctuation(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.ForCharacterClasses.Separator" path="/definition"/>
        /// </summary>
        public bool Is_Separator(char character)
        {
            var output = Char.IsSeparator(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.ForCharacterClasses.Symbol" path="/definition"/>
        /// </summary>
        public bool Is_Symbol(char character)
        {
            var output = Char.IsSymbol(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.ForCharacterClasses.Uppercase" path="/definition"/>
        /// </summary>
        public bool Is_Uppercase(char character)
        {
            var output = Char.IsUpper(character);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Glossary.ForCharacterClasses.Whitespace" path="/definition"/>
        /// </summary>
        public bool Is_Whitespace(char character)
        {
            var output = Char.IsWhiteSpace(character);
            return output;
        }
    }
}

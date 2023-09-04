using System;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IFileExtensionOperator : IFunctionalityMarker
    {
        /// <summary>
        /// <inheritdoc cref="Get_FileExtensionSeparator_Character"/>
        /// Chooses <see cref="Get_FileExtensionSeparator_Character"/> as the default.
        /// </summary>
        public char Get_FileExtensionSeparator()
        {
            var output = this.Get_FileExtensionSeparator_Character();
            return output;
        }

        /// <summary>
        /// Gets the file extension separator character.
        /// <para><inheritdoc cref="Z0000.ICharacters.Period" path="descendant::name"/></para>
        /// </summary>
        public char Get_FileExtensionSeparator_Character()
        {
            var output = Instances.Characters.Period;
            return output;
        }

        /// <summary>
        /// Gets the file extension separator character.
        /// <para><inheritdoc cref="Z0000.IStrings.Period" path="descendant::name"/></para>
        /// </summary>
        public char Get_FileExtensionSeparator_String()
        {
            var output = Instances.Characters.Period;
            return output;
        }
    }
}

using System;

using R5T.T0131;


namespace R5T.L0053
{
    [ValuesMarker]
    public partial interface IDirectorySeparators : IValuesMarker
    {
        /// <summary>
        /// <para><inheritdoc cref="Z0000.ICharacters.Slash" path="/summary/descendant::name"/></para>
        /// The non-Windows path directory separator (for Linux and Mac).
        /// </summary>
        public char NonWindows => Instances.Characters.Slash;

        /// <summary>
        /// <para><inheritdoc cref="Z0000.ICharacters.Backslash" path="/summary/descendant::name"/></para>
        /// The Windows path directory separator.
        /// </summary>
        public char Windows => Instances.Characters.Backslash;


        /// <summary>
        /// The standard is <see cref="Windows"/>.
        /// </summary>
        public char Standard => this.Windows;

        /// <summary>
        /// Both Windows and Non-Windows directory separators.
        /// (<see cref="Windows"/>, <see cref="NonWindows"/>)
        /// </summary>
        private static readonly char[] zBoth = new[] {
            Instances.Characters.Backslash,
            Instances.Characters.Slash
        };

        /// <inheritdoc cref="zBoth"/>
        public char[] Both => IDirectorySeparators.zBoth;
    }
}

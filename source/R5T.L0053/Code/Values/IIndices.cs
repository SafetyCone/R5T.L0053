using System;

using R5T.T0131;


namespace R5T.L0053
{
    /// <summary>
    /// Note: Name of values instance variety should be plural, so not "Index", and went with the correct term instead of "Indexes".
    /// </summary>
    [ValuesMarker]
    public partial interface IIndices : IValuesMarker
    {
        /// <summary>
        /// <para>-1</para>
        /// </summary>
        public int Negative_One => -1;

        /// <summary>
        /// <para>0</para>
        /// </summary>
        public int Zero => 0;

        /// <summary>
        /// <para>1</para>
        /// </summary>
        public int One => 1;

        /// <summary>
        /// The index used throughout the .NET standard library to indicate that a value was not found.
        /// <inheritdoc cref="Negative_One"/>
        /// </summary>
        public int NotFound => this.Negative_One;
    }
}

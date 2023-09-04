using System;

using R5T.T0131;


namespace R5T.L0053
{
    [ValuesMarker]
    public partial interface IValues : IValuesMarker
    {
        /// <summary>
        /// <para>true</para>
        /// By default, files are overwritten.
        /// </summary>
        public const bool DefaultOverwriteValue_Const = true;

        /// <inheritdoc cref="DefaultOverwriteValue_Const"/>
        public bool DefaultOverwriteValue => DefaultOverwriteValue_Const;

        /// <summary>
		/// The value for the command line to have no arguments is null.
		/// </summary>
		public string EmptyCommandArguments => null;
    }
}

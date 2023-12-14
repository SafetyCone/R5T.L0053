using System;

using R5T.T0131;
using R5T.Z0000;


namespace R5T.L0053
{
    [ValuesMarker]
    public partial interface IValues : IValuesMarker,
        L0066.IValues
    {
        /// <summary>
        /// <para><inheritdoc cref="IStrings.Empty" path="/summary/descendant::description"/></para>
        /// If an assembly has no file path location, the result of <see cref="System.Reflection.Assembly.Location"/> is the emtpy string (<see cref="IStrings.Empty"/>).
        /// </summary>
        public string Default_AssemblyFilePath => Instances.Strings.Empty;

        /// <summary>
        /// <para>
        /// <value>"parameter"</value>,
        /// <description>the default value for parameters whose names are strangely null or empty</description>.
        /// </para>
        /// </summary>
        public const string Default_ParameterName_Const = "parameter";

        /// <inheritdoc cref="Default_ParameterName_Const"/>
        public string Default_ParameterName => Default_ParameterName_Const;

        /// <summary>
		/// The value for the command line to have no arguments is null.
		/// </summary>
		public string EmptyCommandArguments => null;

        /// <summary>
        /// Version strings can have a 'v' as a leading version indicator (ex: v4.0.30319).
        /// </summary>
        public const char LeadingVersionIndicator_Constant = ICharacters.v_Lowercase_Constant;

        /// <inheritdoc cref="LeadingVersionIndicator_Constant"/>
        public char LeadingVersionIndicator => LeadingVersionIndicator_Constant;
    }
}

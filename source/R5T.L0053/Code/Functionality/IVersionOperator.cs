using System;
using System.Linq;

using R5T.T0132;

using R5T.L0053.Extensions;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IVersionOperator : IFunctionalityMarker,
        L0066.IVersionOperator
    {
        public string Ensure_NotSuffixed(string versionString)
        {
            var indexOrNotFound = Instances.StringOperator.Get_IndexOf_OrNotFound(
                versionString,
                Instances.Characters.Dash);

            var output = Instances.StringOperator.Is_Found(indexOrNotFound)
                ? Instances.StringOperator.Get_Substring_Upto_Exclusive(
                    indexOrNotFound,
                    versionString)
                : versionString
                ;

            return output;
        }

        public bool Is_Suffixed(string versionString)
        {
            var output = Instances.StringOperator.Contains(
                versionString,
                Instances.Characters.Dash);

            return output;
        }

        public string Ensure_NotVersionIndicated(string versionString)
        {
            var hasVersionIndicator = this.Has_LeadingVersionIndicator(versionString);

            var output = hasVersionIndicator
                ? this.Remove_LeadingVersionIndicator_Unchecked(versionString)
                : versionString
                ;

            return output;
        }

        public char GetVersionTokenSeparator()
        {
            var output = Z0000.Instances.Characters.Period;
            return output;
        }

        public Version Get_Version(string version)
        {
            var output = this.Parse(version);
            return output;
        }

        /// <summary>
		/// Robust, in the sense that if the version string is null or empty, no exception will be thrown.
		/// Instead, false will be return.
		/// </summary>
		public bool Has_LeadingVersionIndicator(string versionString)
        {
            if (Instances.StringOperator.Is_NullOrEmpty(versionString))
            {
                return false;
            }

            var firstCharacter = versionString.First();

            var output = firstCharacter == Instances.Values.LeadingVersionIndicator;
            return output;
        }

        /// <summary>
        /// Determines if the version property value is the value returned by <see cref="L0066.IVersionOperator.Get_UndefinedVersionPropertyValue"/> (which is -1, negative one).
        /// </summary>
        public bool IsUndefinedVersionPropertyValue(int versionPropertyValue)
        {
            var undefinedVersionPropertyValue = this.Get_UndefinedVersionPropertyValue();

            var output = versionPropertyValue == undefinedVersionPropertyValue;
            return output;
        }

        /// <summary>
        /// Can handle version indicated strings (ex: v4.0.30319).
        /// </summary>
        public Version Parse(string versionString)
        {
            var ensuredVersionString = versionString;

            ensuredVersionString = this.Ensure_NotVersionIndicated(ensuredVersionString);
            ensuredVersionString = this.Ensure_NotSuffixed(ensuredVersionString);

            var output = Version.Parse(ensuredVersionString);
            return output;
        }

        /// <summary>
		/// Unchecked in the sense that no check is performed that the input is not null or empty, or that the input actually begins with the leading version indicator.
		/// </summary>
        public string Remove_LeadingVersionIndicator_Unchecked(string versionIndicatedString)
        {
            var output = versionIndicatedString.Except_First();
            return output;
        }

        /// <summary>
        /// Version indicated strings begin with a 'v'.
        /// This method removes that V.
        /// </summary>
        public string Remove_LeadingVersionIndicator_Strict(string versionIndicatedString)
        {
            this.Verify_HasLeadingVersionIndicator(versionIndicatedString);

            var output = this.Remove_LeadingVersionIndicator_Unchecked(versionIndicatedString);
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Remove_LeadingVersionIndicator_Strict(string)"/> as the default.
        /// </summary>
        public string Remove_LeadingVersionIndicator(string versionIndicatedString)
        {
            return this.Remove_LeadingVersionIndicator_Strict(versionIndicatedString);
        }

        public string ToString_Default(Version version)
        {
            var output = version.ToString();
            return output;
        }

        public void Verify_HasLeadingVersionIndicator(string versionString)
        {
            var hasLeadingVersionIndicator = this.Has_LeadingVersionIndicator(versionString);
            if (!hasLeadingVersionIndicator)
            {
                throw new Exception($"Version string did not have a leading version indicator ('{Instances.Values.LeadingVersionIndicator}').");
            }
        }
    }
}

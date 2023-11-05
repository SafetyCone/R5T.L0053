using System;
using System.Globalization;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IDateTimeOperator : IFunctionalityMarker
    {
        public bool TryParseExact(
            string @string,
            string format,
            out DateTime dateTime)
        {
            var isDateTimeWithFormat = DateTime.TryParseExact(
                @string,
                format,
                Instances.FormatProviders.Default,
                // Use none to match the old behavior.
                DateTimeStyles.None,
                out dateTime);

            return isDateTimeWithFormat;
        }
    }
}

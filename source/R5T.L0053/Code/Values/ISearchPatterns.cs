using System;

using R5T.T0131;


namespace R5T.L0053
{
    /// <inheritdoc cref="Y0000.Documentation.For_SearchPattern"/>
    [ValuesMarker]
    public partial interface ISearchPatterns : IValuesMarker
    {
        public string All => Instances.Strings.Asterix;
    }
}

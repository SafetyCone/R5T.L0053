using System;

using R5T.T0131;


namespace R5T.L0053
{
    [ValuesMarker]
    public partial interface IFileExtensions : IValuesMarker,
        Z0010.Platform.IFileExtensions
    {
        /// <inheritdoc cref="Z0010.Platform.IFileExtensions.Dll"/>
        public string Assembly => this.Dll;
    }
}

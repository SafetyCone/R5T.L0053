using System;

using R5T.T0131;


namespace R5T.L0053
{
    [ValuesMarker]
    public partial interface IPaths : IValuesMarker
    {
        /// <summary>
        /// Assumes windows is the default.
        /// <inheritdoc cref="DotnetSharedDirectoryPath_Windows" path="/summary"/>
        /// </summary>
        public string DotnetSharedDirectoryPath => this.DotnetSharedDirectoryPath_Windows;

        /// <summary>
        /// "C:\Program Files\dotnet\shared\"
        /// </summary>
        public string DotnetSharedDirectoryPath_Windows => @"C:\Program Files\dotnet\shared\";
    }
}

using System;

using R5T.T0131;


namespace R5T.L0053
{
    /// <summary>
    /// A list of .NET runtime names.
    /// </summary>
    /// <remarks>
    /// These can be found in the directory:
    /// C:\Program Files\dotnet\shared\
    /// </remarks>
    [ValuesMarker]
    public partial interface IRuntimeNames : IValuesMarker
    {
        public string Microsoft_AspNetCore_All => "Microsoft.AspNetCore.All";
        public string Microsoft_AspNetCore_App => "Microsoft.AspNetCore.App";
        public string Microsoft_NETCore_App => "Microsoft.NETCore.App";
        public string Microsoft_WindowsDesktop_App => "Microsoft.WindowsDesktop.App";
    }
}

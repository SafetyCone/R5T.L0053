using System;
using System.ComponentModel;
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
        /// <summary>
        /// "Microsoft.AspNetCore.All"
        /// </summary>
        /// <inheritdoc cref="Microsoft_AspNetCore_App" path="/remarks"/>
        [Obsolete("Use .App instead.")]
        public string Microsoft_AspNetCore_All => "Microsoft.AspNetCore.All";

        /// <summary>
        /// "Microsoft.AspNetCore.App"
        /// </summary>
        /// <remarks>
        /// App should be used instead of All. See <see href="https://github.com/aspnet/Announcements/issues/314"/> and <see href="https://github.com/dotnet/AspNetCore.Docs/issues/7424"/>.
        /// </remarks>
        public string Microsoft_AspNetCore_App => "Microsoft.AspNetCore.App";

        /// <summary>
        /// "Microsoft.NETCore.App"
        /// </summary>
        public string Microsoft_NETCore_App => "Microsoft.NETCore.App";

        /// <summary>
        /// "Microsoft.WindowsDesktop.App"
        /// </summary>
        public string Microsoft_WindowsDesktop_App => "Microsoft.WindowsDesktop.App";
    }
}

using System;
using System.Xml.Linq;

using R5T.T0156;


namespace R5T.L0053
{
    /// <summary>
    /// Platform library for the .NET Standard 2.1 target framework.
    /// </summary>
    [DocumentationMarker]
	public class Documentation
	{
        /// <summary>
        /// Note: asynchronous settings can be used synchronously, but not vice-versa.
        /// </summary>
        public static readonly object NoteOnAsynchronousSettings;

        /// <summary>
        /// All parameters <em>should</em> have names, but somehow it's possible that they do not.
        /// </summary>
        public static readonly object ParametersShouldHaveParameterNames;
    }
}
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
        /// <inheritdoc cref="Documentation" path="/summary"/>
        /// <reference>
        /// <inheritdoc cref="Documentation.Project_SelfDescription" path="/summary"/>
        /// </reference>
        public static readonly object Project_SelfDescription;

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
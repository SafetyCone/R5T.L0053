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
        /// When equating two reference type instances, if one or both of the instances are null then a simple null check has determined whether the instances are equal.
        /// In the case where one instance is null, but the other isn't, a null check has determined equality and the instances are not equal.
        /// If both are null, then the null check has determined equality and the instances are equal.
        /// Only in the case where both are not null does a null check not determine equality.
        /// </summary>
        public static readonly object NullCheckDeterminesEquality;

        /// <summary>
        /// All parameters <em>should</em> have names, but somehow it's possible that they do not.
        /// </summary>
        public static readonly object ParametersShouldHaveParameterNames;

        /// <summary>
        /// When equating two object instances, if the objects have different types then a simple type check has determined whether the instances are equal.
        /// In the case where the instances have different types, a type check has determined equality and the instances are not equal.
        /// Otherwise, if the instances have the same type, a type check does not determine equality and you will need to equate instance values.
        /// </summary>
        public static readonly object TypeCheckDeterminesEquality;

        /// <summary>
        /// type name (fully qualified type name)
        /// </summary>
        public static readonly object TypeNameMeansFullyQualifiedTypeName;

        /// <summary>
        /// Note that only <see cref="XElement"/>, <see cref="XDocument"/> and <see cref="XAttribute"/> have constructors like this (<see cref="XObject"/>, <see cref="XNode"/>, and <see cref="XContainer"/> do not).
        /// </summary>
        public static readonly object WhichXObjectsAreCloneable;
    }
}
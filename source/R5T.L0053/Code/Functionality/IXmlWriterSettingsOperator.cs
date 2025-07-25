using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml;

using F10Y.T0011;
using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IXmlWriterSettingsOperator : IFunctionalityMarker,
        F10Y.L0005.IXmlWriterSettingsOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public F10Y.L0005.IXmlWriterSettingsOperator _F10Y_L0005 => F10Y.L0005.XmlWriterSettingsOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public void Configure(Action<XmlWriterSettings> configure)
        {

        }

        public Task DescribeTo(
            XmlWriterSettings settings,
            TextWriter writer)
        {
            var text = this.DescribeTo_Text(settings);

            return writer.WriteAsync(text);
        }

        public void DescribeTo_Synchronous(
            XmlWriterSettings settings,
            TextWriter writer)
        {
            var text = this.DescribeTo_Text(settings);

            writer.Write(text);
        }

        public void DescribeTo_Console_Synchronous(XmlWriterSettings settings)
        {
            this.DescribeTo_Synchronous(
                settings,
                Console.Out);
        }

        /// <summary>
        /// Implements by-value equality check for the XML writer settings type.
        /// </summary>
        /// <remarks>
        /// The XML writer settings type (<inheritdoc cref="XmlWriterSettings"/>) is a reference type, and it has no equality operator overloads.
        /// Thus, it uses the default object equality operation (by-reference).
        /// </remarks>
        public bool Equals_ByValue(
            XmlWriterSettings settings1,
            XmlWriterSettings settings2)
        {
            var output = true
                && settings1.Async == settings2.Async
                && settings1.CheckCharacters == settings2.CheckCharacters
                && settings1.CloseOutput == settings2.CloseOutput
                && settings1.ConformanceLevel == settings2.ConformanceLevel
                && settings1.DoNotEscapeUriAttributes == settings2.DoNotEscapeUriAttributes
                && settings1.Encoding == settings2.Encoding
                && settings1.Indent == settings2.Indent
                && settings1.IndentChars == settings2.IndentChars
                && settings1.NamespaceHandling == settings2.NamespaceHandling
                && settings1.NewLineChars == settings2.NewLineChars
                && settings1.NewLineHandling == settings2.NewLineHandling
                && settings1.NewLineOnAttributes == settings2.NewLineOnAttributes
                && settings1.OmitXmlDeclaration == settings2.OmitXmlDeclaration
                && settings1.OutputMethod == settings2.OutputMethod
                && settings1.WriteEndDocumentOnClose == settings2.WriteEndDocumentOnClose
                ;

            return output;
        }

        /// <summary>
        /// Chooses <see cref="Equals_ByValue(XmlWriterSettings, XmlWriterSettings)"/> as the default.
        /// <para><inheritdoc cref="Equals_ByValue(XmlWriterSettings, XmlWriterSettings)" path="/summary"/></para>
        /// </summary>
        public bool Equals(
            XmlWriterSettings settings1,
            XmlWriterSettings settings2)
        {
            var output = this.Equals_ByValue(
                settings1,
                settings2);

            return output;
        }

        /// <summary>
        /// Asynchronous is the default.
        /// <inheritdoc cref="Set_Standard_Synchronous(XmlWriterSettings)" path="/summary"/>
        /// </summary>
        public void Set_Standard(XmlWriterSettings settings)
        {
            // Asynchonous.
            settings.Async = true;

            this.Set_Standard_Synchronous(settings);
        }

        /// <summary>
        /// Standard values include:
        /// <list type="bullet">
        /// <item>Indent, true</item>
        /// <item>OmitXmlDeclaration, true</item>
        /// </list>
        /// <para><inheritdoc cref="Documentation.NoteOnAsynchronousSettings" path="/summary"/></para>
        /// </summary>
        public void Set_Standard_Synchronous(XmlWriterSettings settings)
        {
            // Indent.
            settings.Indent = true;

            // Omit declaration.
            settings.OmitXmlDeclaration = true;
        }
    }
}

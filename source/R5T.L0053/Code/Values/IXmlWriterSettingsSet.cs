using System;
using System.Xml;

using R5T.T0131;
using R5T.T0143;

using R5T.L0053.Extensions;


namespace R5T.L0053
{
    [ValuesMarker]
    public partial interface IXmlWriterSettingsSet : IValuesMarker,
        L0066.IXmlWriterSettingsSet
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        L0066.IXmlWriterSettingsSet _L0066 => L0066.XmlWriterSettingsSet.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// The default writer settings contain the values set by the parameterless constructor. 
        /// </summary>
        XmlWriterSettings Default => new XmlWriterSettings();

        /// <inheritdoc cref="IXmlWriterSettingsOperator.Set_Standard(XmlWriterSettings)"/>
        XmlWriterSettings Standard => new XmlWriterSettings().Set_Standard();

        /// <inheritdoc cref="IXmlWriterSettingsOperator.Set_Standard_Synchronous(XmlWriterSettings)"/>
        XmlWriterSettings Standard_Synchronous => new XmlWriterSettings().Set_Standard_Synchronous();

        /// <summary>
        /// Useful for writing XElements just the way they are. Sets:
        /// <list type="bullet">
        /// <item><see cref="ConformanceLevel.Fragment"/></item>
        /// <item><see cref="XmlWriterSettings.Async"/> = true</item>
        /// </list>
        /// </summary>
        XmlWriterSettings Fragment => new XmlWriterSettings()
        {
            Async = true,
            ConformanceLevel = ConformanceLevel.Fragment,
        };
    }
}

using System;


namespace R5T.L0053
{
    public class XmlWriterSettingsSet : IXmlWriterSettingsSet
    {
        #region Infrastructure

        public static IXmlWriterSettingsSet Instance { get; } = new XmlWriterSettingsSet();


        private XmlWriterSettingsSet()
        {
        }

        #endregion
    }
}

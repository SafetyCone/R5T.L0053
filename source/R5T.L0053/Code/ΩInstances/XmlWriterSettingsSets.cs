using System;


namespace R5T.L0053
{
    public class XmlWriterSettingsSets : IXmlWriterSettingsSets
    {
        #region Infrastructure

        public static IXmlWriterSettingsSets Instance { get; } = new XmlWriterSettingsSets();


        private XmlWriterSettingsSets()
        {
        }

        #endregion
    }
}

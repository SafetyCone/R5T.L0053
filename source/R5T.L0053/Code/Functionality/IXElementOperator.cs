using System;
using System.Xml.Linq;

using R5T.T0132;

using IXElementOperator_Common = F10Y.L0000.IXElementOperator;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IXElementOperator : IFunctionalityMarker,
        L0066.IXElementOperator
    {
        /// <inheritdoc cref="Create_Element_FromText(string, LoadOptions)" path="/summary"/>
        /// <remarks>
        /// This might be a bad signature, since it could easily be ambiguous with <see cref="IXElementOperator_Common.Create_Element(string)"/>.
        /// </remarks>
        public XElement Create_Element(
            string xmlText,
            LoadOptions loadOptions = ILoadOptionsSets.Default_Constant)
        {
            var output = this.Create_Element_FromText(
                xmlText,
                loadOptions);

            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="IXElementOperator_Common.Parse(string, LoadOptions)"/>.
        /// </summary>
        public new XElement Create_Element_FromText(
            string xmlText,
            LoadOptions loadOptions = ILoadOptionsSets.Default_Constant)
        {
            var output = this.Parse(
                xmlText,
                loadOptions);

            return output;
        }

        public new XElement Parse(
            string xmlText,
            LoadOptions loadOptions = ILoadOptionsSets.Default_Constant)
        {
            var output = XElement.Parse(
                xmlText,
                loadOptions);

            return output;
        }
    }
}

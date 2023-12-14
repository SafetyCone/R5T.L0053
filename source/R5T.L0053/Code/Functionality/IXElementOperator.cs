using System;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IXElementOperator : IFunctionalityMarker,
        L0066.IXElementOperator
    {
        /// <inheritdoc cref="Create_Element_FromText(string, LoadOptions)" path="/summary"/>
        /// <remarks>
        /// This might be a bad signature, since it could easily be ambiguous with <see cref="L0066.IXElementOperator.Create_Element(string)"/>.
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
        /// Quality-of-life overload for <see cref="L0066.IXElementOperator.Parse(string, LoadOptions)"/>.
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

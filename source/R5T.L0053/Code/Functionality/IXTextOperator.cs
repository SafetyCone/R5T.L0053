using System;
using System.Xml.Linq;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IXTextOperator : IFunctionalityMarker
    {
        public string Get_Value(XText text)
        {
            var output = text.Value;
            return output;
        }

        public bool Is_WhitespaceOnly(XText text)
        {
            var value = this.Get_Value(text);

            var output = Instances.StringOperator.Is_WhitespaceOnly(value);
            return output;
        }
    }
}

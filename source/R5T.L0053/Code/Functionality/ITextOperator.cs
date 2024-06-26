using System;
using System.Collections.Generic;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface ITextOperator : IFunctionalityMarker,
        L0066.ITextOperator
    {
        /// <summary>
        /// If the text is one of several special string values (null, empty, newline, or tab), outputs a representation of that string instead of the string itself.
        /// Otherwise just returns the text.
        /// </summary>
        public string Get_TextRepresentation(string text)
        {
            var output = text switch
            {
                Z0000.IStrings.Empty_Constant => Instances.Strings.Empty_TextRepresentation,
                Z0000.IStrings.NewLine_NonWindows_Constant => Instances.Strings.NewLine_TextRepresentation,
                Z0000.IStrings.NewLine_Windows_Constant => Instances.Strings.NewLine_Windows,
                Z0000.IStrings.Null_Constant => Instances.Strings.Null_TextRepresentation,
                Z0000.IStrings.Tab_Constant => Instances.Strings.Tab_TextRepresentation,
                _ => text
            };

            return output;
        }
    }
}

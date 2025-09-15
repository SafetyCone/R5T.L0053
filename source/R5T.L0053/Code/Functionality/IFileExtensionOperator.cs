using System;

using R5T.T0132;
using R5T.T0143;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IFileExtensionOperator : IFunctionalityMarker,
        L0066.IFileExtensionOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        L0066.IFileExtensionOperator _L0066 => L0066.FileExtensionOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles
    }
}

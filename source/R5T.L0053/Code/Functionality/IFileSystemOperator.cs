using System;

using R5T.T0132;


namespace R5T.L0053
{
    /// <summary>
    /// Aggregate file system operator.
    /// </summary>
    [FunctionalityMarker]
    public partial interface IFileSystemOperator : IFunctionalityMarker,
        N000.IFileSystemOperator,
        N001.IFileSystemOperator
    {
        
    }
}

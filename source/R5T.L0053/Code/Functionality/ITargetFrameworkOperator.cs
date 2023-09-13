using System;
using System.Linq;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface ITargetFrameworkOperator : IFunctionalityMarker
    {
        // On hold, seems like it might not be possible.
        ///// <summary>
        ///// Gets the currently executing target framework moniker. (Example: "net6.0")
        ///// </summary>
        ///// <remarks>
        ///// Using the currently executing runtime, get the target framework moniker from the runtime directory path.
        ///// </remarks>
        //public string Get_CurrentlyExecutingTargetFrameworkMoniker()
        //{
        //    // C:\Program Files\dotnet\shared\Microsoft.NETCore.App\6.0.21\
        //    var runtimeDirectoryPath = Instances.RuntimeEnvironmentOperator.Get_RuntimeDirectoryPath();

        //    var pathParts = Instances.PathOperator.Get_DirectoryPathParts(runtimeDirectoryPath);

        //    var output = pathParts.Last();
        //    return output;
        //}
    }
}

using System;

using R5T.T0131;


namespace R5T.L0053
{
    [ValuesMarker]
    public partial interface IFilePaths : IValuesMarker
    {
        /// <summary>
        /// The path of the currently executing executable file.
        /// </summary>
        public string Executable => Instances.ExecutablePathOperator.Get_ExecutableFilePath();
    }
}

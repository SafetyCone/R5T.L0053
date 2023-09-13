using System;


namespace R5T.L0053
{
    public class DotnetPackDirectoryPathOperator : IDotnetPackDirectoryPathOperator
    {
        #region Infrastructure

        public static IDotnetPackDirectoryPathOperator Instance { get; } = new DotnetPackDirectoryPathOperator();


        private DotnetPackDirectoryPathOperator()
        {
        }

        #endregion
    }
}

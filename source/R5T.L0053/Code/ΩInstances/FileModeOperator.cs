using System;


namespace R5T.L0053
{
    public class FileModeOperator : IFileModeOperator
    {
        #region Infrastructure

        public static IFileModeOperator Instance { get; } = new FileModeOperator();


        private FileModeOperator()
        {
        }

        #endregion
    }
}

using System;


namespace R5T.L0053
{
    public class FilePaths : IFilePaths
    {
        #region Infrastructure

        public static IFilePaths Instance { get; } = new FilePaths();


        private FilePaths()
        {
        }

        #endregion
    }
}

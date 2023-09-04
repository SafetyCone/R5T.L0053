using System;


namespace R5T.L0053
{
    public class SearchPatterns : ISearchPatterns
    {
        #region Infrastructure

        public static ISearchPatterns Instance { get; } = new SearchPatterns();


        private SearchPatterns()
        {
        }

        #endregion
    }
}

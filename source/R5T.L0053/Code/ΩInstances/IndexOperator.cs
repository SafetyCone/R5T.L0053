using System;


namespace R5T.L0053
{
    public class IndexOperator : IIndexOperator
    {
        #region Infrastructure

        public static IIndexOperator Instance { get; } = new IndexOperator();


        private IndexOperator()
        {
        }

        #endregion
    }
}

using System;


namespace R5T.L0053
{
    public class DictionaryOperator : IDictionaryOperator
    {
        #region Infrastructure

        public static IDictionaryOperator Instance { get; } = new DictionaryOperator();


        private DictionaryOperator()
        {
        }

        #endregion
    }
}

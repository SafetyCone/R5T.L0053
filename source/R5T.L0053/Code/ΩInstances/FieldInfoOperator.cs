using System;


namespace R5T.L0053
{
    public class FieldInfoOperator : IFieldInfoOperator
    {
        #region Infrastructure

        public static IFieldInfoOperator Instance { get; } = new FieldInfoOperator();


        private FieldInfoOperator()
        {
        }

        #endregion
    }
}

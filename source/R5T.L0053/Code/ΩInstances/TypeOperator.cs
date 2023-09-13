using System;


namespace R5T.L0053
{
    public class TypeOperator : ITypeOperator
    {
        #region Infrastructure

        public static ITypeOperator Instance { get; } = new TypeOperator();


        private TypeOperator()
        {
        }

        #endregion
    }
}

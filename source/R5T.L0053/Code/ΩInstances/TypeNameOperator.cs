using System;


namespace R5T.L0053
{
    public class TypeNameOperator : ITypeNameOperator
    {
        #region Infrastructure

        public static ITypeNameOperator Instance { get; } = new TypeNameOperator();


        private TypeNameOperator()
        {
        }

        #endregion
    }
}

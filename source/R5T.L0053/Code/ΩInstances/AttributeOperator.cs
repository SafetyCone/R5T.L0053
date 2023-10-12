using System;


namespace R5T.L0053
{
    public class AttributeOperator : IAttributeOperator
    {
        #region Infrastructure

        public static IAttributeOperator Instance { get; } = new AttributeOperator();


        private AttributeOperator()
        {
        }

        #endregion
    }
}

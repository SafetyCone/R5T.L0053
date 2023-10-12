using System;


namespace R5T.L0053
{
    public class AttributeOperations : IAttributeOperations
    {
        #region Infrastructure

        public static IAttributeOperations Instance { get; } = new AttributeOperations();


        private AttributeOperations()
        {
        }

        #endregion
    }
}

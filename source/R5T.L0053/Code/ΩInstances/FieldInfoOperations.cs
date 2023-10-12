using System;


namespace R5T.L0053
{
    public class FieldInfoOperations : IFieldInfoOperations
    {
        #region Infrastructure

        public static IFieldInfoOperations Instance { get; } = new FieldInfoOperations();


        private FieldInfoOperations()
        {
        }

        #endregion
    }
}

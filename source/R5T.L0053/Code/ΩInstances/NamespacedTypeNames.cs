using System;


namespace R5T.L0053
{
    public class NamespacedTypeNames : INamespacedTypeNames
    {
        #region Infrastructure

        public static INamespacedTypeNames Instance { get; } = new NamespacedTypeNames();


        private NamespacedTypeNames()
        {
        }

        #endregion
    }
}

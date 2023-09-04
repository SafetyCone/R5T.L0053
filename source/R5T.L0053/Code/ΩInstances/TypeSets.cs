using System;


namespace R5T.L0053
{
    public class TypeSets : ITypeSets
    {
        #region Infrastructure

        public static ITypeSets Instance { get; } = new TypeSets();


        private TypeSets()
        {
        }

        #endregion
    }
}

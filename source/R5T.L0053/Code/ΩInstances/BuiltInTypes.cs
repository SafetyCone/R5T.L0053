using System;


namespace R5T.L0053
{
    public class BuiltInTypes : IBuiltInTypes
    {
        #region Infrastructure

        public static IBuiltInTypes Instance { get; } = new BuiltInTypes();


        private BuiltInTypes()
        {
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;


namespace R5T.L0053
{
    public class NameBasedTypeEqualityComparer : IEqualityComparer<Type>
    {
        #region Static

        public static NameBasedTypeEqualityComparer Instance { get; } = new NameBasedTypeEqualityComparer();

        #endregion


        public bool Equals(Type x, Type y)
        {
            var output = x.Name == y.Name;
            return output;
        }

        public int GetHashCode(Type obj)
        {
            var output = obj.Name.GetHashCode();
            return output;
        }
    }
}

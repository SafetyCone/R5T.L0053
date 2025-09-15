using System;


namespace R5T.L0053.Extensions
{
    public static class ArrayExtensions
    {
        public static T Get_Last<T>(this T[] arrary)
        {
            return Instances.ArrayOperator.Get_Last(arrary);
        }

        public static T SecondFromEnd<T>(this T[] array)
        {
            return Instances.ArrayOperator.Get_SecondFromEnd(array);
        }
    }
}

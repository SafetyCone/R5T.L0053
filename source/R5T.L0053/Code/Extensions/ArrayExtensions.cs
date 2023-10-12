using System;


namespace R5T.L0053.Extensions
{
    public static class ArrayExtensions
    {
        public static T[] Empty_IfNull<T>(this T[] array)
        {
            return Instances.ArrayOperator.Empty_IfNull(array);
        }

        public static int Get_IndexOfLast(this Array array)
        {
            return Instances.ArrayOperator.Get_IndexOfLast(array);
        }

        public static T Get_Last<T>(this T[] arrary)
        {
            return Instances.ArrayOperator.Get_Last(arrary);
        }

        public static T[] Null_IfEmpty<T>(this T[] array)
        {
            return Instances.ArrayOperator.Null_IfEmpty(array);
        }

        public static T SecondFromEnd<T>(this T[] array)
        {
            return Instances.ArrayOperator.Get_SecondFromEnd(array);
        }
    }
}

using System;


namespace R5T.L0053.Extensions
{
    public static class ArrayExtensions
    {
        public static T SecondFromEnd<T>(this T[] array)
        {
            return Instances.ArrayOperator.SecondFromEnd(array);
        }
    }
}

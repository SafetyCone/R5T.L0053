using System;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IArrayOperator : IFunctionalityMarker
    {
        public bool Contains<T>(
            T[] array,
            T item)
        {
            var output = Instances.EnumerableOperator.Contains(
                array,
                item);

            return output;
        }

        public T SecondFromEnd<T>(T[] array)
        {
            var output = array[^2];
            return output;
        }
    }
}

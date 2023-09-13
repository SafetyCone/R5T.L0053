using System;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IActionOperator : IFunctionalityMarker
    {
        public void Run<TValue>(
            TValue value,
            Action<TValue> action)
        {
            this.Run_OkIfDefault(
                value,
                action);
        }

        public TOutput Run<T, TOutput>(
            T value,
            Func<T, TOutput> function)
        {
            return this.Run_OkIfDefault(
                value,
                function);
        }

        public void Run_OkIfDefault<TValue>(
            TValue value,
            Action<TValue> action)
        {
            if (action == default)
            {
                return;
            }

            action(value);
        }

        public TOutput Run_OkIfDefault<T, TOutput>(
            T value,
            Func<T, TOutput> function)
        {
            if (function == default)
            {
                return default;
            }

            var output = function(value);
            return output;
        }
    }
}

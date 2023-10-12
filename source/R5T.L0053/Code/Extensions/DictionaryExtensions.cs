using System;
using System.Collections.Generic;


namespace R5T.L0053.Extensions
{
    public static class DictionaryExtensions
    {
        public static TValue AddAndReturn_Value<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue value)
        {
            return Instances.DictionaryOperator.AddAndReturn_Value(
                dictionary,
                key,
                value);
        }
    }
}

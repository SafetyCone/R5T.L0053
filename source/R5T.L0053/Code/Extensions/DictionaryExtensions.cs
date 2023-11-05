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

        public static void Add_Value<TKey, TValue>(this IDictionary<TKey, List<TValue>> dictionary,
            TKey key,
            TValue value)
        {
            Instances.DictionaryOperator.Add_Value(
                dictionary,
                key,
                value);
        }

        public static void Add_Value<TKey, TValue>(this IDictionary<TKey, IList<TValue>> dictionary,
            Func<IList<TValue>> listConstructor,
            TKey key,
            TValue value)
        {
            Instances.DictionaryOperator.Add_Value(
                dictionary,
                listConstructor,
                key,
                value);
        }
    }
}

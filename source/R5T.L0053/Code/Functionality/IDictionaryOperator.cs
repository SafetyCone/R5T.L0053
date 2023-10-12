using System;
using System.Collections.Generic;

using R5T.T0132;

using R5T.L0053.Extensions;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IDictionaryOperator : IFunctionalityMarker
    {
        public TValue Acquire_Value<TKey, TValue>(
            IDictionary<TKey, TValue> dictionary,
            TKey key,
            Func<TValue> valueConstructor)
        {
            if (dictionary.ContainsKey(key))
            {
                var value = dictionary[key];
                return value;
            }
            else
            {
                var value = valueConstructor();

                return dictionary.AddAndReturn_Value(key, value);
            }
        }

        public TValue AddAndReturn_Value<TKey, TValue>(IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue value)
        {
            dictionary.Add(key, value);

            return value;
        }

        public Dictionary<TKey, TValue> Empty<TKey, TValue>()
        {
            var output = new Dictionary<TKey, TValue>();
            return output;
        }
    }
}

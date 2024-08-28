using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0132;

using R5T.L0053.Extensions;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IDictionaryOperator : IFunctionalityMarker,
        L0066.IDictionaryOperator
    {
        public async Task<TValue> Acquire_Value<TKey, TValue>(
            IDictionary<TKey, TValue> dictionary,
            TKey key,
            Func<Task<TValue>> valueConstructor)
        {
            if (dictionary.ContainsKey(key))
            {
                var value = dictionary[key];
                return value;
            }
            else
            {
                var value = await valueConstructor();

                return dictionary.AddAndReturn_Value(key, value);
            }
        }

        public TValue AddAndReturn_Value<TKey, TValue>(IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue value)
            => this.Add_AndReturnValue(dictionary, key, value);

        public Dictionary<TKey, TValue> Combine<TKey, TValue>(
            out Dictionary<TKey, TValue[]> duplicates,
            IEnumerable<IDictionary<TKey, TValue>> dictionaries)
        {
            var output = new Dictionary<TKey, TValue>();
            var duplicates_Internal = new Dictionary<TKey, List<TValue>>();

            foreach (var dictionary in dictionaries)
            {
                foreach (var pair in dictionary)
                {
                    var added = output.TryAdd(pair.Key, pair.Value);
                    if(!added)
                    {
                        var currentValue = output[pair.Key];

                        var isFirstDuplicate = !duplicates_Internal.ContainsKey(pair.Key);
                        if(isFirstDuplicate)
                        {
                            duplicates_Internal.Add_Value(pair.Key, currentValue);
                        }

                        duplicates_Internal.Add_Value(pair.Key, pair.Value);
                    }
                }
            }

            duplicates = duplicates_Internal.ToDictionary(
                x => x.Key,
                x => x.Value.ToArray());

            return output;
        }

        public Dictionary<TKey, TValue> Combine<TKey, TValue>(
            out Dictionary<TKey, TValue[]> duplicates,
            params IDictionary<TKey, TValue>[] dictionaries)
        {
            return this.Combine(
                out duplicates,
                dictionaries.AsEnumerable());
        }

        public Dictionary<TKey, TValue> Empty<TKey, TValue>()
        {
            var output = new Dictionary<TKey, TValue>();
            return output;
        }
    }
}

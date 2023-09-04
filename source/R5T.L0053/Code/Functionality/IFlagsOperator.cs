using System;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IFlagsOperator : IFunctionalityMarker
    {
        private static Implementations.IFlagsOperator Implementations => L0053.Implementations.FlagsOperator.Instance;


        /// <summary>
        /// Works for an enumeration value of a single flag.
        /// </summary>
        public bool Has_Flag<TEnum>(TEnum value, TEnum flag)
            where TEnum : Enum
        {
            // Use the standard library's implementation, it works for both flag and flags (since both are actually just an integer value).
            var output = Implementations.Has_Flag_StandardLibrary(
                value,
                flag);

            return output;
        }

        /// <summary>
        /// Works for an enumeration value of combined flags.
        /// </summary>
        public bool Has_Flags<TEnum>(TEnum value, TEnum flags)
            where TEnum : Enum
        {
            // Use the standard library's implementation, it works for both flag and flags (since both are actually just an integer value).
            var output = Implementations.Has_Flag_StandardLibrary(
                value,
                flags);

            return output;
        }

        //public TEnum Combine<TEnum>(TEnum value, TEnum flags)
        //    where TEnum : Enum
        //{
        //    //Instances.EnumerationOperator.Verify_IsInt32Based<TEnum>();

        //    //var valueAsInt32 = Unchecked.To_Int32(value);
        //    //var flagsAsInt32 = Unchecked.To_Int32(flags);

        //    //var outputAsInt32 = valueAsInt32 | flagsAsInt32;

        //    //var output = Unchecked.From_Int32<TEnum>(outputAsInt32);
        //    //return output;

        //    var output = value | flags;
        //    return output;
        //}
    }
}

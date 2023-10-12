using System;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IFlagsOperator : IFunctionalityMarker,
        L0066.IFlagsOperator
    {
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

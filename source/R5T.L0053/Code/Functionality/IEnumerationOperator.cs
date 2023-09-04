using System;

using R5T.T0132;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IEnumerationOperator : IFunctionalityMarker
    {
        public Type Get_UnderlyingType(Enum value)
        {
            var enumerationType = value.GetType();

            var output = this.Get_UnderlyingType(enumerationType);
            return output;
        }

        public Type Get_UnderlyingType<TEnum>()
            where TEnum : Enum
        {
            var enumerationType = typeof(TEnum);

            var output = this.Get_UnderlyingType(enumerationType);
            return output;
        }

        public Type Get_UnderlyingType(Type enumerationType)
        {
            var underlyingType = Enum.GetUnderlyingType(enumerationType);
            return underlyingType;
        }

        //public bool Is<T>(Enum value, Enum flag)
        //    where T : Enum
        //{

        //}
    }
}

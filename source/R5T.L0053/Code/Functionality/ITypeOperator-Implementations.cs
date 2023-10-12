using System;

using R5T.T0132;


namespace R5T.L0053.Implementations
{
    [FunctionalityMarker]
    public partial interface ITypeOperator : IFunctionalityMarker
    {
        /// <summary>
		/// <inheritdoc cref = "Y0000.Glossary.ForType.GenericDefinition" path="/definition"/>
		/// </summary>
		public bool Is_GenericDefinition(Type type)
        {
            var isGeneric = type.IsGenericTypeDefinition;
            return isGeneric;
        }
    }
}

using System;

using R5T.T0132;

using Glossary = R5T.Y0000.Glossary;


namespace R5T.L0053
{
    [FunctionalityMarker]
    public partial interface IIndexOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Gets the last <inheritdoc cref="Glossary.ForIndex.Exclusive" path="/name"/> index from a last <inheritdoc cref="Glossary.ForIndex.Inclusive" path="/name"/> index by adding one.
        /// <para><inheritdoc cref="Glossary.ForIndex.ExclusiveInclusiveRelationship" path="/definition"/></para>
        /// </summary>
        public int Get_ExclusiveIndex(int inclusiveIndex)
        {
            var output = inclusiveIndex + 1;
            return output;
        }

        public int Get_InclusiveIndex(int exclusiveIndex)
        {
            var output = exclusiveIndex - 1;
            return output;
        }

        public bool Is_Found(int index)
        {
            var output = Instances.Indices.NotFound != index;
            return output;
        }

        /// <summary>
        /// Note: somewhat useless, since it's usually better to say what was being searched for was not found,
        /// instead of just that the result of searching was not found.
        /// But here anyway.
        /// </summary>
        public void Verify_IsFound(int index)
        {
            var isFound = this.Is_Found(index);
            if(!isFound)
            {
                throw new Exception("Index is not found.");
            }
        }

        public bool Was_Found(int index)
        {
            return this.Is_Found(index);
        }
    }
}

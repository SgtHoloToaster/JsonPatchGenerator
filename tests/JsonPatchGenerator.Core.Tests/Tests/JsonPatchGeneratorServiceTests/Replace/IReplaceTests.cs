﻿namespace JsonPatchGenerator.Core.Tests.Tests.JsonPatchGeneratorServiceTests
{
    public interface IReplaceTests
    {
        void ArrayElementPropertyReplaceOperationHasCorrectPath();
        void ArrayElementPropertyReplaceOperationHasCorrectValue();
        void ArrayElementReplaceOperationHasCorrectPath();
        void CanHandleMultipleDifferences();
        void CreateCorrectPathForNestedPropertiesOnReplace();
        void DontCreateExtraOperationsOnReplace();
        void ReplaceOperationForComplexPropertiesHasCorrectValue();
        void ReplaceOperationHasCorrectPath();
        void ReplaceOperationHasCorrectValue();
        void SimpleTypeArrayElementReplaceOperationHasCorrectValue();
        void SupportReplaceOperationForSimpleTypes();
        void SupportReplaceOperationsForNestedObjects();
        void SupportReplacingPropertiesOfArrayElement();
        void SupportReplacingValuesWithNull();
        void SupportSimpleTypeArrayElementReplacing();
        void SupportStringElementReplacing();
        void StringElementReplaceOperationHasCorrectPath();
        void StringElementReplaceOperationHasCorrectValue();
        void SupportSimpleTypeListElementReplacing();
        void SimpleTypeListElementReplaceOperationHasCorrectPath();
        void SimpleTypeListElementReplaceOperationHasCorrectValue();
        void SupportReplacingPropertiesOfListElement();
        void ListElementPropertyReplaceOperationHasCorrectPath();
        void ListElementPropertyReplaceOperationHasCorrectValue();
    }
}
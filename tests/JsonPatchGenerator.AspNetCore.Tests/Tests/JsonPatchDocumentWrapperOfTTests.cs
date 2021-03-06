﻿using JsonPatchGenerator.Core.Helpers;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace JsonPatchGenerator.AspNetCore.Tests.Tests
{
    public class JsonPatchDocumentWrapperOfTTests
    {
        [Fact]
        public void ReturnsCorrectOperationsList()
        {
            // arrange
            var (expectedOperations, operations) = GetOperations<object>();
            var jsonPatchDocument = new JsonPatchDocument<object>(operations, new DefaultContractResolver());
            var target = new JsonPatchDocumentWrapper<object>(jsonPatchDocument);

            // act
            var result = target.Operations;

            // assert
            Assert.Equal(expectedOperations, result);
        }

        [Fact]
        public void ReturnsCorrectWrappedValue()
        {
            // arrange
            var (_, expectedOperations) = GetOperations<object>();
            var jsonPatchDocument = new JsonPatchDocument<object>(expectedOperations, new DefaultContractResolver());
            var target = new JsonPatchDocumentWrapper<object>(jsonPatchDocument);

            // act
            var result = target.GetValue();

            // assert
            var resultedDocument = result as JsonPatchDocument<object>;
            Assert.NotNull(resultedDocument);
            Assert.Equal(expectedOperations, resultedDocument.Operations);
        }

        private (List<Interface.Models.Operation>, List<Operation<T>>) GetOperations<T>() where T : class
        {
            var operations = new List<Interface.Models.Operation>
            {
                new Interface.Models.Operation(Interface.Enums.OperationType.Add, "/addPath", 33),
                new Interface.Models.Operation(Interface.Enums.OperationType.Copy, "/copyPath", null, "/copyFrom"),
                new Interface.Models.Operation(Interface.Enums.OperationType.Move, "/movePath", null, "/moveFrom"),
                new Interface.Models.Operation(Interface.Enums.OperationType.Remove, "/removePath"),
                new Interface.Models.Operation(Interface.Enums.OperationType.Replace, "/replacePath", 1),
                new Interface.Models.Operation(Interface.Enums.OperationType.Test, "/testPath", "value")
            };

            var expectedOperations = operations
                .Select(o => new Operation<T>(EnumsHelper.GetEnumMemberAttributeValue(o.Type), o.Path, o.From, o.Value))
                .ToList();

            return (operations, expectedOperations);
        }
    }
}

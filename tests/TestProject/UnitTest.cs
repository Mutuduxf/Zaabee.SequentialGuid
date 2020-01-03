using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Zaabee.SequentialGuid;

namespace TestProject
{
    public class UnitTest
    {
        private const int quantity = 1000;

        [Fact]
        public void TestSequentialAsBinary()
        {
            var guids = new Guid[quantity];
            Enumerable.Range(0, 1000).AsParallel().ForAll(p =>
                guids[p] = (SequentialGuidHelper.GenerateComb(SequentialGuidType.SequentialAsBinary)));
            Assert.Equal(guids, guids.Distinct());
        }

        [Fact]
        public void TestSequentialAsString()
        {
            var guids = new Guid[quantity];
            Enumerable.Range(0, 1000).AsParallel().ForAll(p =>
                guids[p] = (SequentialGuidHelper.GenerateComb(SequentialGuidType.SequentialAsString)));
            Assert.Equal(guids, guids.Distinct());
        }

        [Fact]
        public void TestSequentialAtEnd()
        {
            var guids = new Guid[quantity];
            Enumerable.Range(0, 1000).AsParallel().ForAll(p =>
                guids[p] = (SequentialGuidHelper.GenerateComb(SequentialGuidType.SequentialAtEnd)));
            Assert.Equal(guids, guids.Distinct());
        }
    }
}
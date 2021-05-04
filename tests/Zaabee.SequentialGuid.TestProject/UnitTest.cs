using System;
using System.Linq;
using Xunit;

namespace Zaabee.SequentialGuid.TestProject
{
    public class UnitTest
    {
        private const int Quantity = 1000;

        [Theory]
        [InlineData(SequentialGuidType.SequentialAsBinary)]
        [InlineData(SequentialGuidType.SequentialAsString)]
        [InlineData(SequentialGuidType.SequentialAtEnd)]
        public void TestSequentialAsBinary(SequentialGuidType sequentialGuidType)
        {
            var guids = new Guid[Quantity];
            Enumerable.Range(0, Quantity).AsParallel().ForAll(p =>
                guids[p] = SequentialGuidHelper.GenerateComb(sequentialGuidType));
            Assert.Equal(guids, guids.Distinct());
        }
    }
}
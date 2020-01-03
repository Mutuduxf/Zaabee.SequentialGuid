using System;
using System.Linq;
using Xunit;
using Zaabee.SequentialGuid;

namespace TestProject
{
    public class UnitTest
    {
        private const int quantity = 1000;

        [Theory]
        [InlineData(SequentialGuidType.SequentialAsBinary)]
        [InlineData(SequentialGuidType.SequentialAsString)]
        [InlineData(SequentialGuidType.SequentialAtEnd)]
        public void TestSequentialAsBinary(SequentialGuidType sequentialGuidType)
        {
            var guids = new Guid[quantity];
            Enumerable.Range(0, quantity).AsParallel().ForAll(p =>
                guids[p] = (SequentialGuidHelper.GenerateComb(sequentialGuidType)));
            Assert.Equal(guids, guids.Distinct());
        }
    }
}
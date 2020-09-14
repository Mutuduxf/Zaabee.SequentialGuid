using System;

namespace Zaabee.SequentialGuid
{
    public static class SequentialGuidHelper
    {
        /// <summary>
        /// Generate Comb
        /// </summary>
        /// <returns></returns>
        public static Guid GenerateComb(SequentialGuidType sequentialGuidType = SequentialGuidType.SequentialAsString)
            => SequentialGuidGenerator.NewSequentialGuid(sequentialGuidType);
    }
}
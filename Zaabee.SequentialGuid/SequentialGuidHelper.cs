using System;
using System.Security.Cryptography;

namespace Zaabee.SequentialGuid
{
    public class SequentialGuidHelper
    {
        /// <summary>
        /// 获取有序的唯一ID。
        /// </summary>
        /// <returns></returns>
        public static Guid GenerateComb(SequentialGuidType sequentialGuidType = SequentialGuidType.SequentialAsString)
        {
            return SequentialGuidGenerator.NewSequentialGuid(sequentialGuidType);
        }

        /// <summary>
        /// Sequential guid generator
        /// http://www.codeproject.com/Articles/388157/GUIDs-as-fast-primary-keys-under-multiple-database
        /// </summary>
        private static class SequentialGuidGenerator
        {
            private static readonly RNGCryptoServiceProvider Rng = new RNGCryptoServiceProvider();

            public static Guid NewSequentialGuid(SequentialGuidType guidType)
            {
                var randomBytes = new byte[10];
                Rng.GetBytes(randomBytes);

                var timestamp = DateTime.UtcNow.Ticks / 10000L;
                var timestampBytes = BitConverter.GetBytes(timestamp);

                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(timestampBytes);
                }

                var guidBytes = new byte[16];

                switch (guidType)
                {
                    case SequentialGuidType.SequentialAsString:
                    case SequentialGuidType.SequentialAsBinary:
                        Buffer.BlockCopy(timestampBytes, 2, guidBytes, 0, 6);
                        Buffer.BlockCopy(randomBytes, 0, guidBytes, 6, 10);

                        // If formatting as a string, we have to reverse the order
                        // of the Data1 and Data2 blocks on little-endian systems.
                        if (guidType == SequentialGuidType.SequentialAsString && BitConverter.IsLittleEndian)
                        {
                            Array.Reverse(guidBytes, 0, 4);
                            Array.Reverse(guidBytes, 4, 2);
                        }

                        break;

                    case SequentialGuidType.SequentialAtEnd:
                        Buffer.BlockCopy(randomBytes, 0, guidBytes, 0, 10);
                        Buffer.BlockCopy(timestampBytes, 2, guidBytes, 10, 6);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(guidType), guidType, null);
                }

                return new Guid(guidBytes);
            }
        }

        /// <summary>
        /// Sequential guid type（AtEnd for sqlServer,AsString/AsBinary for mysql,AsBinary for oracle,AsString/AsBinary for postgresql.）
        /// </summary>
        public enum SequentialGuidType
        {
            SequentialAsString,
            SequentialAsBinary,
            SequentialAtEnd
        }
    }
}
namespace Zaabee.SequentialGuid
{

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
using System.Collections.Generic;

namespace YouTrack.Rest
{
    public interface IChangedField
    {
        string Name { get; }
        IEnumerable<string> Values { get; }
        IEnumerable<string> OldValues { get; }
        IEnumerable<string> NewValues { get; }
    }
}
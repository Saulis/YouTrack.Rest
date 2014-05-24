using System.Collections.Generic;

namespace YouTrack.Rest
{
    public interface ICustomField
    {
        string Name { get; set; }
        IEnumerable<string> Values { get; set; }
    }
}

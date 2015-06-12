using System.Collections.Generic;
using System.Linq;

namespace YouTrack.Rest.Deserialization
{
    class ChangeCollection
    {
        public List<Change> Changes { get; set; }

        public IEnumerable<IChange> GetChanges(IConnection connection)
        {
            return Changes.Select(c => c.GetChange(connection)).ToArray();
        } 
    }
}
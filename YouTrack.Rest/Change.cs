using System;
using System.Collections.Generic;

namespace YouTrack.Rest
{
    public class Change: IChange
    {
        public Change()
        {
            ChangedFields = new Dictionary<string, IChangedField>(StringComparer.InvariantCultureIgnoreCase);
        }

        public DateTime Updated { get; internal set; }

        public string UpdaterName { get; internal set; }

        public IDictionary<string, IChangedField> ChangedFields { get; private set; }
    }
}
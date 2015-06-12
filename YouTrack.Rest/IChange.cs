using System;
using System.Collections.Generic;

namespace YouTrack.Rest
{
    public interface IChange
    {
        DateTime Updated { get; }
        string UpdaterName { get; }

        IDictionary<string, IChangedField> ChangedFields { get; }
    }
}
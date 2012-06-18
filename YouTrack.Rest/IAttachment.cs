using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouTrack.Rest
{
    public interface IAttachment
    {
        string Url { get; }
        string Name { get; }
    }
}

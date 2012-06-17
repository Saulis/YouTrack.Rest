using System;
using System.Collections.Generic;
using System.Linq;

namespace YouTrack.Rest
{
    internal class Field
    {
        public string Name { get; set; }
        public List<Value_> Values { get; set; }

        public string GetSingleValue()
        {
            return Values.Single().Value;
        }

        public override string ToString()
        {
            return String.Format("{0}: {1}", Name, String.Join(", ", Values.Select(v => v.ToString())));
        }
    }
}
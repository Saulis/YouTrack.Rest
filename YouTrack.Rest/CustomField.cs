using System.Collections.Generic;

namespace YouTrack.Rest
{
    class CustomField : ICustomField
    {
        public string Name { get; set; }
        public IEnumerable<string> Values { get; set; }

        public CustomField(string name, IEnumerable<string> values)
        {
            Name = name;
            Values = values;
        }
    }
}

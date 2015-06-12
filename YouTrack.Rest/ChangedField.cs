using System.Collections.Generic;
using YouTrack.Rest.Deserialization;

namespace YouTrack.Rest
{
    class ChangedField : IChangedField
    {
        public ChangedField(Field field)
        {
            Name = field.Name;
            
            if (null != field.Values)
                Values = field.Values.ConvertAll(v => v.ToString());
            
            if (null != field.NewValues)
                NewValues = field.NewValues.ConvertAll(v => v.ToString());

            if (null != field.OldValues)
                OldValues = field.OldValues.ConvertAll(v => v.ToString());
        }

        public string Name { get; private set; }

        public IEnumerable<string> Values { get; private set; }

        public IEnumerable<string> OldValues { get; private set; }

        public IEnumerable<string> NewValues { get; private set; }
    }
}
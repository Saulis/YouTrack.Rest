using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp.Deserializers;
using YouTrack.Rest.Exceptions;

namespace YouTrack.Rest.Deserialization
{
    class Field
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<Value_> Values { get; set; }

        // issue field value changes
        public List<NewValue> NewValues { get; set; }
        public List<OldValue> OldValues { get; set; }

        public string GetValue()
        {
            if(HasSingleValue())
            {
                return Values.Single().Value;
            }

            throw new IssueDeserializationException(String.Format("Field '{0}' has {1} values.", Name, Values.Count));
        }

        private bool HasSingleValue()
        {
            return Values.Count() == 1;
        }

        public override string ToString()
        {
            return String.Format("{0}: {1}", Name, String.Join(", ", Values.Select(v => v.ToString())));
        }

        public DateTime GetDateTime()
        {
            ulong millis = Convert.ToUInt64(GetValue());

            DateTime youtrackBaseTime = new DateTime(1970, 1, 1);
            DateTime datetimeGmt = youtrackBaseTime.AddMilliseconds(millis);
            DateTime localTime = datetimeGmt.ToLocalTime();

            return localTime;
        }

        public int GetInt32()
        {
            return Convert.ToInt32(GetValue());
        }
    }
}
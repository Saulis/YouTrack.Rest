using System.Collections.Generic;
using System.Linq;

namespace YouTrack.Rest
{
    class IssueDeserializer
    {
        public string Id { get; set; }
        public List<Field> Fields { get; set; }

        public IIssue GetIssue()
        {
            Issue issue = new Issue();

            issue.Id = Id;
            issue.Type = GetSingleFieldValueFor("Type");
            issue.Summary = GetSingleFieldValueFor("summary");
            issue.ProjectShortName = GetSingleFieldValueFor("projectShortName");

            return issue;
        }

        private string GetSingleFieldValueFor(string name)
        {
            if (HasSingleFieldFor(name))
            {
                return GetSingleFieldFor(name).GetSingleValue();
            }

            return null;
        }

        private bool HasSingleFieldFor(string name)
        {
            return Fields.Count(f => f.Name == name) == 1;
        }

        private Field GetSingleFieldFor(string name)
        {
            return Fields.Single(f => f.Name == name);
        }
    }
}
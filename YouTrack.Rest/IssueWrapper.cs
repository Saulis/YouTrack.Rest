using System.Collections.Generic;
using System.Linq;

namespace YouTrack.Rest
{
    internal class IssueWrapper
    {
        public string Id { get; set; }
        public List<Field> Fields { get; set; }

        public virtual IIssue Deserialize(IConnection connection)
        {
            Issue issue = new Issue(Id, connection);

            issue.Type = GetSingleFieldValueFor("Type");
            issue.Summary = GetSingleFieldValueFor("summary");
            issue.ProjectShortName = GetSingleFieldValueFor("projectShortName");
            /*
             * TODO: 
             * jiraId
             * numberInProject
             * description
             * created
             * updated
             * updaterName
             * resolved
             * reporterName
             * commentsCount
             * votes
             * permittedGroup
             * comment
             * tag
             * custom fields
             */

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
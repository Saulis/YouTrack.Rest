using System;
using System.Collections.Generic;
using System.Linq;
using YouTrack.Rest.Interception;
using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Issues;

namespace YouTrack.Rest
{
    class Issue : IssueActions, IIssue, ILoadable
    {
        public string Summary { get; set; }
        public string Type { get; set; }
        public string ProjectShortName { get; set; }
        public string Description { get; internal set; }
        public int NumberInProject { get; internal set; }
        public DateTime Created { get; internal set; }
        public DateTime Updated { get; internal set; }
        public string UpdaterName { get; internal set; }
        public string ReporterName { get; internal set; }
        public int VotesCount { get; internal set; }
        public int CommentsCount { get; internal set; }
        public string Priority { get; internal set; }
        public string State { get; internal set; }
        public string Subsystem { get; internal set; }
        public IEnumerable<ICustomField> CustomFields { get; internal set; }

        public bool IsLoaded { get; private set; }

        public void Load()
        {
            GetIssueRequest request = new GetIssueRequest(Id);

            Deserialization.Issue issue = Connection.Get<Deserialization.Issue>(request);

            issue.MapTo(this, Connection);

            IsLoaded = true;
        }

        public Issue(string issueId, IConnection connection)
            : base(issueId, connection)
        {
            IsLoaded = false;
        }

        public override void ApplyCommand(string command)
        {
            base.ApplyCommand(command);

            IsLoaded = false;
        }

        public override void ApplyCommands(params string[] commands)
        {
            base.ApplyCommands(commands);

            IsLoaded = false;
        }

        public string GetCustomFieldValue(string fieldName)
        {
            IEnumerable<string> values = GetCustomFieldValues(fieldName);
            if (values != null)
            {
                int valuesCount = values.Count();

                if (valuesCount > 1)
                {
                    throw new IndexOutOfRangeException(
                        string.Format("Found {0} values for custom field '{1}', but expected only one.",
                        VotesCount, fieldName));
                }

                return values.First();
            }

            return null;
        }

        public IEnumerable<string> GetCustomFieldValues(string fieldName)
        {
            if (CustomFields != null)
            {
                foreach (ICustomField field in CustomFields)
                {
                    if (field.Name == fieldName)
                    {
                        return field.Values;
                    }
                }
            }

            return null;
        }
    }
}
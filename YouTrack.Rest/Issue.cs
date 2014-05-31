using System;
using System.Collections.Generic;
using System.Linq;
using YouTrack.Rest.Exceptions;
using YouTrack.Rest.Interception;
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
        public IDictionary<string, IEnumerable<string>> Fields { get; internal set; }

        public bool IsLoaded { get; private set; }

        public void Load()
        {
            GetIssueRequest request = new GetIssueRequest(Id);

            Deserialization.Issue issue = Connection.Get<Deserialization.Issue>(request);

            issue.MapTo(this, Connection);

            IsLoaded = true;
        }

        public Issue(string issueId, IConnection connection) : base(issueId, connection)
        {
            Fields = new Dictionary<string, IEnumerable<string>>(StringComparer.InvariantCultureIgnoreCase);
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

        public bool HasField(string fieldName)
        {
            return Fields != null && Fields.ContainsKey(fieldName);
        }

        public string GetFieldValue(string fieldName)
        {
            if (!HasField(fieldName))
            {
                return string.Empty;
            }

            IEnumerable<string> values = GetFieldValues(fieldName);

            if (values.Count() == 1)
            {
                return values.Single();
            }

            throw new UnexpectedMultipleFieldValuesException(string.Format("Expected a single value for field '{0}', got {1} values.", fieldName, values.Count()));
        }

        public IEnumerable<string> GetFieldValues(string fieldName)
        {
            if (HasField(fieldName))
            {
                return Fields[fieldName];
            }

            return new string[0];
        }


    }
}
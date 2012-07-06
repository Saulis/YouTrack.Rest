using System;
using System.Linq;
using YouTrack.Rest.Factories;
using YouTrack.Rest.Interception;
using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Issues;

namespace YouTrack.Rest
{
    class Issue : IssueActions, IIssue, ILoadable
    {
        private readonly IIssueRequestFactory issueRequestFactory;
        public event EventHandler Loaded;

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

        public bool IsLoaded { get; private set; }

        public void Load()
        {
            IYouTrackGetRequest<IIssue> request = issueRequestFactory.GetIssueRequest(this, Connection);

            request.Execute();

            OnLoaded(); 
        }

        public void OnLoaded()
        {
            IsLoaded = true;

            EventHandler handler = Loaded;
            if (handler != null) handler(this, new EventArgs());
        }

        public Issue(string issueId, IConnection connection, IIssueRequestFactory issueRequestFactory)
            : base(issueId, connection)
        {
            this.issueRequestFactory = issueRequestFactory;
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
    }
}
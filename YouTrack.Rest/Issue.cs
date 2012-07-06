using System;
using System.Linq;
using YouTrack.Rest.Factories;
using YouTrack.Rest.Interception;
using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Issues;

namespace YouTrack.Rest
{
    class LoadableIssue : Issue, ILoadable
    {
        public LoadableIssue(string issueId, IConnection connection, IIssueRequestFactory issueRequestFactory) : base(issueId, connection, issueRequestFactory)
        {
            IsLoaded = false;
        }

        public event EventHandler Loaded;
        public bool IsLoaded { get; private set; }

        public void Load()
        {
            IYouTrackGetRequest<IIssue> request = IssueRequestFactory.GetIssueRequest(this, Connection);

            request.Execute();

            OnLoaded();
        }

        public void OnLoaded()
        {
            IsLoaded = true;

            EventHandler handler = Loaded;
            if (handler != null) handler(this, new EventArgs());
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

    class Issue : IssueActions, IIssue
    {
        protected IIssueRequestFactory IssueRequestFactory { get; set; }

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

        public Issue(string issueId, IConnection connection, IIssueRequestFactory issueRequestFactory)
            : base(issueId, connection)
        {
            IssueRequestFactory = issueRequestFactory;
        }

    }
}
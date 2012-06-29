using System;
using System.Collections.Generic;
using YouTrack.Rest.Deserialization;

namespace YouTrack.Rest.Tests.Repositories
{
    class DeserializedIssueMock : Rest.Deserialization.Issue
    {
        private readonly IIssue issue;

        public const string IssueId = "FOO-BAR";
        public const string ProjectShortName = "FOO";
        public const string Summary = "Summary";
        public const string Type = "Bug";
        public const int CommentsCount = 1;
        public const int NumberInProject = 3;
        public const string Description = "desc";
        public const string Priority = "urgent";
        public const string ReporterName = "reporter";
        public const string UpdaterName = "updater";
        public const string Subsystem = "sub";
        public const string State = "foobar";
        public const int VotesCount = 2;
        public const int UpdatedMillis = 2123;
        public const int CreatedMillis = 1234;

        public DeserializedIssueMock()
        {
            Fields = CreateFields();
            Comments = CreateComments();
        }

        public DeserializedIssueMock(IIssue issue)
        {
            this.issue = issue;
        }

        public override IIssue GetIssue(IConnection connection)
        {
            return issue;
        }

        private List<Field> CreateFields()
        {
            List<Field> fields = new List<Field>();

            fields.Add(CreateField("projectShortName", ProjectShortName));
            fields.Add(CreateField("summary", Summary));
            fields.Add(CreateField("Type", Type));
            fields.Add(CreateField("commentsCount", CommentsCount.ToString()));
            fields.Add(CreateField("created", CreatedMillis.ToString()));
            fields.Add(CreateField("description", Description));
            fields.Add(CreateField("numberInProject", NumberInProject.ToString()));
            fields.Add(CreateField("priority", Priority));
            fields.Add(CreateField("reporterName", ReporterName));
            fields.Add(CreateField("updaterName", UpdaterName));
            fields.Add(CreateField("state", State));
            fields.Add(CreateField("subsystem", Subsystem));
            fields.Add(CreateField("updated", UpdatedMillis.ToString()));
            fields.Add(CreateField("votes", VotesCount.ToString()));

            return fields;
        }

        private static List<Rest.Deserialization.Comment> CreateComments()
        {
            return new List<Rest.Deserialization.Comment>() { new Rest.Deserialization.Comment() { Id = "commentId" } };
        }


        private static Field CreateField(string name, string value)
        {
            Value_ value_ = new Value_() { Value = value };

            Field field = new Field() { Name = name, Values = new List<Value_> { value_ } };

            return field;
        }
    }
}
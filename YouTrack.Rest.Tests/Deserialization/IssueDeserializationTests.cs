using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using YouTrack.Rest.Deserialization;
using YouTrack.Rest.Exceptions;
using YouTrack.Rest.Tests.Repositories;

namespace YouTrack.Rest.Tests.Deserialization
{
    class IssueDeserializationTests : TestFor<Rest.Deserialization.Issue>
    {
        private IConnection connection;
        private List<Rest.Deserialization.Comment> comments;
        private Issue issue;
        private const string IssueId = "FOO-BAR";

        protected override void SetupDependencies()
        {
            DeserializedIssueMock deserializedIssueMock = new DeserializedIssueMock();

            comments = deserializedIssueMock.Comments;

            Sut.Id = IssueId;
            Sut.Fields = deserializedIssueMock.Fields;
            Sut.Comments = comments;
            connection = Mock<IConnection>();

            issue = new Issue(IssueId, connection);
        }

        [Test]
        public void ProjectShortNameIsWrapped()
        {
            Sut.MapTo(issue, connection);

            Assert.That(issue.ProjectShortName, Is.EqualTo(DeserializedIssueMock.ProjectShortName));
        }

        [Test]
        public void SummaryIsWrapped()
        {
            Sut.MapTo(issue, connection);

            Assert.That(issue.Summary, Is.EqualTo(DeserializedIssueMock.Summary));
        }

        [Test]
        public void TypeIsWrapped()
        {
            Sut.MapTo(issue, connection);

            Assert.That(issue.Type, Is.EqualTo(DeserializedIssueMock.Type));
        }

        [Test]
        public void CommentsCountIsWrapped()
        {
            Sut.MapTo(issue, connection);

            Assert.That(issue.CommentsCount, Is.EqualTo(DeserializedIssueMock.CommentsCount));
        }

        [Test]
        public void CreatedIsWrapped()
        {
            Sut.MapTo(issue, connection);

            Assert.That(GetYouTrackMilliseconds(issue.Created), Is.EqualTo(DeserializedIssueMock.CreatedMillis));
        }

        [Test]
        public void DescriptionIsWrapped()
        {
            Sut.MapTo(issue, connection);

            Assert.That(issue.Description, Is.EqualTo(DeserializedIssueMock.Description));
        }

        [Test]
        public void NumberInProjectIsWrapped()
        {
            Sut.MapTo(issue, connection);

            Assert.That(issue.NumberInProject, Is.EqualTo(DeserializedIssueMock.NumberInProject));
        }

        [Test]
        public void ReporterNameIsWrapped()
        {
            Sut.MapTo(issue, connection);

            Assert.That(issue.ReporterName, Is.EqualTo(DeserializedIssueMock.ReporterName));
        }

        [Test]
        public void StateIsWrapped()
        {
            Sut.MapTo(issue, connection);

            Assert.That(issue.State, Is.EqualTo(DeserializedIssueMock.State));
        }

        [Test]
        public void SubsystemIsWrapped()
        {
            Sut.MapTo(issue, connection);

            Assert.That(issue.Subsystem, Is.EqualTo(DeserializedIssueMock.Subsystem));
        }

        [Test]
        public void UpdatedIsWrapped()
        {
            Sut.MapTo(issue, connection);

            Assert.That(GetYouTrackMilliseconds(issue.Updated), Is.EqualTo(DeserializedIssueMock.UpdatedMillis));
        }

        private double GetYouTrackMilliseconds(DateTime value)
        {
            return value.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds;
        }

        [Test]
        public void UpdaterNameIsWrapped()
        {
            Sut.MapTo(issue, connection);

            Assert.That(issue.UpdaterName, Is.EqualTo(DeserializedIssueMock.UpdaterName));
        }

        [Test]
        public void VotesCountIsWrapped()
        {
            Sut.MapTo(issue, connection);

            Assert.That(issue.VotesCount, Is.EqualTo(DeserializedIssueMock.VotesCount));
        }

        [Test]
        public void CommentsAreSet()
        {
            Sut.MapTo(issue, connection);

            AssertThatCommentIdsMatch(comments, issue.Comments);
        }

        private void AssertThatCommentIdsMatch(IEnumerable<Rest.Deserialization.Comment> expectedComments, IEnumerable<IComment> actualComments)
        {
            Assert.That(actualComments.Select(c => c.Id), Is.EquivalentTo(expectedComments.Select(c => c.Id)));
        }

        [Test]
        public void EmptyStringIsReturnedInsteadOfNullDescription()
        {
            RemoveDescriptionField();

            Sut.MapTo(issue, connection);

            Assert.That(issue.Description, Is.EqualTo(String.Empty));
        }

        [Test]
        public void ExceptionIsThrownOnMultipleFields()
        {
            AddAnotherDescriptionField();

            Assert.Throws<IssueSerializationException>(() => Sut.GetIssue(connection));
        }

        private void AddAnotherDescriptionField()
        {
            Field descriptionField = new Field {Name = "description"};

            Sut.Fields.Add(descriptionField);
        }

        private void RemoveDescriptionField()
        {
            Field descriptionField = Sut.Fields.Single(f => f.Name == "description");

            Sut.Fields.Remove(descriptionField);
        }
    }
}

using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using YouTrack.Rest.Deserialization;
using YouTrack.Rest.Interception;
using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Issues;
using YouTrack.Rest.Tests.Repositories;

namespace YouTrack.Rest.Tests
{
    class IssueTests : TestFor<Issue>
    {
        private IConnection connection;
        private const string IssueId = "FOO-BAR";
        private FileUrlCollection fileUrlCollection;
        private CommentCollection commentCollection;

        protected override Issue CreateSut()
        {
            connection = Mock<IConnection>();
            return new Issue("FOO-BAR", connection);
        }

        protected override void SetupDependencies()
        {
            connection.Get<Rest.Deserialization.Issue>(Arg.Any<GetIssueRequest>()).Returns(new DeserializedIssueMock());
            fileUrlCollection = new FileUrlCollection();
            commentCollection = new CommentCollection { Comments = new List<Rest.Deserialization.Comment>() };
        }

        [Test]
        public void IsNotLoadedWhenConstructed()
        {
            Assert.IsFalse(((ILoadable)Sut).IsLoaded);
        }

        [Test]
        public void LoadSetLoaded()
        {
            ILoadable loadable = Sut;

            loadable.Load();

            Assert.IsTrue(loadable.IsLoaded);
        }

        [Test]
        public void ConnectionIsCalledWithAddComment()
        {
            Sut.AddComment("foobar");

            connection.Received().Post(Arg.Any<AddCommentToIssueRequest>());
        }

        [Test]
        public void CommentIsDeleted()
        {
            Sut.RemoveComment("foobar");

            connection.Received().Delete(Arg.Any<RemoveACommentForAnIssueRequest>());
        }

        [Test]
        public void CommentsAreFetchedAgainAfterAddingComment()
        {
            connection.Get<CommentCollection>(Arg.Any<GetCommentsOfAnIssueRequest>()).Returns(commentCollection);

            IEnumerable<IComment> comments = Sut.Comments;
            Sut.AddComment("foobar");
            comments = Sut.Comments;

            connection.Received(2).Get<CommentCollection>(Arg.Any<GetCommentsOfAnIssueRequest>());
        }

        [Test]
        public void ConnectionIsCalledWithAttachFile()
        {
            Sut.AttachFile("foo.jpg");

            connection.Received().PostWithFile(Arg.Any<AttachFileToAnIssueRequest>());
        }

        [Test]
        public void ConnectionIsCalledWithAttachFileWithBytes()
        {
            Sut.AttachFile("foo.txt", new byte[512]);

            connection.Received().PostWithFile(Arg.Any<AttachFileToAnIssueRequest>());
        }

        [Test]
        public void ConnectionIsCalledWithGetAttachments()
        {
            connection.Get<FileUrlCollection>(Arg.Any<GetAttachmentsOfAnIssueRequest>()).Returns(fileUrlCollection);

            Sut.GetAttachments();

            connection.Received().Get<FileUrlCollection>(Arg.Any<GetAttachmentsOfAnIssueRequest>());
        }

        [Test]
        public void ConnectionIsCalledWithGetComments()
        {
            connection.Get<CommentCollection>(Arg.Any<GetCommentsOfAnIssueRequest>()).Returns(commentCollection);

            IEnumerable<IComment> comments = Sut.Comments;

            connection.Received().Get<CommentCollection>(Arg.Any<GetCommentsOfAnIssueRequest>());
        }

        [Test]
        public void ConnectionIsCalledWithSetSubsystem()
        {
            Sut.SetSubsystem("Foobar");

            connection.Received().Post(Arg.Any<ApplyCommandToAnIssueRequest>());
        }

        [Test]
        public void SubsystemIsApplied()
        {
            Sut.SetSubsystem("Foobar");

            AssertThatCommandIsApplied("Subsystem Foobar");
        }

        private void AssertThatCommandIsApplied(string command)
        {
            connection.Received().Post(Arg.Is<ApplyCommandToAnIssueRequest>(x => x.RestResource == String.Format("/rest/issue/{0}/execute?command={1}", IssueId, Uri.EscapeDataString(command))));
        }

        private void AssertThatCommandsAreApplied(string commands)
        {
            connection.Received().Post(Arg.Is<ApplyCommandsToAnIssueRequest>(x => x.RestResource == String.Format("/rest/issue/{0}/execute?command={1}", IssueId, Uri.EscapeDataString(commands))));
        }

        [Test]
        public void ConnectionIsCalledWithSetType()
        {
            Sut.SetType("Foobar");

            connection.Received().Post(Arg.Any<ApplyCommandToAnIssueRequest>());
        }

        [Test]
        public void TypeIsApplied()
        {
            Sut.SetType("foobar");

            AssertThatCommandIsApplied("Type foobar");
        }

        [Test]
        public void MultipleCommandsAreApplied()
        {
            Sut.ApplyCommands("Foo", "Bar");

            AssertThatCommandsAreApplied("Foo Bar");
        }

        [Test]
        public void IssueStatusNotLoadedAfterApplyingCommand()
        {
            Sut.Load();

            Sut.ApplyCommands("Foo", "Bar");

            Assert.IsFalse(Sut.IsLoaded);
        }
    }
}

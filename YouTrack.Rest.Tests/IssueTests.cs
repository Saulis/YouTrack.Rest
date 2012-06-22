using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSubstitute;
using NUnit.Framework;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Tests
{
    class IssueTests : TestFor<Issue>
    {
        private IConnection connection;
        private FileUrlsWrapper fileUrlsWrapper;
        private CommentsWrapper commentsWrapper;

        protected override Issue CreateSut()
        {
            connection = Mock<IConnection>();

            return new Issue("FOO-BAR", connection);
        }

        protected override void SetupDependencies()
        {
            fileUrlsWrapper = new FileUrlsWrapper();
            commentsWrapper = new CommentsWrapper { Comments = new List<Comment>() };
        }

        [Test]
        public void ConnectionIsCalledWithAddComment()
        {
            Sut.AddComment("foobar");

            connection.Received().Post(Arg.Any<AddCommentToIssueRequest>());
        }

        [Test]
        public void CommentsAreFetchedAgainAfterAddingComment()
        {
            connection.Get<CommentsWrapper>(Arg.Any<GetCommentsOfAnIssueRequest>()).Returns(commentsWrapper);

            ICollection<IComment> comments = Sut.Comments;
            Sut.AddComment("foobar");
            comments = Sut.Comments;

            connection.Received(2).Get<CommentsWrapper>(Arg.Any<GetCommentsOfAnIssueRequest>());
        }

        [Test]
        public void ConnectionIsCalledWithAttachFile()
        {
            Sut.AttachFile("foo.jpg");

            connection.Received().PostWithFile(Arg.Any<AttachFileToAnIssueRequest>());
        }

        [Test]
        public void ConnectionIsCalledWithGetAttachments()
        {
            connection.Get<FileUrlsWrapper>(Arg.Any<GetAttachmentsOfAnIssueRequest>()).Returns(fileUrlsWrapper);

            Sut.GetAttachments();

            connection.Received().Get<FileUrlsWrapper>(Arg.Any<GetAttachmentsOfAnIssueRequest>());
        }

        [Test]
        public void ConnectionIsCalledWithGetComments()
        {
            connection.Get<CommentsWrapper>(Arg.Any<GetCommentsOfAnIssueRequest>()).Returns(commentsWrapper);

            ICollection<IComment> comments = Sut.Comments;

            connection.Received().Get<CommentsWrapper>(Arg.Any<GetCommentsOfAnIssueRequest>());
        }
    }
}

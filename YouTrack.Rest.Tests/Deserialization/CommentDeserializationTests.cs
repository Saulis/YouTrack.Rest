using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace YouTrack.Rest.Tests.Deserialization
{
    class CommentDeserializationTests : TestFor<Rest.Deserialization.Comment>
    {
        private IConnection connection;
        private const string CommentId = "Foo";
        private const string IssueId = "Bar";

        protected override void SetupDependencies()
        {
            Sut.Id = CommentId;
            Sut.IssueId = IssueId;

            connection = Mock<IConnection>();
        }

        [Test]
        public void CommentIsReturned()
        {
            IComment comment = Sut.GetComment(connection);

            Assert.That(comment, Is.TypeOf<Comment>());
        }

        [Test]
        public void IdIsAssigned()
        {
            Assert.That(Sut.GetComment(connection).Id, Is.EqualTo(CommentId));
        }

        [Test]
        public void IssueIdIsAssigned()
        {
            Assert.That(Sut.GetComment(connection).IssueId, Is.EqualTo(IssueId));
        }
    }
}

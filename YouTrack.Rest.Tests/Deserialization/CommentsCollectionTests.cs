using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using YouTrack.Rest.Deserialization;

namespace YouTrack.Rest.Tests.Deserialization
{
    class CommentsCollectionTests : TestFor<CommentsCollection>
    {
        private Rest.Deserialization.Comment deserializedComment;
        private List<Rest.Deserialization.Comment> deserializedComments;
        private IConnection connection;

        protected override void SetupDependencies()
        {
            connection = Mock<IConnection>();

            deserializedComments = new List<Rest.Deserialization.Comment>();
            deserializedComment = Mock<Rest.Deserialization.Comment>();
            deserializedComments.Add(deserializedComment);

            Sut.Comments = deserializedComments;
        }

        [Test]
        public void GetCommentCalledOnEachComment()
        {
            IEnumerable<IComment> comments = Sut.GetComments(connection).ToList();

            deserializedComment.Received().GetComment(connection);
        }
    }
}

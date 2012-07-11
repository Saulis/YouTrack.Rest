using NUnit.Framework;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Tests.Requests
{
    abstract class AttachFileToAnIssueRequestTests :YouTrackRequestTests<AttachFileToAnIssueRequest, IYouTrackPostWithFileRequest>
    {
        protected override string ExpectedRestResource
        {
            get { return "/rest/issue/FOO-BAR/attachment?name=foo"; }
        }

        [Test]
        public void NameIsFiles()
        {
            Assert.That(Sut.Name, Is.EqualTo("files"));
        }

    }

    class AttachFileToAnIssueRequestWithFilenameTests : AttachFileToAnIssueRequestTests
    {
        protected override AttachFileToAnIssueRequest CreateSut()
        {
            return new AttachFileToAnIssueRequest("FOO-BAR", "foo.jpg");
        }

        [Test]
        public void FilePathIsSet()
        {
            Assert.That(Sut.FilePath, Is.EqualTo("foo.jpg"));
        }

        [Test]
        public void DoesNotHaveBytes()
        {
            Assert.IsFalse(Sut.HasBytes);
        }
    }

    class AttachFileToAnIssueRequestWithBytesTests : AttachFileToAnIssueRequestTests
    {
        private byte[] bytes;

        protected override AttachFileToAnIssueRequest CreateSut()
        {
            bytes = new byte[16];
            return new AttachFileToAnIssueRequest("FOO-BAR", "foo.jpg", bytes);
        }

        [Test]
        public void HasBytes()
        {
            Assert.That(Sut.HasBytes);
        }

        [Test]
        public void ReturnsBytes()
        {
            Assert.That(Sut.Bytes, Is.EqualTo(bytes));
        }
    }
}

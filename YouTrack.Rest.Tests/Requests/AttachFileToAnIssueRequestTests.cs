using NUnit.Framework;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Tests.Requests
{
    class AttachFileToAnIssueRequestTests :YouTrackRequestTests<AttachFileToAnIssueRequest, IYouTrackPostWithFileRequest>
    {
        protected override AttachFileToAnIssueRequest CreateSut()
        {
            return new AttachFileToAnIssueRequest("FOO-BAR", "foo.jpg");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/issue/FOO-BAR/attachment?name=foo"; }
        }

        [Test]
        public void FilePathIsSet()
        {
            Assert.That(Sut.FilePath, Is.EqualTo("foo.jpg"));
        }

        [Test]
        public void NameIsFiles()
        {
            Assert.That(Sut.Name, Is.EqualTo("files"));
        }
    }
}

using NUnit.Framework;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Tests.Requests
{
    abstract class YouTrackRequestTests<TRequest> : TestFor<TRequest> where TRequest : YouTrackRequest
    {
        protected abstract string ExpectedRestResource { get; }

        [Test]
        public void VerifyRestResource()
        {
            Assert.That(Sut.RestResource, Is.EqualTo(ExpectedRestResource));
        }
    }
}
using NUnit.Framework;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Tests.Requests
{
    abstract class YouTrackRequestTests<TRequest, TRequestType> : TestFor<TRequest> where TRequest : YouTrackRequest where TRequestType : IYouTrackRequest
    {
        protected abstract string ExpectedRestResource { get; }

        [Test]
        public void VerifyRestResource()
        {
            Assert.That(Sut.RestResource, Is.EqualTo(ExpectedRestResource));
        }

        [Test]
        public void VerifyRequestType()
        {
            Assert.That(Sut, Is.AssignableTo<TRequestType>());
        }

        [Test]
        public void HasBody()
        {
            Sut.Body = "foobar";

            Assert.That(Sut.HasBody);
        }

        [Test]
        public void DoesNotHaveBody()
        {
            Sut.Body = null;

            Assert.IsFalse(Sut.HasBody);
        }
    }
}
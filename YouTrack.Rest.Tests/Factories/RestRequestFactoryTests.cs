using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using RestSharp;
using YouTrack.Rest.Factories;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Tests.Factories
{
    class RestRequestFactoryTests : TestFor<RestRequestFactory>
    {
        public class RequestBodyItem
        {
            public string Value { get; set; }
        }

        private ISession session;
        private Dictionary<string, string> authenticationCookies;
        private IYouTrackRequest youTrackRequest;
        private const string RequestBody = "requestBody";

        protected override void SetupDependencies()
        {
            session = Mock<ISession>();
            authenticationCookies = CreateAuthenticationCookies();
            youTrackRequest = Mock<IYouTrackRequest>();
        }

        private Dictionary<string, string> CreateAuthenticationCookies()
        {
            Dictionary<string, string> cookies = new Dictionary<string, string>();
            cookies.Add("foo", "bar");

            return cookies;
        }

        private IRestRequest CreateRestRequest()
        {
            return Sut.CreateRestRequest(youTrackRequest, session, Method.GET);
        }

        [Test]
        public void AuthenticationCookiesAreSetWhenAuthenticated()
        {
            session.IsAuthenticated.Returns(true);
            session.AuthenticationCookies.Returns(authenticationCookies);

            var restRequest = CreateRestRequest();

            Assert.That(restRequest.Parameters.Any(p => p.Type == ParameterType.Cookie && p.Name == "foo"));
        }

        [Test]
        public void RequestHasBody()
        {
            youTrackRequest.HasBody.Returns(true);
            youTrackRequest.Body.Returns(new RequestBodyItem { Value = RequestBody });

            var restRequest = CreateRestRequest();

            Assert.That(restRequest.Parameters.Any(p => p.Type == ParameterType.RequestBody && p.Value.ToString().Contains(RequestBody)));
        }


        
    }
}
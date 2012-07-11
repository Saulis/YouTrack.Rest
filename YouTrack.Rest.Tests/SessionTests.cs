using System.Collections.Generic;
using System.Net;
using NSubstitute;
using NUnit.Framework;
using RestSharp;
using YouTrack.Rest.Exceptions;

namespace YouTrack.Rest.Tests
{
    class SessionTests : TestFor<Session>
    {
        private IRestClient restClient;
        private IRestResponse badRequestResponse;
        private IRestResponse loginResponse;
        private static RestResponseCookie authenticationCookie;

        protected override Session CreateSut()
        {
            restClient = Mock<IRestClient>();
            
            return new Session(restClient, "login", "password");
        }

        protected override void SetupDependencies()
        {
            badRequestResponse = CreateBadRequestResponse();

            loginResponse = CreateLoginResponse();
            restClient.Execute(Arg.Any<IRestRequest>()).Returns(loginResponse);
        }

        private IRestResponse CreateLoginResponse()
        {
            IRestResponse restResponse = Mock<IRestResponse>();

            restResponse.Cookies.Returns(CreateRestResponseCookies());

            return restResponse;
        }

        private static List<RestResponseCookie> CreateRestResponseCookies()
        {
            List<RestResponseCookie> restResponseCookies = new List<RestResponseCookie>();
            authenticationCookie = new RestResponseCookie() {Name = "foobar"};
            restResponseCookies.Add(authenticationCookie);

            return restResponseCookies;
        }

        private IRestResponse CreateBadRequestResponse()
        {
            IRestResponse response = Mock<IRestResponse>();

            response.StatusCode.Returns(HttpStatusCode.BadRequest);

            return response;
        }

        [Test]
        public void LoginExceptionIsThrownOnLoginFailed()
        {
            restClient.Execute(Arg.Any<IRestRequest>()).Returns(badRequestResponse);

            Assert.Throws<RequestFailedException>(() => Sut.Login());
        }

        [Test]
        public void LoginRequestIsUsedOnLogin()
        {
            Sut.Login();

            restClient.Received().Execute(Arg.Is<IRestRequest>(r => r.Resource == "/rest/user/login?login=login&password=password"));
        }

        [Test]
        public void IsAuthenticatedAfterLogin()
        {
            Sut.Login();

            Assert.IsTrue(Sut.IsAuthenticated);
        }

        [Test]
        public void AuthenticationCookiesAreSet()
        {
            Sut.Login();

            Assert.That(Sut.AuthenticationCookies.ContainsKey(authenticationCookie.Name));
        }
    }
}
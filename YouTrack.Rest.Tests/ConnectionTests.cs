using System.Net;
using NSubstitute;
using NUnit.Framework;
using RestSharp;
using YouTrack.Rest.Exceptions;

namespace YouTrack.Rest.Tests
{
    class ConnectionTests : TestFor<Connection>
    {
        private IRestClient restClient;
        private IRestResponse badRequestResponse;

        protected override Connection CreateSut()
        {
            restClient = Mock<IRestClient>();
            
            return new Connection(restClient, "login", "password");
        }

        protected override void SetupDependencies()
        {
            badRequestResponse = CreateBadRequestResponse();
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
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using NSubstitute;
using NUnit.Framework;
using RestSharp;
using YouTrack.Rest.Exceptions;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Tests
{
    public class ConnectionTestItem
    {

    }

    class ConnectionTests : TestFor<Connection>
    {
        private IRestClient restClient;
        private IRestResponse restResponse;
        private IRestResponse<ConnectionTestItem> restResponseWithTestItem;
        private List<Parameter> parametersWithLocationHeader;
        private ISession session;
        private Dictionary<string, string> authenticationCookies;
        private IYouTrackPostWithFileRequest postWithFileRequest;

        protected override Connection CreateSut()
        {
            restClient = Mock<IRestClient>();
            session = Mock<ISession>();

            return new Connection(restClient, session);
        }

        protected override void SetupDependencies()
        {
            restResponse = Mock<IRestResponse>();
            restResponseWithTestItem = Mock<IRestResponse<ConnectionTestItem>>();
            parametersWithLocationHeader = CreateParametersWithLocationHeader();

            authenticationCookies = CreateAuthenticationCookies();

            restClient.Execute(Arg.Any<IRestRequest>()).Returns(restResponse);
            restClient.Execute<ConnectionTestItem>(Arg.Any<IRestRequest>()).Returns(restResponseWithTestItem);

            postWithFileRequest = Mock<IYouTrackPostWithFileRequest>();
        }

        private Dictionary<string, string> CreateAuthenticationCookies()
        {
            Dictionary<string, string> cookies = new Dictionary<string, string>();
            cookies.Add("foo", "bar");

            return cookies;
        }

        private List<Parameter> CreateParametersWithLocationHeader()
        {
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(CreateParameterWithLocationHeader());


            return parameters;
        }

        private Parameter CreateParameterWithLocationHeader()
        {
            Parameter parameter = new Parameter();
            parameter.Name = "Location";
            parameter.Type = ParameterType.HttpHeader;
            parameter.Value = "foobar";

            return parameter;
        }

        [Test]
        public void AuthenticationCookiesAreSetWhenAuthenticated()
        {
            session.IsAuthenticated.Returns(true);
            session.AuthenticationCookies.Returns(authenticationCookies);

            Sut.Get(Mock<IYouTrackGetRequest>());

            AssertThatRestRequestContainsAuthenticationCookie();
        }

        private void AssertThatRestRequestContainsAuthenticationCookie()
        {
            restClient.Received().Execute(Arg.Is<IRestRequest>(x => x.Parameters.Any(p => p.Type == ParameterType.Cookie && p.Name == "foo")));
        }

        [Test]
        public void RestClientIsCalledWithGetMethod()
        {
            Sut.Get(Mock<IYouTrackGetRequest>());

            AssertThatRestClientExecuteWasCalledWithMethod(Method.GET);
        }

        [Test]
        public void RequestNotFoundExceptionThrownOnNotFound()
        {
            restResponse.StatusCode.Returns(HttpStatusCode.NotFound);

            Assert.Throws<RequestNotFoundException>(() => Sut.Get(Mock<IYouTrackGetRequest>()));
        }

        [Test]
        public void RequestFailedExceptionThrownOnBadRequest()
        {
            restResponse.StatusCode.Returns(HttpStatusCode.BadRequest);

            Assert.Throws<RequestFailedException>(() => Sut.Get(Mock<IYouTrackGetRequest>()));
        }

        [Test]
        public void RequestFailedExceptionThrownOnForbidden()
        {
            restResponse.StatusCode.Returns(HttpStatusCode.Forbidden);

            Assert.Throws<RequestFailedException>(() => Sut.Get(Mock<IYouTrackGetRequest>()));
        }

        [Test]
        public void RequestFailedExceptionThrownOnUnauthorized()
        {
            restResponse.StatusCode.Returns(HttpStatusCode.Unauthorized);

            Assert.Throws<RequestFailedException>(() => Sut.Get(Mock<IYouTrackGetRequest>()));
        }

        private void AssertThatRestClientExecuteWasCalledWithMethod(Method method)
        {
            restClient.Received().Execute(Arg.Is<IRestRequest>(x => x.Method == method));
        }

        private void AssertThatRestClientExecuteWasCalledWithMethod<TResponse>(Method method) where TResponse : new()
        {
            restClient.Received().Execute<TResponse>(Arg.Is<IRestRequest>(x => x.Method == method));
        }

        [Test]
        public void RestClientCalledWitGetMethodAndResponseType()
        {
            Sut.Get<ConnectionTestItem>(Mock<IYouTrackGetRequest>());

            AssertThatRestClientExecuteWasCalledWithMethod<ConnectionTestItem>(Method.GET);
        }

        [Test]
        public void RestClientCalledWithDeleteMethod()
        {
            Sut.Delete(Mock<IYouTrackDeleteRequest>());

            AssertThatRestClientExecuteWasCalledWithMethod(Method.DELETE);
        }

        [Test]
        public void RestClientCalledWithPostMethod()
        {
            Sut.Post(Mock<IYouTrackPostRequest>());

            AssertThatRestClientExecuteWasCalledWithMethod(Method.POST);
        }

        [Test]
        public void LocationHeaderCountInvalidThrownOnMissingLocationHeader()
        {
            Assert.Throws<LocationHeaderCountInvalidException>(() => Sut.Put(Mock<IYouTrackPutRequest>()));

        }

        [Test]
        public void RestClientCalledWithPutMethod()
        {
            restResponse.Headers.Returns(parametersWithLocationHeader);

            Sut.Put(Mock<IYouTrackPutRequest>());

            AssertThatRestClientExecuteWasCalledWithMethod(Method.PUT);
        }

        [Test]
        public void ArgumentNullExceptionThrownOnMissingResponseHeaders()
        {
            restResponse.Headers.Returns(null as IList<Parameter>);

            Assert.Throws<ArgumentNullException>(() => Sut.Put(Mock<IYouTrackPutRequest>()));
        }

        [Test]
        public void PostingFileIsCalledWithPostMethod()
        {
            Sut.PostWithFile(postWithFileRequest);

            AssertThatRestClientExecuteWasCalledWithMethod(Method.POST);
        }

        [Test]
        public void FileIsPostedWithName()
        {
            postWithFileRequest.Name.Returns("files");

            Sut.PostWithFile(postWithFileRequest);

            AssertThatRestClientExecuteWasCalledWithFileAndName("files");
        }

        [Test]
        public void FileIsPostedWithFilePath()
        {
            postWithFileRequest.FilePath.Returns("foo.jpg");

            Sut.PostWithFile(postWithFileRequest);

            AssertThatRestClientExecuteWasCalledWithFile("foo.jpg");
        }

        [Test]
        public void FileIsPostedWithBytes()
        {
            byte[] bytes = new byte[512];
            string filename = "foo.txt";

            postWithFileRequest.HasBytes.Returns(true);
            postWithFileRequest.Bytes.Returns(bytes);
            postWithFileRequest.FileName.Returns(filename);

            Sut.PostWithFile(postWithFileRequest);

            AssertThatRestClientExecuteWasCalledWithBytes(filename, bytes);
        }

        private void AssertThatRestClientExecuteWasCalledWithBytes(string filename, byte[] bytes)
        {
            restClient.Received().Execute(Arg.Is<IRestRequest>(x => x.Files.Any(f => f.FileName == filename && f.ContentLength == bytes.Length)));
        }

        private void AssertThatRestClientExecuteWasCalledWithFile(string filePath)
        {
            restClient.Received().Execute(Arg.Is<IRestRequest>(x => x.Files.Any(f => f.FileName == filePath)));
        }

        private void AssertThatRestClientExecuteWasCalledWithFileAndName(string name)
        {
            restClient.Received().Execute(Arg.Is<IRestRequest>(x => x.Files.Any(f => f.Name == name)));
        }
    }
}

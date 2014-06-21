using System;
using System.Collections.Generic;
using System.Net;
using NSubstitute;
using NUnit.Framework;
using RestSharp;
using YouTrack.Rest.Exceptions;
using YouTrack.Rest.Factories;
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
        
        private IRestFileRequestFactory requestFactory;

        protected override Connection CreateSut()
        {
            restClient = Mock<IRestClient>();
            session = Mock<ISession>();
            requestFactory = Mock<IRestFileRequestFactory>();

            return new Connection(restClient, session, requestFactory);
        }

        protected override void SetupDependencies()
        {
            restResponse = Mock<IRestResponse>();
            restResponseWithTestItem = Mock<IRestResponse<ConnectionTestItem>>();
            parametersWithLocationHeader = CreateParametersWithLocationHeader();

            restClient.Execute(Arg.Any<IRestRequest>()).Returns(restResponse);
            restClient.Execute<ConnectionTestItem>(Arg.Any<IRestRequest>()).Returns(restResponseWithTestItem);
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
        public void RestClientIsCalledWithGetMethod()
        {
            Sut.Get(Mock<IYouTrackGetRequest>());

            AssertThatRestRequestWasCreatedWithMethod(Method.GET);
        }


        [Test]
        public void RequestNotFoundExceptionThrownOnNotFound()
        {
            restResponse.StatusCode.Returns(HttpStatusCode.NotFound);

            Assert.Throws<RequestNotFoundException>(() => Sut.Get(Mock<IYouTrackGetRequest>()));
        }

        [Test]
        public void RequestFailedExceptionThrownOnNotAcceptable()
        {
            restResponse.StatusCode.Returns(HttpStatusCode.NotAcceptable);

            Assert.Throws<RequestFailedException>(() => Sut.Get(Mock<IYouTrackGetRequest>()));
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

        [Test]
        public void RequestFailedExceptionThrownOnUnsupportedMediaType()
        {
            restResponse.StatusCode.Returns(HttpStatusCode.UnsupportedMediaType);

            Assert.Throws<RequestFailedException>(() => Sut.Get(Mock<IYouTrackGetRequest>()));
        }

        private void AssertThatRestRequestWasCreatedWithMethod(Method method)
        {
            requestFactory.Received().CreateRestRequest(Arg.Any<IYouTrackRequest>(), session, method);
        }

        [Test]
        public void RestRequestIsCreatedWitGetMethodAndResponseType()
        {
            Sut.Get<ConnectionTestItem>(Mock<IYouTrackGetRequest>());

            AssertThatRestRequestWasCreatedWithMethod(Method.GET);
        }

        [Test]
        public void RestRequestIsCreatedWithDeleteMethod()
        {
            Sut.Delete(Mock<IYouTrackDeleteRequest>());

            AssertThatRestRequestWasCreatedWithMethod(Method.DELETE);
        }

        [Test]
        public void RestRequestIsCreatedWithPostMethod()
        {
            Sut.Post(Mock<IYouTrackPostRequest>());

            AssertThatRestRequestWasCreatedWithMethod(Method.POST);
        }

        [Test]
        public void LocationHeaderCountInvalidThrownOnMissingLocationHeader()
        {
            Assert.Throws<LocationHeaderCountInvalidException>(() => Sut.Put(Mock<IYouTrackPutRequest>()));

        }

        [Test]
        public void RestRequestIsCreatedWithPutMethod()
        {
            restResponse.Headers.Returns(parametersWithLocationHeader);

            Sut.Put(Mock<IYouTrackPutRequest>());

            AssertThatRestRequestWasCreatedWithMethod(Method.PUT);
        }

        [Test]
        public void ArgumentNullExceptionThrownOnMissingResponseHeaders()
        {
            restResponse.Headers.Returns(null as IList<Parameter>);

            Assert.Throws<ArgumentNullException>(() => Sut.Put(Mock<IYouTrackPutRequest>()));
        }

        [Test]
        public void PostingFileRequestIsCreatedWithPostMethod()
        {
            Sut.PostWithFile(Mock<IYouTrackPostWithFileRequest>());

            requestFactory.Received().CreateRestRequestWithFile(Arg.Any<IYouTrackFileRequest>(), session, Method.POST);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Reflection;
using NSubstitute;
using NUnit.Framework;
using RestSharp;
using YouTrack.Rest.Repositories;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Tests
{
    [TestFixture]
    class YouTrackClientTests : TestFor<YouTrackClient>
    {
        private IRestClient restClient;
        private IRestResponse<TestItem> restResponseWithLocationHeader;

        protected override YouTrackClient CreateSut()
        {
            YouTrackClient youTrackClient = new YouTrackClient("http://foo.bar", "login", "password");
            
            return youTrackClient;
        }

        protected override void SetupDependencies()
        {
            restClient = InjectRestClient(Sut);
            restResponseWithLocationHeader = CreateRestResponseWithLocationHeader();
            restClient.Execute<TestItem>(Arg.Any<IRestRequest>()).Returns(restResponseWithLocationHeader);
        }

        private IRestResponse<TestItem> CreateRestResponseWithLocationHeader()
        {
            IRestResponse<TestItem> restResponse = Mock<IRestResponse<TestItem>>();

            Parameter locationParameter = new Parameter();
            locationParameter.Name = "Location";
            locationParameter.Type = ParameterType.HttpHeader;
            locationParameter.Value = "foobar";

            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(locationParameter);

            restResponse.Headers.Returns(parameters);

            return restResponse;
        }

        private IRestClient InjectRestClient(YouTrackClient youTrackClient)
        {
            FieldInfo restClientField = youTrackClient.GetType().GetField("restClient", BindingFlags.NonPublic | BindingFlags.Instance);
            IRestClient restClient = Mock<IRestClient>();
            restClientField.SetValue(youTrackClient, restClient);

            return restClient;
        }

        [Test]
        public void IssueRepositoryIsReturned()
        {
            Assert.That(Sut.GetIssueRepository(), Is.TypeOf<IssueRepository>());
        }

        [Test]
        public void ConnectionIsReturned()
        {
            Assert.That(Sut.GetConnection(), Is.TypeOf<Session>());
        }


    }

    public class TestItem
    {

    }

}
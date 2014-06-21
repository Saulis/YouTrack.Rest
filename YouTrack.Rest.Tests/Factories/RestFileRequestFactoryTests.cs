using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using RestSharp;
using YouTrack.Rest.Factories;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Tests.Factories
{
    class RestFileRequestFactoryTests : TestFor<RestFileRequestFactory>
    {
        private IRestRequestFactory restRequestFactory;
        private IYouTrackPostWithFileRequest postWithFileRequest;
        private ISession session;
        private IRestRequest restRequest;

        protected override RestFileRequestFactory CreateSut()
        {
            restRequestFactory = Mock<IRestRequestFactory>();

            return new RestFileRequestFactory(restRequestFactory);
        }

        protected override void SetupDependencies()
        {
            session = Mock<ISession>();
            postWithFileRequest = Mock<IYouTrackPostWithFileRequest>();

            restRequest = Mock<IRestRequest>();
            restRequest.Parameters.Returns(new List<Parameter>());
            restRequest.Parameters.Add(new Parameter() { Name = "Accept", Value = "foo"});
            
            restRequestFactory.CreateRestRequest(postWithFileRequest, session, Method.POST)
                              .Returns(restRequest);


        }

        private IRestRequest GetRestRequestWithFile()
        {
            return Sut.CreateRestRequestWithFile(postWithFileRequest, session, Method.POST);
        }


        [Test]
        public void PostingFileRequestUsesJson()
        {
            IRestRequest restRequestWithFile = GetRestRequestWithFile();

            Assert.That(restRequestWithFile.Parameters.Single(p => p.Name == "Accept").Value, Is.EqualTo("application/json"));
        }

        [Test]
        public void FileIsPostedWithName()
        {
            postWithFileRequest.Name.Returns("files");

            IRestRequest restRequestWithFile = GetRestRequestWithFile();

            restRequestWithFile.Received().AddFile("files", Arg.Any<String>());
        }

        [Test]
        public void FileIsPostedWithFilePath()
        {
            postWithFileRequest.FilePath.Returns("foo.jpg");

            IRestRequest restRequestWithFile = GetRestRequestWithFile();

            restRequestWithFile.Received().AddFile(Arg.Any<String>(), "foo.jpg");
        }

        [Test]
        public void FileIsPostedWithBytes()
        {
            byte[] bytes = new byte[512];
            string filename = "foo.txt";

            postWithFileRequest.HasBytes.Returns(true);
            postWithFileRequest.Bytes.Returns(bytes);
            postWithFileRequest.FileName.Returns(filename);

            IRestRequest restRequestWithFile = GetRestRequestWithFile();

            restRequestWithFile.Received().AddFile(Arg.Any<String>(), bytes, filename);
        }
    }
}
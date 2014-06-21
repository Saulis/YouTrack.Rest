using System.Linq;
using RestSharp;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Factories
{
    internal interface IRestFileRequestFactory : IRestRequestFactory
    {
        IRestRequest CreateRestRequestWithFile(IYouTrackFileRequest request, ISession session, Method method);
    }

    class RestFileRequestFactory : IRestFileRequestFactory
    {
        private readonly IRestRequestFactory restRequestFactory;

        //Since https://github.com/restsharp/RestSharp/commit/2781d7e11544a67c9bfb300edc43a0947ab7986f, RestSharp.RestRequest.AddFile()
        //has started reading the given file using IO. Therefore creating the RestRequest and calling AddFile in the same factory prevents
        //unit testing without having the actual files in the IO.
        internal RestFileRequestFactory(IRestRequestFactory restRequestFactory)
        {
            this.restRequestFactory = restRequestFactory;
        }

        public RestFileRequestFactory() : this(new RestRequestFactory())
        {
            
        }

        public IRestRequest CreateRestRequest(IYouTrackRequest request, ISession session, Method method)
        {
            return restRequestFactory.CreateRestRequest(request, session, method);
        }

        public IRestRequest CreateRestRequestWithFile(IYouTrackFileRequest request, ISession session, Method method)
        {
            IRestRequest restRequest = CreateRestRequest(request, session, method);
            AddFileToRestRequest(request, restRequest);

            //Using Accept=application/xml for files doesn't work in 5.x http://youtrack.jetbrains.com/issue/JT-25271
            ReplaceAcceptWithJson(restRequest);

            return restRequest;
        }

        private void ReplaceAcceptWithJson(IRestRequest restRequest)
        {
            foreach (var parameter in restRequest.Parameters.Where(p => p.Name == "Accept"))
            {
                parameter.Value = "application/json";
            }
        }

        private void AddFileToRestRequest(IYouTrackFileRequest request, IRestRequest restRequest)
        {
            if (request.HasBytes)
            {
                restRequest.AddFile(request.Name, request.Bytes, request.FileName);
            }
            else
            {
                restRequest.AddFile(request.Name, request.FilePath);
            }
        }
    }
}
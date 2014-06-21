using System.Collections.Generic;
using RestSharp;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Factories
{
    internal interface IRestRequestFactory
    {
        IRestRequest CreateRestRequest(IYouTrackRequest request, ISession session, Method method);
    }

    class RestRequestFactory : IRestRequestFactory
    {
        private readonly RestFileRequestFactory restFileRequestFactory;

        public RestRequestFactory()
        {
            restFileRequestFactory = new RestFileRequestFactory(this);
        }

        public IRestRequest CreateRestRequest(IYouTrackRequest request, ISession session, Method method)
        {
            RestRequest restRequest = new RestRequest(request.RestResource, method);

            if(request.HasBody)
            {
                restRequest.AddBody(request.Body);
            }

            SetAcceptToXml(restRequest);

            if (session.IsAuthenticated)
            {
                SetAuthenticationCookies(restRequest, session.AuthenticationCookies);
            }

            return restRequest;
        }

        public IRestRequest CreateRestRequestWithFile(IYouTrackFileRequest request, ISession session, Method method)
        {
            return restFileRequestFactory.CreateRestRequestWithFile(request, session, method);
        }

        private void SetAcceptToXml(RestRequest restRequest)
        {
            restRequest.AddHeader("Accept", "application/xml");
        }

        private void SetAuthenticationCookies(RestRequest restRequest, IEnumerable<KeyValuePair<string, string>> authenticationCookies)
        {
            foreach (KeyValuePair<string, string> cookie in authenticationCookies)
            {
                restRequest.AddCookie(cookie.Key, cookie.Value);
            }
        }
    }
}
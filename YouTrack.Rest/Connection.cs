using System.Collections.Generic;
using System.Linq;
using System.Net;
using RestSharp;
using YouTrack.Rest.Exceptions;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest
{
    class Connection : IConnection
    {
        private readonly IRestClient restClient;
        private readonly string login;
        private readonly string password;

        public Connection(IRestClient restClient, string login, string password)
        {
            this.restClient = restClient;
            this.login = login;
            this.password = password;
        }

        public bool IsAuthenticated
        {
            get { return AuthenticationCookies != null; }
        }

        public IDictionary<string, string> AuthenticationCookies { get; private set; }

        public void Login()
        {
            IRestResponse loginResponse = ExecuteRequest(new LoginRequest(login, password), Method.POST);

            AuthenticationCookies = loginResponse.Cookies.ToDictionary(c => c.Name, c => c.Value);
        }

        private IRestResponse ExecuteRequest(IYouTrackRequest request, Method method)
        {
            IRestRequest restRequest = new RestRequest(request.RestResource, method);
            IRestResponse restResponse = restClient.Execute(restRequest);

            ThrowIfRequestFailed(restResponse);

            return restResponse;
        }

        private void ThrowIfRequestFailed(IRestResponse response)
        {
            switch(response.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                case HttpStatusCode.Forbidden:
                case HttpStatusCode.Unauthorized:
                    throw new RequestFailedException(response);
            }
        }
    }
}

using System;
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
        private readonly ISession session;

        public Connection(IRestClient restClient, ISession session)
        {
            this.restClient = restClient;
            this.session = session;
        }

        private IRestResponse ExecuteRequest(IYouTrackRequest request, Method method)
        {
            IRestRequest restRequest = CreateRestRequest(request, method);
            IRestResponse restResponse = restClient.Execute(restRequest);

            ThrowIfRequestFailed(restResponse);

            return restResponse;
        }

        private IRestResponse ExecuteRequestWithFile(IYouTrackFileRequest request, Method method)
        {
            IRestRequest restRequest = CreateRestRequestWithFile(request, method);
            IRestResponse restResponse = restClient.Execute(restRequest);

            ThrowIfRequestFailed(restResponse);

            return restResponse;
        }


        private IRestResponse<TResponse> ExecuteRequest<TResponse>(IYouTrackRequest request, Method method) where TResponse : new()
        {
            IRestRequest restRequest = CreateRestRequest(request, method);
            IRestResponse<TResponse> restResponse = restClient.Execute<TResponse>(restRequest);

            ThrowIfRequestFailed(restResponse);

            return restResponse;
        }

        private void ThrowIfRequestFailed(IRestResponse response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                case HttpStatusCode.Forbidden:
                case HttpStatusCode.Unauthorized:
                    throw new RequestFailedException(response);

                case HttpStatusCode.NotFound:
                    throw new RequestNotFoundException(response);
            }
        }

        public string Put(IYouTrackPutRequest request)
        {
            IRestResponse response = ExecuteRequestWithAuthentication(request, Method.PUT);

            return GetLocationHeaderValue(response);
        }

        public TResponse Get<TResponse>(IYouTrackGetRequest request) where TResponse : new()
        {
            IRestResponse<TResponse> response = ExecuteRequestWithAuthentication<TResponse>(request, Method.GET);

            return response.Data;
        }

        public void Get(IYouTrackGetRequest request)
        {
            ExecuteRequestWithAuthentication(request, Method.GET);
        }

        public void Delete(IYouTrackDeleteRequest request)
        {
            ExecuteRequestWithAuthentication(request, Method.DELETE);
        }

        public void Post(IYouTrackPostRequest request)
        {
            ExecuteRequestWithAuthentication(request, Method.POST);
        }

        public void PostWithFile(IYouTrackPostWithFileRequest request)
        {
            ExecuteRequestWithAuthenticationAndFile(request, Method.POST);
        }

        private string GetLocationHeaderValue(IRestResponse response)
        {
            Func<Parameter, bool> locationPredicate = h => h.Name.ToLowerInvariant() == "location";

            ThrowIfHeaderCountInvalid(response, locationPredicate);

            return response.Headers.Single(locationPredicate).Value.ToString();
        }

        private void ThrowIfHeaderCountInvalid(IRestResponse response, Func<Parameter, bool> locationPredicate)
        {
            if (response.Headers == null)
            {
                throw new ArgumentNullException("response.Headers", "Response Headers are null.");
            }

            if (response.Headers.Count(locationPredicate) != 1)
            {
                throw new LocationHeaderCountInvalidException(response.Headers);
            }
        }

        private IRestResponse ExecuteRequestWithAuthentication(IYouTrackRequest request, Method method)
        {
            LoginIfNotAuthenticated();

            return ExecuteRequest(request, method);
        }

        private IRestResponse ExecuteRequestWithAuthenticationAndFile(IYouTrackFileRequest request, Method method)
        {
            LoginIfNotAuthenticated();

            return ExecuteRequestWithFile(request, method);
        }

        private IRestResponse<TResponse> ExecuteRequestWithAuthentication<TResponse>(IYouTrackRequest request, Method method) where TResponse : new()
        {
            LoginIfNotAuthenticated();

            return ExecuteRequest<TResponse>(request, method);
        }

        private IRestRequest CreateRestRequest(IYouTrackRequest request, Method method)
        {
            RestRequest restRequest = new RestRequest(request.RestResource, method);

            SetAcceptToXml(restRequest);

            if (session.IsAuthenticated)
            {
                SetAuthenticationCookies(restRequest);
            }

            return restRequest;
        }


        private IRestRequest CreateRestRequestWithFile(IYouTrackFileRequest request, Method method)
        {
            IRestRequest restRequest = CreateRestRequest(request, method);
            AddFileToRestRequest(request, restRequest);

            return restRequest;
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

        private void SetAcceptToXml(RestRequest restRequest)
        {
            Func<Parameter, bool> acceptPredicate = p => p.Name == "Accept";

            if (restRequest.Parameters.Count(acceptPredicate) > 1)
            {
                throw new InvalidAcceptHeaderCountException(restRequest);
            }

            if (restRequest.Parameters.Count(acceptPredicate) == 1)
            {
                Parameter parameter = restRequest.Parameters.Single(acceptPredicate);
                parameter.Value = "application/xml";
            }
            else
            {
                restRequest.AddHeader("Accept", "application/xml");
            }
        }

        private void SetAuthenticationCookies(RestRequest restRequest)
        {
            foreach (KeyValuePair<string, string> cookie in session.AuthenticationCookies)
            {
                restRequest.AddCookie(cookie.Key, cookie.Value);
            }
        }

        private void LoginIfNotAuthenticated()
        {
            if (!session.IsAuthenticated)
            {
                session.Login();
            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using RestSharp;
using YouTrack.Rest.Exceptions;
using YouTrack.Rest.Repositories;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest
{
    public class YouTrackClient : IYouTrackClient
    {
        private readonly IConnection connection;
        private readonly RestClient restClient;

        public YouTrackClient(string baseUrl, string login, string password)
        {
            restClient = new RestClient(baseUrl);
            connection = new Connection(restClient, login, password);
        }

        public IConnection GetConnection()
        {
            return connection;
        }

        public IIssueRepository GetIssueRepository()
        {
            return new IssueRepository(this);
        }

        private IRestResponse ExecuteRequest(IYouTrackRequest request, Method method)
        {
            IRestRequest restRequest = CreateRestRequest(request, method);
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

        private IRestResponse<TResponse> ExecuteRequestWithAuthentication<TResponse>(IYouTrackRequest request, Method method) where TResponse : new()
        {
            LoginIfNotAuthenticated();

            return ExecuteRequest<TResponse>(request, method);
        }

        private IRestRequest CreateRestRequest(IYouTrackRequest request, Method method)
        {
            RestRequest restRequest = new RestRequest(request.RestResource, method);

            SetAcceptToXml(restRequest);

            if (connection.IsAuthenticated)
            {
                SetAuthenticationCookies(restRequest);
            }

            return restRequest;
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
            foreach (KeyValuePair<string, string> cookie in connection.AuthenticationCookies)
            {
                restRequest.AddCookie(cookie.Key, cookie.Value);
            }
        }

        private void LoginIfNotAuthenticated()
        {
            if (!connection.IsAuthenticated)
            {
                connection.Login();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using YouTrack.Rest.Exceptions;

namespace YouTrack.Rest.Requests
{
    class RestRequestResourceBuilder
    {
        private readonly string resourceBase;
        private readonly Dictionary<string, string> parameters;

        public RestRequestResourceBuilder(string resourceBase)
        {
            this.resourceBase = resourceBase;

            parameters = new Dictionary<string, string>();
        }

        public override string ToString()
        {
            return resourceBase + CreateParameterString();
        }

        private string CreateParameterString()
        {
            StringBuilder parameterString = new StringBuilder();

            if(parameters.Count > 0)
            {
                parameterString.Append("?");
            }

            foreach (KeyValuePair<string, string> keyValuePair in parameters)
            {
                parameterString.Append(String.Format("{0}={1}&", keyValuePair.Key, Uri.EscapeDataString(keyValuePair.Value)));
            }

            return parameterString.ToString().TrimEnd('&');
        }

        public void AddParameter(string parameterName, string parameterValue)
        {
            ThrowIfParameterAlreadyAdded(parameterName);

            if (!String.IsNullOrEmpty(parameterValue))
            {
                parameters.Add(parameterName, parameterValue);
            }
        }

        public void AddMultiValueParameter(string parameterName, IEnumerable<string> parameterValues)
        {
            foreach (var parameterValue in parameterValues)
            {
                if (!String.IsNullOrEmpty(parameterValue))
                {
                    parameters.Add(parameterName, parameterValue);
                }
            }
        }

        private void ThrowIfParameterAlreadyAdded(string parameterName)
        {
            if (parameters.ContainsKey(parameterName))
            {
                throw new ParameterAlreadyAddedException();
            }
        }
    }
}
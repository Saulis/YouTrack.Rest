using System;

namespace YouTrack.Rest.Requests
{
    class ApplyCommandsToAnIssueRequest : YouTrackRequest, IYouTrackPostRequest
    {

        public ApplyCommandsToAnIssueRequest(string issueId, params string[] commands)
            : base(String.Format("/rest/issue/{0}/execute", issueId))
        {
            ThrowIfCommandsAreNull(commands);

            ResourceBuilder.AddParameter("command", String.Join(" ", commands));
        }

        private void ThrowIfCommandsAreNull(string[] commands)
        {
            if(commands == null)
            {
                throw new ArgumentNullException("commands");
            }
        }
    }
}
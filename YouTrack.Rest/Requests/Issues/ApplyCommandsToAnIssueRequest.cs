using System;
using System.Collections.Generic;
using System.Linq;

namespace YouTrack.Rest.Requests.Issues
{
    class ApplyCommandsToAnIssueRequest : YouTrackRequest, IYouTrackPostRequest
    {

        public ApplyCommandsToAnIssueRequest(string issueId, params string[] commands)
            : base(String.Format("/rest/issue/{0}/execute", issueId))
        {
            ThrowIfCommandsAreNull(commands);

            ResourceBuilder.AddParameter("command", String.Join(" ", commands));
        }

        private void ThrowIfCommandsAreNull(IEnumerable<string> commands)
        {
            if(commands == null || !commands.Any())
            {
                throw new ArgumentNullException("commands");
            }
        }
    }
}
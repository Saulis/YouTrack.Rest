using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouTrack.Rest.Requests
{
    class ApplyCommandToAnIssueRequest : YouTrackRequest, IYouTrackPostRequest
    {
        public ApplyCommandToAnIssueRequest(string issueId, string command = null, string comment = null, string group = null, bool? disableNotifications = null, string runAs = null)
            : base(String.Format("/rest/issue/{0}/execute", issueId))
        {
            ResourceBuilder.AddParameter("comment", comment);
        }
    }
}

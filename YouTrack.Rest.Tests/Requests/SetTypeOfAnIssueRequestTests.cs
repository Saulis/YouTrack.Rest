using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouTrack.Rest.Requests;

namespace YouTrack.Rest.Tests.Requests
{
    class SetTypeOfAnIssueRequestTests : YouTrackRequestTests<SetTypeOfAnIssueRequest, IYouTrackPostRequest>
    {
        protected override SetTypeOfAnIssueRequest CreateSut()
        {
            return new SetTypeOfAnIssueRequest("FOO-BAR", "Task");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/issue/FOO-BAR/execute?command=Type%20Task"; }
        }
    }
}

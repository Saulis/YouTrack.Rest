using NUnit.Framework;
using YouTrack.Rest.Requests;
using YouTrack.Rest.Requests.Users;

namespace YouTrack.Rest.Tests.Requests.Users
{
    class AssignRoleToUserGroupRequestTests :YouTrackRequestTests<AssignRoleToUserGroupRequest, IYouTrackPutRequest>
    {
        protected override AssignRoleToUserGroupRequest CreateSut()
        {
            return new AssignRoleToUserGroupRequest("foo", "bar");
        }

        protected override string ExpectedRestResource
        {
            get { return "/rest/admin/group/foo/role/bar"; }
        }

        [Test]
        public void RequestHasBody()
        {
            Assert.That(Sut.HasBody);
        }

        [Test]
        public void HasUserRoleBody()
        {
            Assert.That(Sut.Body, Is.TypeOf<Rest.Deserialization.UserRole>());
        }
    }
}

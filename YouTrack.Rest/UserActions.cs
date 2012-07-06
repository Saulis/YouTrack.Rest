using System.Collections.Generic;

namespace YouTrack.Rest
{
    class UserActions : IUserActions
    {
        public void JoinGroup(string groupName)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IUserGroup> Groups
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
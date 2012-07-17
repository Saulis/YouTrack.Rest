using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace YouTrack.Rest.Features.Administration.Users
{
    public class UserSteps : Steps.Steps
    {
        [AfterScenario]
        public void Teardown()
        {
            Console.WriteLine("Tearing down the Scenario...");

            if (HasSavedUser())
            {
                DeleteUser(GetSavedLogin());
            }

            if(HasSavedUserGroup())
            {
                DeleteUserGroup(GetSavedUserGroup());
            }
        }

        private bool HasSavedUser()
        {
            if(HasSavedLogin())
            {
                return UserExists(GetSavedLogin());
            }

            return false;
        }

        private bool HasSavedUserGroup()
        {
            return ScenarioContext.Current.ContainsKey("savedUserGroup") && ScenarioContext.Current["savedUserGroup"] != null;
        }

        private bool HasSavedLogin()
        {
            return ScenarioContext.Current.ContainsKey("savedLogin");
        }

        protected void SaveLogin(string login)
        {
            ScenarioContext.Current.Set(login, "savedLogin");
        }

        protected string GetSavedLogin()
        {
            return ScenarioContext.Current.Get<string>("savedLogin");
        }

        protected IUser GetSavedUser()
        {
            return GetUser(GetSavedLogin());
        }

        protected void CreateUser(string login, string password, string email, string fullname = null)
        {
            StepHelper.CreateUser(login, password, email, fullname);

            SaveLogin(login);
        }

        protected void DeleteUser(string login)
        {
            StepHelper.DeleteUser(login);
        }

        protected bool UserExists(string login)
        {
            return StepHelper.UserExists(login);
        }

        protected IUser GetUser(string login)
        {
            return StepHelper.GetUser(login);
        }

        protected void CreateUserGroup(string userGroupName)
        {
            IUserGroup userGroup = StepHelper.CreateUserGroup(userGroupName);

            ScenarioContext.Current.Set(userGroup, "savedUserGroup");
        }

        protected IUserGroup GetSavedUserGroup()
        {
            if(HasSavedUserGroup())
            {
                return ScenarioContext.Current.Get<IUserGroup>("savedUserGroup");
            }

            throw new ApplicationException("Usergroup hasn't been saved to ScenarioContext.");
        }


        protected void DeleteUserGroup(string userGroupName)
        {
            StepHelper.DeleteUserGroup(userGroupName);

            ScenarioContext.Current["savedUserGroup"] = null;
        }

        private void DeleteUserGroup(IUserGroup userGroup)
        {
            DeleteUserGroup(userGroup.Name);
        }

        protected IEnumerable<IUserGroup> GetAllUserGroups()
        {
            return StepHelper.GetAllUserGroups();
        }
    }
}
using System;
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
        }

        private bool HasSavedUser()
        {
            if(HasSavedLogin())
            {
                return UserExists(GetSavedLogin());
            }

            return false;
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
    }
}
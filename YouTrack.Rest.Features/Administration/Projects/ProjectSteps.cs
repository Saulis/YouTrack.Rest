using System;
using TechTalk.SpecFlow;
using YouTrack.Rest.Repositories;

namespace YouTrack.Rest.Features.Administration.Projects
{
    public class ProjectSteps : Steps.Steps
    {
        protected IProjectRepository ProjectRepository
        {
            get { return StepHelper.GetProjectRepository(); }
        }

        [AfterScenario]
        public void Teardown()
        {
            Console.WriteLine("Tearing down the Scenario...");

            if (HasSavedProject())
            {
                DeleteProject(GetSavedProject().Id);
            }
        }

        private bool HasSavedProject()
        {
            return ScenarioContext.Current.ContainsKey("savedProject");
        }

        protected void SaveProject(IProject project)
        {
            ScenarioContext.Current.Set(project, "savedProject");
        }

        protected IProject GetSavedProject()
        {
            return ScenarioContext.Current.Get<IProject>("savedProject");
        }

        protected void DeleteProject(string projectid)
        {
            Console.WriteLine("Deleting project {0}", projectid);

            ProjectRepository.DeleteProject(projectid);
        }

        protected void CreateProject(string projectid, string projectname, int startingNumber, string projectleadlogin, string description)
        {
            Console.WriteLine("Creating project {0}", projectid);

            SaveProject(ProjectRepository.CreateProject(projectid, projectname, projectleadlogin, startingNumber, description));
        }

        protected bool ProjectExists(string projectId)
        {
            Console.WriteLine("Checking if project {0} exists", projectId);

            return ProjectRepository.ProjectExists(projectId);
        }
    }
}
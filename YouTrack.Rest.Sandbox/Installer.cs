using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouTrack.Rest.Repositories;

namespace YouTrack.Rest.Sandbox
{
    class Installer
    {
        public const string ProjectShortname = "SB";

        static void Main(string[] args)
        {
            YouTrackClient youTrackClient = new YouTrackClient("http://localhost:8484", "youtrack.rest", "youtrack.rest");

            //1. Check if user exists / create user
            //3. Check rights / set admin rights
            //4. Check project / create project
            //5. Check subsystem / add subsystem Test
            //6. Check issue / add issue

            //RunInstallationSteps(new CreateUser(youTrackClient));
                
                //new SetupInitialIssue(youTrackClient));
        }

        private static void RunInstallationSteps(params ISandboxInstallationStep[] installationSteps)
        {
            foreach (ISandboxInstallationStep installationStep in installationSteps)
            {
                RunInstallationStep(installationStep);
            }
        }

        private static void RunInstallationStep(ISandboxInstallationStep installationStep)
        {
            if(installationStep.IsNotDone())
            {
                installationStep.DoIt();
            }
        }
    }

    internal class CreateUser : ISandboxInstallationStep
    {
        public bool IsNotDone()
        {
            throw new NotImplementedException();
        }

        public void DoIt()
        {
            throw new NotImplementedException();
        }
    }

    class SetupInitialIssue : ISandboxInstallationStep
    {
        private YouTrackClient youTrackClient;

        public SetupInitialIssue(YouTrackClient youTrackClient)
        {
            this.youTrackClient = youTrackClient;
        }

        public bool IsNotDone()
        {
            IProjectRepository projectRepository = youTrackClient.GetProjectRepository();

            IProjectProxy projectProxy = projectRepository.GetProjectProxy(Installer.ProjectShortname);

            throw new NotImplementedException();
        }

        public void DoIt()
        {
            throw new NotImplementedException();
        }
    }

    internal interface ISandboxInstallationStep
    {
        bool IsNotDone();
        void DoIt();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouTrack.Rest.Repositories;

namespace YouTrack.Rest.Sandbox
{
    internal class Installer
    {
        public const string ProjectShortname = "SB";

        private static void Main(string[] args)
        {
            YouTrackClient youTrackClient = new YouTrackClient("http://localhost:8484", "youtrack.rest", "youtrack.rest");

            CreateUser(youTrackClient);
            CreateProject(youTrackClient);
            AddSubsystem(youTrackClient);
            CreateInitialIssue(youTrackClient);
        }

        private static void CreateInitialIssue(YouTrackClient youTrackClient)
        {
            //1. Check if sandbox has any issues
            //2. Create issue

            throw new NotImplementedException();
        }

        private static void AddSubsystem(YouTrackClient youTrackClient)
        {
            //1. Check if subsystem Test exists
            //2. Add subsystem Test

            throw new NotImplementedException();
        }

        private static void CreateUser(YouTrackClient youTrackClient)
        {
            //1. Check if user exists
            //2. Create user
            //3. Set admin rights

            throw new NotImplementedException();
        }

        private static void CreateProject(YouTrackClient youTrackClient)
        {
            //1. Check if project exists
            //2. Create project

            throw new NotImplementedException();
        }
    }
}

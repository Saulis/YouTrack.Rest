using System;
using System.Collections.Generic;
using System.Linq;
using YouTrack.Rest.Repositories;

namespace YouTrack.Rest.Sandbox
{
    internal class Installer
    {
        public const string ProjectShortname = "SB";
        private const string UserName = "youtrack.rest";
        private const string Password = "youtrack.rest";
        private const string UserGroupName = "Automated Testers";
        private const string Subsystem = "Test";
        private const string ProjectName = "Sandbox";

        private static void Main(string[] args)
        {
            YouTrackClient youTrackClient = Login();

            CreateUser(youTrackClient);
            CreateProject(youTrackClient);

            Console.WriteLine("Done! Press any key to continue...");
            Console.ReadKey();
        }

        private static YouTrackClient Login()
        {
            Console.Write("Username with admin rights (root): ");
            string readLine = Console.ReadLine();
            string username = String.IsNullOrEmpty(readLine) ? "root" : readLine;

            Console.Write("Password: ");
            ConsoleColor oldForeGroundColor = Console.ForegroundColor;
            Console.ForegroundColor = Console.BackgroundColor;
            string password = Console.ReadLine();

            Console.ForegroundColor = oldForeGroundColor;

            YouTrackClient youTrackClient = new YouTrackClient("http://localhost:80", username, password);
            return youTrackClient;
        }

        private static void CreateInitialIssue(IIssueRepository issueRepository)
        {
            Console.Write("Creating issue for project {0}...", ProjectShortname);

            issueRepository.CreateIssue(ProjectShortname, "Initial issue", "Blah Blah");

            Console.WriteLine("done.");
        }

        private static void AddSubsystem(IProjectRepository projectRepository)
        {
            Console.Write("Adding project subsystem {0} exists...", Subsystem);

            IProject project = projectRepository.GetProject(ProjectShortname);

            project.AddSubsystem(Subsystem);

            Console.WriteLine("done.");
        }

        private static void CreateUser(YouTrackClient youTrackClient)
        {
            IUserRepository userRepository = youTrackClient.GetUserRepository();

            CreateUserGroup(userRepository);
            CreateUser(userRepository);
        }

        private static void CreateUser(IUserRepository userRepository)
        {
            if (UserExists(userRepository))
            {
                if (!UserBelongsToTestersUserGroup(userRepository))
                {
                    AddUserToTestersUserGroup(userRepository);
                }
            }
            else
            {
                CreateTestUser(userRepository);
                AddUserToTestersUserGroup(userRepository);
            }
        }

        private static void AddUserToTestersUserGroup(IUserRepository userRepository)
        {
            Console.Write("Adding user {0} to user group {1}...", UserName, UserGroupName);

            IUser user = userRepository.GetUser(UserName);
            user.JoinGroup(UserGroupName);

            Console.WriteLine("done.");
        }

        private static bool UserBelongsToTestersUserGroup(IUserRepository userRepository)
        {
            Console.Write("Checking if user {0} belongs to user group {1}...", UserName, UserGroupName);

            IUser user = userRepository.GetUser(UserName);

            bool contains = user.Groups.Select(ug => ug.Name).Contains(UserGroupName);

            Console.WriteLine(contains ? "yes." : "no.");

            return contains;
        }

        private static void CreateUserGroup(IUserRepository userRepository)
        {
            if (TestersUserGroupExists(userRepository))
            {
                if (!TestersUserGroupHasAdminRole(userRepository))
                {
                    AssignAdminRoleToTestersUserGroup(userRepository);
                }
            }
            else
            {
                CreateTestersUserGroup(userRepository);
                AssignAdminRoleToTestersUserGroup(userRepository);
            }
        }

        private static bool TestersUserGroupHasAdminRole(IUserRepository userRepository)
        {
            Console.Write("Checking if user group {0} has admin role...", UserGroupName);

            IEnumerable<IUserGroup> userGroups = userRepository.GetUserGroups();
            IUserGroup userGroup = userGroups.Single(ug => ug.Name == UserGroupName);

            bool contains = userGroup.Roles.Select(r => r.Name).Contains("Admin");

            Console.WriteLine(contains ? "yes." : "no.");

            return contains;
        }

        private static void AssignAdminRoleToTestersUserGroup(IUserRepository userRepository)
        {
            Console.Write("Assigning admin role to user group {0}...", UserGroupName);

            IEnumerable<IUserGroup> userGroups = userRepository.GetUserGroups();
            IUserGroup userGroup = userGroups.Single(ug => ug.Name == UserGroupName);

            userGroup.AssignRoleToAllProjects("Admin");

            Console.WriteLine("done.");
        }

        private static void CreateTestersUserGroup(IUserRepository userRepository)
        {
            Console.Write("Creating user group {0}...", UserGroupName);

            userRepository.CreateUserGroup(UserGroupName);

            Console.WriteLine("done.");
        }

        private static bool TestersUserGroupExists(IUserRepository userRepository)
        {
            Console.Write("Checking if user group {0} exists...", UserGroupName);

            IEnumerable<IUserGroup> userGroups = userRepository.GetUserGroups();
            bool contains = userGroups.Select(ug => ug.Name).Contains(UserGroupName);

            Console.WriteLine(contains ? "yes." : "no.");

            return contains;
        }

        private static void CreateTestUser(IUserRepository userRepository)
        {
            Console.Write("Creating user {0}...", UserName);

            userRepository.CreateUser(UserName, Password, "email@email.com", "YouTrack.REST");

            Console.WriteLine("done.");
        }

        private static bool UserExists(IUserRepository userRepository)
        {
            Console.Write("Checking if user {0} exists...", UserName);

            bool userExists = userRepository.UserExists(UserName);

            Console.WriteLine(userExists ? "yes." : "no.");

            return userExists;
        }

        private static void CreateProject(YouTrackClient youTrackClient)
        {
            IProjectRepository projectRepository = youTrackClient.GetProjectRepository();
            IIssueRepository issueRepository = youTrackClient.GetIssueRepository();

            if(ProjectExists(projectRepository))
            {
                if (!SubsystemExists(projectRepository))
                {
                    AddSubsystem(projectRepository);
                }

                if (!IssueExists(projectRepository))
                {
                    CreateInitialIssue(issueRepository);
                }
            }
            else
            {
                CreateSandboxProject(projectRepository);
                AddSubsystem(projectRepository);
                CreateInitialIssue(issueRepository);
            }
        }

        private static bool IssueExists(IProjectRepository projectRepository)
        {
            Console.Write("Checking if project {0} has issues...", ProjectShortname);

            IProject project = projectRepository.GetProject(ProjectShortname);
            bool any = project.GetIssues().Any();

            Console.WriteLine(any ? "yes." : "no.");

            return any;
        }

        private static bool SubsystemExists(IProjectRepository projectRepository)
        {
            Console.Write("Checking if project subsystem {0} exists...", Subsystem);

            IProject project = projectRepository.GetProject(ProjectShortname);

            bool contains = project.Subsystems.Select(s => s.Name).Contains(Subsystem);

            Console.WriteLine(contains ? "yes." : "no.");

            return contains;
        }

        private static void CreateSandboxProject(IProjectRepository projectRepository)
        {
            Console.Write("Creating project {0}...", ProjectShortname);

            projectRepository.CreateProject(ProjectShortname, ProjectName, UserName, 1);

            Console.WriteLine("done.");
        }

        private static bool ProjectExists(IProjectRepository projectRepository)
        {
            Console.Write("Checking if project {0} exists...", ProjectShortname);

            bool projectExists = projectRepository.ProjectExists(ProjectShortname);

            Console.WriteLine(projectExists ? "yes." : "no.");

            return projectExists;
        }
    }
}

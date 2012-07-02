# YouTrack.Rest

Easy-to-use .NET client for Jetbrains' YouTrack REST API (http://www.jetbrains.com/youtrack)

Compatible with YouTrack v4.0 (http://confluence.jetbrains.net/display/YTD4/YouTrack+REST+API+Reference)

Built on top of RestSharp: https://github.com/restsharp/RestSharp / http://restsharp.org
and CastleProject's DynamicProxy: https://github.com/castleproject/Castle.Core-READONLY / http://www.castleproject.org/

## Usage

```csharp

// First, create the client instance
IYouTrackClient youTrackClient = new YouTrackClient("http://youtrack.address.com", "login", "password");

// Fetching and creating issues is done using the IssueRepository
IIssueRepository issueRepository = youTrackClient.GetIssueRepository();

// Creating issue
IIssue issue = issueRepository.CreateIssue("project", "summary", "description");

// YouTrack.Rest uses Castle DynamicProxy for lazy loading which allows you to execute various commands related to an issue without actually fetching the issue from YouTrack.
issue.AttachFile(@"C:\temp\foo.jpg");
issue.AddComment("blah blah");

// Using properties which use issue details will trigger a REST request:
Console.WriteLine(issue.Summary);

```

## Supported API Features (v0.4.0)

* Issues
	* Create New Issue
	* Get an Issue
	* Check that an Issue Exists
	* Get Attachments of an Issue
	* Get Comments of an Issue
	* Attach File to an Issue
	* Delete an Issue
	* Apply Command(s) to an Issue
	* Get Issues in a Project
	* Remove a Comment for an Issue
	
* Admin
	* Projects
		* Create a new project (next release)
		* Delete project (next release)
	* Users
		* Create a new user (next release)
		* Delete user (next release)
		* Get user (next release)
	
## Contributing

Don't see the feature you need in the list? Feel free to post your own implementations or bug fixes and I'll be happy to integrate them into the code!

You can also post an issue or send me a message and I'll try to sort it out.

* Alright, what do I need to know?
	* In order to run Acceptance tests, you need to install YouTrack 4.0 locally:
		* Install YouTrack 4.0(http://www.jetbrains.com/youtrack/download/get_youtrack.html)
		* Use port 8484 (well, you can use whatever port you want but then you have to change the tests a bit)
		* Run the YouTrack.Rest.Sandbox.Installer (still in progress, heres the manual procedure: Add user with admin rights, add Sandbox project, add subsystem Test to it, add one issue to project)

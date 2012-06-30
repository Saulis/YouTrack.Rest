# YouTrack.Rest

Easy-to-use .NET client for Jetbrains' YouTrack REST API (http://www.jetbrains.com/youtrack)

Compatible with YouTrack v3.x with v4.x support planned. (http://confluence.jetbrains.net/display/YTD3/YouTrack+REST+API+Reference)

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
	
## Not (yet) Supported API Features

* Issues
	* Get Issue History
	* Get Historical Changes of an Issue
	* Get Links of an Issue
	* Get a Number of Issues

* Projects
	* TBD

* Users
	* TBD

* Admin
	* TBD

* Export
	* TBD

* Import
	* TBD
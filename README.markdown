# YouTrack.Rest

Easy-to-use .NET client for Jetbrains' YouTrack REST API (http://www.jetbrains.com/youtrack)

Compatible with YouTrack v3.x with v4.x support planned. (http://confluence.jetbrains.net/display/YTD3/YouTrack+REST+API+Reference)

Built on top of RestSharp: https://github.com/restsharp/RestSharp / http://restsharp.org

## Usage

```csharp

// First, create the client instance
IYouTrackClient youTrackClient = new YouTrackClient("http://youtrack.address.com", "login", "password");

// Fetching and creating issues is done using the IssueRepository
IIssueRepository issueRepository = youTrackClient.GetIssueRepository();

// Creating issue and fetching the created issue
IIssue issue = issueRepository.CreateAndGetIssue("project", "summary", "description");

// You can also use another method to only creates the issue and returns a proxy object
IIssueProxy issueProxy = issueRepository.CreateIssue("project", "summary", "description");

// IssueProxy is a proxy class which allows you to execute various commands related to an issue without actually fetching the issue from YouTrack.
issueProxy.AttachFile(@"C:\temp\foo.jpg");

// IssueProxy can be fetched from the repository without making a query to YouTrack
IIssueProxy anotherIssueProxy = issueRepository.GetIssueProxy("FOO-123");
anotherIssueProxy.AddComment("blah blah");

// Issue of course has the same methods as IssueProxy, plus Project, Summary and Description.
issue.Summary = "foobar";

```

## Supported API Features

* Issues
	* Create New Issue (creating with attachments not supported yet)
	* Get an Issue
	* Check that an Issue Exists
	* Get Attachments of an Issue
	* Get Comments of an Issue
	* Attach File to an Issue
	* Delete an Issue

## Not (yet) Supported API Features

* Issues
	* Get Issue History
	* Get Historical Changes of an Issue
	* Get Links of an Issue
	* Apply Command to an Issue
	* Get Issues in a Project
	* Get a Number of Issues
	* Remove a Comment for an Issue

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
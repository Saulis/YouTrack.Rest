Feature: Authentication with Login and Password

Scenario: Valid authentication
	When I authenticate with login "youtrackapi" and password "youtrackapi" to "http://youtrack.codebetter.com"
	Then I am authenticated

Scenario: Invalid authentication
	When I authenticate with login "foo" and password "bar" to "http://youtrack.codebetter.com"
	Then I am not authenticated

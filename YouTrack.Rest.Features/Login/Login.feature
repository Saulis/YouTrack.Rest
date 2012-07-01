Feature: Authentication with Login and Password

Scenario: Valid authentication
	When I authenticate with login "youtrack.rest" and password "youtrack.rest" to "http://localhost:8484"
	Then I am authenticated

Scenario: Invalid authentication
	When I authenticate with login "foo" and password "bar" to "http://localhost:8484"
	Then I am not authenticated

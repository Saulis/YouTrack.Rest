Feature: Get an Issue

Scenario: Getting a single issue
	Given I have created an issue
	When I request the issue
	Then the issue is returned
	 And it has the default fields set

Scenario: Getting a single issue with comments
	Given I have created an issue
	  And I have given it a comment
	 When I request the issue
	 Then it has the comment set

Scenario: Getting a single issue without description
	Given I have created an issue without description
	 When I request the issue
	 Then it has the description set to an empty string

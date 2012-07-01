Feature: Apply Command to an Issue

Scenario: Add comment to an Issue
	Given I have created an issue
	When I add a comment to the issue
	Then a comment is added to the issue

Scenario: Edit Subsystem of an Issue
	Given I have created an issue
	 When I change the Subsystem of the Issue
	 Then the Subsystem is changed

Scenario: Edit Type of an Issue
	Given I have created an issue
	 When I change the Type of the Issue
	 Then the Type is changed

Scenario: Edit Subsystem and Type with same command
	Given I have created an issue
	 When I change the Subsystem and Type of the issue
	 Then the Subsystem is changed
	  And the Type is changed

Feature: Attach File to an Issue

Background: 
	Given I am authenticated

Scenario: Attach File to an Issue
	Given I have created an issue
 	 When I attach an file to the issue
	 Then the file is attached

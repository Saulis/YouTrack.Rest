Feature: Get Attachments of an Issue

Scenario: Get multiple Attachments of an Issue
	Given I have created an issue
	  And attached two files to the issue
	 When I get the attachments of the issue
	 Then I get two attached files

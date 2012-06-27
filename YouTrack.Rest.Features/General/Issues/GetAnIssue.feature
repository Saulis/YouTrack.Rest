﻿Feature: Get an Issue

Background: 
	Given I am authenticated

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

@wip
Scenario: Getting a single issue with attachments
	Given I have created an issue
	  And I have added an attachment to it
	 When I request the issue
	 Then it has the attachment set

@wip
Scenario: Getting a single issue with links
	Given I have created an issue
	  And I have linked it to another issue
	 When I request the issue
	 Then it has the link to another issue

@wip
Scenario: Getting a single issue with multiple fix versions
	Given I have created an issue
	  And I have added two fix versions to it
	 When I request the issue
	 Then the issue has both fix versions

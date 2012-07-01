Feature: Remove a comment for an issue

Scenario: Remove existing comment
	Given I have created an issue
	  And I have created an comment to the issue
	 When I remove the comment
	 Then the comment is removed

Scenario: Try to remove non-existing comment
	Given I have created an issue
	 When I try to remove a comment
	 Then the comment is not found
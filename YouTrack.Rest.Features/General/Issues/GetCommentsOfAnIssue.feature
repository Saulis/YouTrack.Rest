Feature: Get Comments of an Issue

Background: 
	Given I am authenticated

Scenario: Get a single comment
	Given I have created an issue
	  And I have created an comment to the issue
 	 When I fetch the comments for the issue
  	 Then I receive one comment

Scenario: Get two comments
	Given I have created an issue
	  And I have created two comments to the issue
	 When I fetch the comments for the issue
	 Then I receive two comments


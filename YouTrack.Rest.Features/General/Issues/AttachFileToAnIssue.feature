Feature: Attach File to an Issue

Scenario: Attach File to an Issue from path
	Given I have created an issue
 	 When I attach an file to the issue using a path
	 Then the file is attached

Scenario: Attach File to an Issue using bytes
	Given I have created an issue
	 When I attach an file to the issue using bytes
	 Then the file is attached

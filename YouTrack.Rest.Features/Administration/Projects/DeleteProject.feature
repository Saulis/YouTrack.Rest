Feature: Delete project
# http://confluence.jetbrains.net/display/YTD4/DELETE+Project

Scenario: Delete specified project
	Given I have create a new project
	 When I delete the project
	 Then the project does not exist anymore

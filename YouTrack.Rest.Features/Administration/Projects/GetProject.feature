Feature: Get project
# http://confluence.jetbrains.net/display/YTD4/GET+Project

Scenario: Get project by its project identifier
	Given I have created a new project
	 When I fetch the project
	 Then the project is fetched


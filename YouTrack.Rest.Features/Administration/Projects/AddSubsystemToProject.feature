Feature: Add subsystem to project
# No api reference available

Scenario: Add subsystem to a project
	Given I have created a project
	 When I add subsystem to the project
	 Then the project has a subsystem

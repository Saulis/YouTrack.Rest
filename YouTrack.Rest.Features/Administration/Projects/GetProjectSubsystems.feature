Feature: Get projects subsystems
# No API reference found :C

Scenario: Get project default subsystems
	Given I have created a project
	 When I fetch the project
	 Then the project has default subsystem "No subsystem"

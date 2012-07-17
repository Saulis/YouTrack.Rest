Feature: Get all user groups
# http://confluence.jetbrains.net/display/YTD4/GET+Groups

Scenario: Get all available user groups
	When I fetch all the user groups
	Then I received user groups

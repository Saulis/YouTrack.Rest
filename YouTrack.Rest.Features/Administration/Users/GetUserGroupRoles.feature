Feature: Get user group roles
# http://confluence.jetbrains.net/display/YTD4/GET+Group+Roles

Scenario: Get roles assigned to a user group
	When I fetch a user group
	Then the user group has roles

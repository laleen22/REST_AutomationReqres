Feature: ListUsers
	Listing Users

@mytag
Scenario: List all existing users
	Given User with name "Lindsay Ferguson"
	When Send request to List users
	Then Validate user exists "Lindsay Ferguson"
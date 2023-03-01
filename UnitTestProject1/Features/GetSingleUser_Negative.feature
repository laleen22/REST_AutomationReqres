Feature: GetSingleUser_Negative
	Get a Single User when id is given which is not available 

@Test
Scenario: Retrive a user when gievn with is

	Given user with id "222"
	When Send request to get single user
	Then Validate single user is not received
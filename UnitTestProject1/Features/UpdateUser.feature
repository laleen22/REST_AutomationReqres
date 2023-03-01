Feature: UpdateUser
	Update a user

@Test
Scenario Outline: Update a user with given inputs

	Given user with id "<id>"
	And update name "<update_name>"
	And update job "<update_job>"
	When Send request to update user
	Then Validate user is updated

Examples: 
| id | update_name | update_job |
| 2  | Kamal       | Manager    |
| 3  | Jon         | Lord       |
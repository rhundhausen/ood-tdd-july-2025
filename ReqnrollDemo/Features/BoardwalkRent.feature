Feature: Rent Calculation for Boardwalk

Calculate the rent charged when a player lands on Boardwalk with property upgrades.

@monopoly
Scenario: Charge rent for landing on Boardwalk with two houses
	Given the property is "Boardwalk"
	And the number of houses on the property is 2
	And a player lands on the property
	When rent is calculated
	Then the rent charged should be $600
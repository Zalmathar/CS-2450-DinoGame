Feature: Jumper

Simple dino jump program that looks to be anything but

Link to a feature: [Calculator]($projectname$/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Jump 1
	Given player jumping
	When cycles passed is 1
	Then the player should be 1 space in the air
Scenario: Jump 2
	Given player jumping
	When cycles passed is 2
	Then the player should be 2 space in the air
Scenario: Jump 3
	Given player jumping
	When cycles passed is 3
	Then the player should be 2 space in the air
Scenario: Jump 4
	Given player jumping
	When cycles passed is 4
	Then the player should be 1 space in the air
Scenario: Jump 5
	When cycles passed is 5
	Then the player should be 0 space in the air
Scenario: no double jump
	Given player jumping
	When jump is called
	Then no additional jump should run
Scenario: frame update player x
	Given frame update
	When player updates position
	Then horizontal position should be constant
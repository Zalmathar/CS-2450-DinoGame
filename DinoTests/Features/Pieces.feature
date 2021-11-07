Feature: Pieces
	THe pieces for the dino game

@mytag
#small rock test cases

	Scenario: correctly constructed small rock
		Given a position of x is starting Position
		And a position of y is 0;
		When a small rock is constructed using Position
		Then Position x is starting Position
		And Position y is 0
		And score is set to 8


	Scenario: y position is wrong

		Given a position of x is starting Position
		And a position of y is 1;
		When a small rock is constructed using Position
		Then throw exception



	Scenario: y position is negative

		Given a position of x is starting Position
		And a position of y is -1;
		When a small rock is constructed using Position
		Then throw exception



	Scenario: x position is wrong

		Given a position of x is -1
		And a position of y is 0;
		When a small rock is constructed using Position
		Then throw exception



	Scenario: x position is too high

		Given a position of x is greater than starting Position
		And a position of y is 0;
		When a small rock is constructed using Position
		Then throw exception



	Scenario: small rock points are correct

		Given a position of x is starting Position
		And a position of y is 0;
		When a small rock is constructed using Position
		Then the score is 8

	Scenario: small rock moves
		Given a small rock
		When a frame update happens
		Then position x is changed by -1
		And y position is the same
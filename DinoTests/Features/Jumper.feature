Feature: Jumper

		Simple dino jump program that looks to be anything but

		Link to a feature: [Calculator]($projectname$/Features/Calculator.feature)
		***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

	@mytag
	#piece tests
	Scenario: JUM-22 1
		Given player jumping
		When cycles passed is 1
		Then the player should be 1 space in the air

	Scenario: JUM-22 2
		Given player jumping
		When cycles passed is 2
		Then the player should be 2 space in the air

	Scenario: JUM-22 3
		Given player jumping
		When cycles passed is 3
		Then the player should be 2 space in the air

	Scenario: JUM-22 4
		Given player jumping
		When cycles passed is 4
		Then the player should be 1 space in the air

	Scenario: JUM-22 5
		Given player jumping
		When cycles passed is 5
		Then the player should be 0 space in the air

	Scenario: JUM-22 no double jump
		Given player jumping
		When jump is called
		Then no additional jump should run

	Scenario: JUM-22 frame update player x
		Given frame update
		When player updates position
		Then horizontal position should be constant
	Scenario: Constructed correctly

	#small rock test cases

	Scenario: correctly constructed small rock
		Given a position of x is starting Position
		And a position of y is 0;
		When a small rock is constructed using Position
		Then Position x is starting Position
		And Position y is 0
		And score is set to 8

	Scenario: small rock moves
		Given a small rock

		When a frame update happens

		Then position x is 1 less

		And y position is the same


	Scenario: big rock moves
		Given a big rock

		When a frame update happens

		Then position x is 1 less

		And y position is the same


	Scenario: bird moves
		Given a bird

		When a frame update happens

		Then position x is 1 less

		And y position is the same


	Scenario: wrong constructor
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



	#big rock test cases



	Scenario: Constructed correctly

		Given a position of x is starting Position
		And a position of y is 0;
		When a big rock is constructed using Position
		Then Position x is starting Position
		And Position y is 0
		And score is set to 10



	Scenario: y position is wrong

		Given a position of x is starting Position
		And a position of y is 1;
		When a big rock is constructed using Position
		Then throw exception



	Scenario: y position is negative
		Given a position of x is starting Position
		And a position of y is -1;
		When a big rock is constructed using Position
		Then throw exception



	Scenario: x position is wrong

		Given a position of x is -1
		And a position of y is 0;
		When a big rock is constructed using Position
		Then throw exception



	Scenario: x position is too high

		Given a position of x is greater than starting Position
		And a position of y is 0;
		When a big rock is constructed using Position
		Then throw exception



	Scenario: big rock points are correct

		Given a position of x is starting Position
		And a position of y is 0;
		When a big rock is constructed using Position
		Then the score is 10





	#bird test cases



	Scenario: Constructed correctly

		Given a position of x is starting Position
		And a position of y is bird starting Position;
		When a small rock is constructed using Position
		Then Position x is starting Position
		And Position y is bird starting Position
		And score is set to 20



	Scenario: y position is wrong

		Given a position of x is starting Position
		And a position of y is 1;
		When a bird is constructed using Position
		Then throw exception


	Scenario: y position is negative

		Given a position of x is starting Position
		And a position of y is -1;
		When a small rock is constructed using Position
		Then throw exception


	Scenario: x position is wrong
		Given a position of x is -1
		And a position of y is bird starting Position;
		When a bird is constructed using Position
		Then throw exception



	Scenario: x position is too high

		Given a position of x is greater than starting Position
		And a position of y is bird starting Position;
		When a bird is constructed using Position
		Then throw exception



	Scenario: bird points are correct

		Given a position of x is starting Position
		And a position of y is bird starting Position;
		When a bird is constructed using Position
		Then the score is 20

	# Controller tests
	@JUM25_Score
	Scenario: JUM25 No Obsticle One point added
		Given there is a player located at (3, 1)
		When the next frame cycle happnes.
		Then The score increases by 1 points

	@JUM25_Score
	Scenario: JUM25 Bird No collision 20 points added
		Given there is a bird located at (4, 3) 
		And there is a player located at (3, 1)
		When the next frame cycle happens.
		Then no collision is detected
		And The score increases by 20 points

	@JUM25_Score
	Scenario: JUM25 Small rock No collision 8 Points added
		Given there is a small rock located at (4, 1)
		And there is a player located at (3, 2)
		When the next fram cycle happens.
		Then no collision is detected
		And The score increases by 8 points

	@JUM25_Score
	Scenario: JUM25 Large rock No collision 10 points added
		Given there is a large rock located at (4, 1)
		And there is a player located at (3, 3)
		When the next frame cycle happens.
		Then no collision is detected
		And The score increases by 10 points

	@JUM25_Score
	Scenario: JUM25 Large rock Collision No points added
		Given there is a large rock one column in front of the player.
		When the next fram cycle happens.
		Then collision is detected
		And score remains the same

	@JUM25_Score
	Scenario: JUM25 Small rock collision No points added
		Given there is a small rock one column in front of the player.
		When the next frame cycle happens.
		Then collision is detected
		And score remains the same

	@JUM25_Score
	Scenario: JUM25 Bird collision no points added
		Given there is a bird one column in front of the player.
		When the next fram cycle happens.
		Then collision is detected
		And score remains the same



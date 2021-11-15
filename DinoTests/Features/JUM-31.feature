Feature: JUM31

    JUM31 Test cases

# JUM-31 Collision Tests
	@JUM31_Collision
	Scenario: JUM31 Bird on level 4 collides with player
		Given there is a controller object
		And there is a bird located at (4, 4)
		And there is a player located at (3, 3)
		When the next frame cycle happens
		Then collision is detected

	@JUM31_Collision
	Scenario: JUM31 Bird on level 3 collides with player
		Given there is a controller object
		And there is a bird located at (4, 3)
		And there is a player located at (3, 3)
		When the next frame cycle happens
		Then collision is detected

	@JUM31_Collision
	Scenario: JUM31 Small rock collides with player
		Given there is a controller object
		And there is a small rock located at (4, 1)
		And there is a player located at (3, 1)
		When the next frame cycle happens
		Then collision is detected

	@JUM31_Collision
	Scenario: JUM31 Large rock collides with player
		Given there is a controller object
		And there is a large rock located at (4, 1)
		And there is a player located at (3, 1)
		When the next frame cycle happens
		Then collision is detected
	
	@JUM31_Collision
	Scenario: JUM31 Large rock collides with a player at level 2
		Given there is a controller object
		And there is a large rock located at (4, 1)
		And there is a player located at (3, 2)
		When the next frame cycle happens
		Then collision is detected

	@JUM31_Collision
	Scenario: JUM31 There are no obstacles
		Given there is a controller object
		And there is a player located at (3, 1)
		When the next frame cycle happens
		Then no collision is detected

	@JUM31_Collision
	Scenario: JUM31 Player passes over large rock
		Given there is a controller object
		And there is a large rock located at (4, 1)
		And there is a player located at (3, 3)
		When the next frame cycle happens
		Then no collision is detected

	@JUM31_Collision
	Scenario: JUM31 Player passes over small rock
		Given there is a controller object
		And there is a small rock located at (4, 1)
		And there is a player located at (3, 2)
		When the next frame cycle happens
		Then no collision is detected

	@JUM31_Collision
	Scenario: JUM31 Player passes under a bird at level 4, while at level 2
		Given there is a controller object
		And there is a bird located at (4, 4)
		And there is a player located at (3, 2)
		When the next frame cycle happens
		Then no collision is detected

	@JUM31_Collision
	Scenario: JUM31 Player passes under a bird at level 4, while at level 1
		Given there is a controller object
		And there is a bird located at (4, 4)
		And there is a player located at (3, 1)
		When the next frame cycle happens
		Then no collision is detected

	@JUM31_Collision
	Scenario: JUM31 Player passes uder a bird at level 3, while at level 1
		Given there is a controller object
		And there is a bird located at (4, 3)
		And there is a player located at (3, 1)
		When the next frame cycle happens
		Then no collision is detected
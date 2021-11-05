Feature: Jumper

		Simple dino jump program that looks to be anything but

		Link to a feature: [Calculator]($projectname$/Features/Calculator.feature)
		***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

	@mytag
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

	# Controller tests
	@Score
	Scenario: No Obsticle One point added
		Given there is no obstacle in front of the player.
		When the next frame cycle happnes.
		Then 1 point is added to the score

	@Score
	Scenario: Bird No collision 20 points added
		Given there is a bird one column in front of the player.
		When the next frame cycle happens.
		And the player does not collide with the bird.
		Then 20 points are added to the score

	@Score
	Scenario: Small rock No collision 8 Points added
		Given there is a small rock one column in front of the player.
		When the next fram cycle happens.
		And the player does not collide iwth the small rock.
		Then 8 points are added to the score

	@Score
	Scenario: Large rock No collision 10 points added
		Given there is a large rock one column in front of the player.
		When the next frame cycle happens.
		And the player does not collide with the large rock.
		Then 10 points are added to the score

	@Score
	Scenario: Large rock Collision No points added
		Given there is a large rock one column in front of the player.
		When the next fram cycle happens.
		And the player collides with the large rock.
		Then no pionts are added to the score.

	@Score
	Scenario: Small rock collision No points added
		Given there is a small rock one column in front of the player.
		When the next frame cycle happens.
		And the player collides with the small rock.
		Then no points are added to the score.

	@Score
	Scenario: Bird collision no points added
		Given there is a bird one column in front of the player.
		When the next fram cycle happens.
		And the playe rcollildes with the bird.
		Then no points are added to the score.
Feature: JUM25

    JUM25 Test cases
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
		Given there is a large rock located at (4, 1)
		And there is a player located at (3, 1)
		When the next fram cycle happens.
		Then collision is detected
		And score remains the same

	@JUM25_Score
	Scenario: JUM25 Small rock collision No points added
		Given there is a small rock located at (4, 1)
		And there is a player located at (3, 1)
		When the next frame cycle happens.
		Then collision is detected
		And score remains the same

	@JUM25_Score
	Scenario: JUM25 Bird collision no points added
		Given there is a bird located at (4, 3)
		And there is a player located at (3, 2)
		When the next frame cycle happens.
		Then collision is detected
		And score remains the same
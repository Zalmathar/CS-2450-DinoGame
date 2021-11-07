Feature: JUM43

    JUM43 Test cases

    @JUM-43
	Scenario: JUM43 Small rock's position is updated
		Given there is a small rock located at (6, 1)
		And there is a player located at (3, 1)
		When the next frame cycle happens
		Then the player position is at (3, 1)
		And the small rock position is at (5, 1)

	@JUM-43
	Scenario: JUM43 Large rock's position is updated
		Given there is a large rock located at (6, 1)
		And there is a player located at (3, 1)
		When the next frame cycle happens
		Then the player position is at (3, 1)
		And the small rock position is at (5, 1)

	@JUM-43
	Scenario: JUM43 Bird at level 4 position is updated
		Given there is a bird located at (6, 4)
		And there is a player located at (3, 1)
		When the next frame cycle happens
		Then the player position is at (3, 1)
		And the small bird is at (5, 4)

	@JUM-43
	Scenario: JUM43 Bird at level 3 position is updated
		Given there is a bird located at (6, 3)
		And there is a player located at (3, 1)
		When the next frame cycle happens
		Then the player position is at (3, 1)
		And the small bird is at (5, 3)
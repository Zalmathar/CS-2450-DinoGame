// Tanis Olesen
// 11/5/2021
// Controlls the behavior of the game
using System;
using System.Collections.Generic;

namespace DinoClassLib
{
    public class Controller
    {

        // Represents the player
        private Player player;
        // Holds a List of all of the obstacles that are on screen
        public List<IPiece> Obstacles { get; private set;}
        

        // Represents the current score the player of the game has achieved. 
        private int score;
        //ToDo: represesnts the display size in the x direction. should be set on frame update by the returned value of the IO
        private int displayXsize;
        // Represents the states the game can be in
        enum status
        {
            pre, // In the pre game state, a screen should be generated that has the player and no other objects. When one of the jump keys in pressed. The game starts
            running, // In the running state, The player is able to jump, obsticals get randomly generated and move toward the left of the screen.
            dead // In the dead state. The total score of the game is showed. When one of the jump keys is pressed. The game re-starts
        }
        // Represents the current state of the game
        private status gameState;


        // Constructs the starting state of the game.
        public Controller()
        {
            // TODO: Start the game in the pre game state, Create the player, and let the IO render the screen. When one of the jump keys is received start the game.
        }

        // Generates a new game state representing the next frame. 
        public void FrameUpdate()
        {
            // TODO: Go through each obstical and update is position.
            // TODO: Check to see if the player is jumping, if it is update the players state.
            // TODO: Check for collisions, If collisions are detected end the game, and display the end game card. If not continue the game. 
            // TODO: Add any score for each obstacle that has been cleared by the player. or just one point for an empty space
            /* TODO: Any Obstacle that has reached the far left of the view must get deleted.
                  To do this im thinking of in this iteration loop, store the index of each item that needs to be deleted. 
                  Than deleting them from the largest index to the smallest. IE. If the obstacles stored at index 1, 3, and 10 need to be deleted. Delete them in order 10, 3, then 1. 
                  Deleteing them in reverse would preserve the integrity of the list as we delete multiple objects from it. Minimizing the amount of times we have to iterate through our obstacle list. 
                  We would then pass this array of indexes to be deleted to our delete method that would go in and delete them. -- Tanis Olesen
            */
            // TODO: Randomly generate a new obsticales
            MakeObstacle();
            // TODO: Display the game state to the user.
            
        }

        // Checks each obstacle agains the players position to determin if a collision has been detected.
        private bool CheckCollision()
        {
            // TODO: Check each obstacle position and size to determin if the player has collided with an object.
            // TODO: If a collision has been detected return true, else return false.
            throw new NotImplementedException();
        }

        // Randomly creates obstacles that are then stored in the obsticale list. Has a chance of not creating any obstical's
        private void MakeObstacle()

        {
            Random RNG = new Random();

            //1-50 Chance of the obstacle being a small rock
            if (RNG.Next(50) == 1)
            {
                Obstacles.Add(new SmallRock(displayXsize, 0));
            } 
            //1-75 Chance of the obstacle being a large rock
            else if (RNG.Next(75) == 1)
            {
                Obstacles.Add(new BigRock(displayXsize, 0));
            }
            //1-100 Chance of the obstacle being a bird
            else if (RNG.Next(100) == 1)
            {
                Obstacles.Add(new Bird(displayXsize, RNG.Next(2) + 3));
            }   
        }
        // When an obsticale has reached the minimum it can be (Far left of the view). Remove each obsticale that has reached the end of the screen
        private void DeleteObstacle(int[] delThese)
        {
            // TODO: Delete each obstacle that is specified by delThese
            throw new NotImplementedException();
        }
    }
}
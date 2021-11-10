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
        public Player player = new Player(3, 1);

        public bool Jumpinfo = false;// dummy value until IO is implemented
        // Holds a List of all of the obstacles that are on screen
        public List<IPiece> Obstacles { get; set;}


        // Represents the current score the player of the game has achieved. 
        private int score;
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        //ToDo: represesnts the display size in the x direction. should be set on frame update by the returned value of the IO
        private int displayXsize;
        // Represents the states the game can be in
        public enum status
        {
            pre, // In the pre game state, a screen should be generated that has the player and no other objects. When one of the jump keys in pressed. The game starts
            running, // In the running state, The player is able to jump, obsticals get randomly generated and move toward the left of the screen.
            dead // In the dead state. The total score of the game is showed. When one of the jump keys is pressed. The game re-starts
        }
        // Represents the current state of the game
        public status gameState;


        // Constructs the starting state of the game.
        public Controller()
        {
           Obstacles = new List<IPiece>();
           score = 0;
            // TODO: Start the game in the pre game state, Create the player, and let the IO render the screen. When one of the jump keys is received start the game.
        }

        // Generates a new game state representing the next frame. 
        public void FrameUpdate()
        {
            bool dodge = false;
            List<int> delList = new List<int>();//to be replaced once delete obstacle implemented
            player.onFrameUpdate(); // Want to update player before the pieces for CheckCollision to work
            for (int i = 0; i < Obstacles.Count; i++)
            {
                IPiece piece = Obstacles[i];
                piece.onFrameUpdate();
                if (CheckCollision(piece) == true)
                {
                    gameState = status.dead;
                    // Display the end game card
                }
                if (piece.position.getX() == 3 && !CheckCollision(piece))
                {
                    score += piece.pointVal; //increase the score for dodging an obstacle
                    dodge = true;
                }
                if(piece.position.getX() < 1)
                {
                    delList.Add(i); // Mark the obstacle to be deleted
                }
            }
            if (!dodge)
            {
                score++;
            }
                
            Playerjump();
           // CheckCollision();
            DeleteObstacle(delList);
            // MakeObstacle();
            //Unsure if this next part is my job
            // TODO: Display the game state to the user.
            
        }

        // Checks an obstacle against the players position to determin if a collision has been detected.
        // When this returns false, in frame update, we will want to change the games running state
        private bool CheckCollision(IPiece _obstacle)
        {
            if (_obstacle.position.getX() != player.position.getX())
            {   
                return false;
            }
            else
            {
                for(int i = 0; i < _obstacle.ySize; i++)
                {
                    if (player.position.getY() == _obstacle.position.getY() + i || player.position.getY() + 1 == _obstacle.position.getY() + i)
                    {
                        return true;
                    }
                }
                return false;
            }
            throw new Exception("CheckCollision Failed");
        }

        // Randomly creates obstacles that are then stored in the obsticale list. Has a chance of not creating any obstical's
        private void MakeObstacle()

        {
            Random RNG = new Random();

            //1-50 Chance of the obstacle being a small rock
            if (RNG.Next(50) == 1)
            {
                Obstacles.Add(new SmallRock(displayXsize, 1));
            } 
            //1-75 Chance of the obstacle being a large rock
            else if (RNG.Next(75) == 1)
            {
                Obstacles.Add(new BigRock(displayXsize, 1));
            }
            //1-100 Chance of the obstacle being a bird
            else if (RNG.Next(100) == 1)
            {
                Obstacles.Add(new Bird(displayXsize, RNG.Next(2) + 3));
            }   
        }
        // When an obsticale has reached the minimum it can be (Far left of the view). Remove each obsticale that has reached the end of the screen
        private void DeleteObstacle(List<int> delThese)
        {
            // TODO: Delete each obstacle that is specified by delThese
            //To do this im thinking of in this iteration loop, store the index of each item that needs to be deleted. 
                 // Than deleting them from the largest index to the smallest. IE.If the obstacles stored at index 1, 3, and 10 need to be deleted. Delete them in order 10, 3, then 1.
                 // Deleteing them in reverse would preserve the integrity of the list as we delete multiple objects from it.Minimizing the amount of times we have to iterate through our obstacle list.
                //  We would then pass this array of indexes to be deleted to our delete method that would go in and delete them. -- Tanis Olesen
            for(int i = delThese.Count; i > 0; i--)
            {
                Obstacles.RemoveAt(delThese[i]);
            }
        }

        private void Playerjump()
        {
            //replace Jumpinfo with IOreturnObj.input when it's done.
            player.IsJumping = Jumpinfo;
            Jumpinfo = false;
        }

        
    }
}
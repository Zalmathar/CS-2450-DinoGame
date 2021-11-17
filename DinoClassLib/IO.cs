using System;

/// <summary>

namespace DinoClassLib
{
    public class IO
    {
        private static int maxScreenXsize = 60;
        public readonly static int maxFPS = 60;
        Pixel[,] Screen = new Pixel[maxScreenXsize, 6];
        private bool checkInput()
        {
            ConsoleKeyInfo cki;
            if (Console.KeyAvailable == true)
            {
                cki = Console.ReadKey(true);
                if (cki.Key.ToString() == "UpArrow" || cki.Key.ToString() == "Spacebar" || cki.Key.ToString() == "W")
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public IOReturner render(Controller ConsoleController)
        {

            //Set colors that should be different from default, making sure to stay within bounds.
            switch (ConsoleController.gameState)
            {

                case Controller.Status.pre:
                    Console.SetCursorPosition(0, 6);
                    Console.WriteLine("Welcome to the dinosaur game!");
                    Console.WriteLine("Please press up, 'w' or the space bar to begin");
                    Console.WriteLine("Use those buttons to make the dinosaur jump!");
                    Console.WriteLine("Don't hit the obstacles!");
                    Console.SetCursorPosition(0, 0);
                    break;
                case Controller.Status.running: //TODO:
                    // Create a new Screen Frame
                    for (int yi = 5; yi >= 0; yi--)
                    {
                        for (int xi = 0; xi < maxScreenXsize; xi++)
                        {
                            Screen[xi, yi] = new Pixel();
                            switch (yi)
                            {
                                case 6:
                                    Screen[xi, yi].backgroundColor = ConsoleColor.Blue;
                                    break;
                                case 0:
                                    Screen[xi, yi].backgroundColor = ConsoleColor.Green;
                                    break;
                                default:
                                    Screen[xi, yi].backgroundColor = ConsoleColor.Blue;
                                    break;
                            }
                        }
                    }

                    // Add player to screen
                    for (int i = 0; i < ConsoleController.player.YSize; i++)
                    {
                        // Player Safety check
                        if((ConsoleController.player.position.getX() != 3) || (ConsoleController.player.position.getY() > 3) || (ConsoleController.player.position.getY() < 1))
                        {
                            throw new Exception("Attempted to display a player at an invalid position");
                        }
                        // Create new pixel with formating for player
                        Pixel playerPixel = new Pixel();
                        playerPixel.foregroundColor = ConsoleColor.Black;
                        playerPixel.backgroundColor = ConsoleColor.Blue;
                        playerPixel.text = "||";
                        // overwrite the existing pixel with our new pixel at the correct position.
                        Screen[ConsoleController.player.position.getX(), i + ConsoleController.player.position.getY()] = playerPixel;
                    }

                    // Add Obstacles to screen
                    foreach (IPiece obst in ConsoleController.Obstacles)
                    {
                        //Obstacle X and Y safety Checks
                        if ((obst.position.getX() > maxScreenXsize) || (obst.position.getX() < 0) || (obst.position.getY() > 4) || (obst.position.getY() < 1))
                        {
                            throw new Exception("Attempted to display an obstacle at an invalid position");
                        }

                        Pixel obstPixel = new Pixel();
                        obstPixel.foregroundColor = ConsoleColor.Black;
                        Type obsType = obst.GetType();
                        if (obsType.Equals(typeof(Bird)))
                        {
                            obstPixel.backgroundColor = ConsoleColor.White;
                            obstPixel.text = "< ";
                        }
                        else if (obsType.Equals(typeof(SmallRock)) || obsType.Equals(typeof(BigRock)))
                        {
                            obstPixel.backgroundColor = ConsoleColor.Gray;
                            obstPixel.text = "XX";
                        }
                        else
                        {
                            // Obst is of an Invalid type
                            throw new Exception("Controller obstacle list contains an object type not supported");
                        }
                        for (int i = 0; i < obst.YSize; i++)
                        {
                            Screen[obst.position.getX() - 1, i + obst.position.getY()] = obstPixel;
                        }
                    }

                    Console.SetCursorPosition(0, 6);
                    Console.Write("Score: " + ConsoleController.Score + "                    ");
                    Console.SetCursorPosition(0, 0);
                    break;

                case Controller.Status.dead:
                    Console.SetCursorPosition(0, 6);
                    Console.WriteLine($"Youre final score is {ConsoleController.Score}");
                    Console.WriteLine("Please play again.");
                    Console.SetCursorPosition(0, 0);
                    break;
            }

            //Render screen
            for (int yi = 5; yi >= 0; yi--)
            {
                for (int xi = 0; xi < maxScreenXsize - 1; xi++)
                {
                    Console.BackgroundColor = Screen[xi, yi].backgroundColor;
                    Console.ForegroundColor = Screen[xi, yi].foregroundColor;
                    Console.Write(Screen[xi, yi].text);
                }
                Console.ResetColor();
                Console.Write("\n");
            }
            //render score below screen
            IOReturner returnVal = new IOReturner(checkInput(), maxScreenXsize);
            Console.SetCursorPosition(0, 0);
            return returnVal;
        }

        public IO()
        {
            for (int yi = 5; yi >= 0; yi--)
            {
                for (int xi = 0; xi < maxScreenXsize; xi++)
                {
                    Screen[xi, yi] = new Pixel();
                    switch (yi)
                    {
                        case 6:
                            Screen[xi, yi].backgroundColor = ConsoleColor.Blue;
                            break;
                        case 0:
                            Screen[xi, yi].backgroundColor = ConsoleColor.Green;
                            break;
                        default:
                            Screen[xi, yi].backgroundColor = ConsoleColor.Blue;
                            break;
                    }
                }
            }
        }

        public IO(int screenXsize)
        {
            //
            // TODO: Add constructor logic here
            maxScreenXsize = screenXsize;
            //initialize screen
            for (int yi = 5; yi >= 0; yi--)
            {
                for (int xi = 0; xi < maxScreenXsize; xi++)
                {
                    Screen[xi, yi] = new Pixel();
                    switch (yi)
                    {
                        case 6:
                            Screen[xi, yi].backgroundColor = ConsoleColor.Blue;
                            break;
                        case 0:
                            Screen[xi, yi].backgroundColor = ConsoleColor.Green;
                            break;
                        default:
                            Screen[xi, yi].backgroundColor = ConsoleColor.Blue;
                            break;
                    }
                }
            }
        }
    }

    public class IOReturner
    {

        public bool inputDetected { get; private set; }
        public int maxScreenXSize { get; private set; }

        public IOReturner(bool inputDetected, int maxScreenXSize)
        {
            this.inputDetected = inputDetected;
            this.maxScreenXSize = maxScreenXSize;

        }

    }

    public class Pixel
    {
        public string text;
        public ConsoleColor backgroundColor;
        public ConsoleColor foregroundColor;

        public Pixel()
        {
            text = "  ";
            backgroundColor = ConsoleColor.Black;
            foregroundColor = ConsoleColor.White;
        }
    }
}
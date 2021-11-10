using System;

/// <summary>

namespace DinoClassLib {
    public class IO
    {
        private int maxScreenXsize;
        private bool checkInput()
        {
            //TODO: Check for input
            return false;
        }
        public IOReturner render(Controller ConsoleController)
        {

            //TODO: render
            switch (ConsoleController.gameState)
            {
                case Controller.status.pre: //TODO: Impliment a pregame render
                    break;
                case Controller.status.running: //TODO: Impliment a running render
                    break;
                case Controller.status.dead: //TODO: Impliment a dead render
                    break;
            }
            //TODO: detect input

            IOReturner returnVal = new IOReturner(checkInput(), maxScreenXsize);
            return returnVal;

        }
        public IO()
        {
            //
            // TODO: Add constructor logic here
            //TODO: Add default screenXsize;
            //
        }
        public IO(int screenXsize)
        {
            //
            // TODO: Add constructor logic here
            this.maxScreenXsize = screenXsize;
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


}
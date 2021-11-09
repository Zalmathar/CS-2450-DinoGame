using System;

namespace DinoClassLib
{
    public class Player : IPiece
    {

        public Position position
        {
            get;
            set;
        }

        public int pointVal
        {
            get;
        }
        public int xSize
        {
            get;
        }

        public int ySize
        {
            get;
        }

        public bool IsJumping 
        {
            get;
            set;
        }


        public Player(int x, int y)
        {
            position = new Position(x, y);
            xSize = 1;
            ySize = 2;
            pointVal = 0;
            IsJumping = false;
            if (position.getY() != 3 || position.getX() != 1)
            {
                throw new NotImplementedException();
            }
        }
        public void onFrameUpdate()
        {
            //to be implemented with jump

        }
    }
}

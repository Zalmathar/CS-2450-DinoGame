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

        private int jumpstate = 0;

        public Player(int x, int y)
        {
            position = new Position(x, y);
            xSize = 1;
            ySize = 2;
            pointVal = 0;
            IsJumping = false;
            if (position.getY() != 1 || position.getX() != 3)
            {
                throw new NotImplementedException();
            }
        }
        public void onFrameUpdate()
        {

            if(jumpstate == 0 && IsJumping)
            {
                position.setY(2);
                jumpstate = 1;
            }else if(jumpstate == 1)
            {
                position.setY(3);
                jumpstate = 2;
            }else if(jumpstate == 2)
            {
                position.setY(3);
                jumpstate = 3;
            }
            else if(jumpstate == 3)
            {
                position.setY(2);
                jumpstate = 4;
            }
            else if(jumpstate == 4)
            {
                position.setY(1);
                jumpstate = 0;
            }

            IsJumping = false;

        }

        public void Jump()
        {

            IsJumping = true;
        }
    }
}

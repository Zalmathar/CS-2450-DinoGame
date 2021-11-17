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

        public int PointVal
        {
            get;
        }
        public int XSize
        {
            get;
        }

        public int YSize
        {
            get;
        }

        public bool IsJumping 
        {
            get;
            set;
        }

        private int _jumpstate = 0;

        public Player(Position p0)
        {
            position = p0;
            XSize = 1;
            YSize = 2;
            PointVal = 0;
            IsJumping = false;
            if (position.getY() != 1 || position.getX() != 3)
            {
                throw new NotImplementedException();
            }
        }
        public void OnFrameUpdate()
        {

            if(_jumpstate == 0 && IsJumping)
            {
                position.setY(2);
                _jumpstate = 1;
            }else if(_jumpstate == 1)
            {
                position.setY(3);
                _jumpstate = 2;
            }else if(_jumpstate == 2)
            {
                position.setY(3);
                _jumpstate = 3;
            }
            else if(_jumpstate == 3)
            {
                position.setY(2);
                _jumpstate = 4;
            }
            else if(_jumpstate == 4)
            {
                position.setY(1);
                _jumpstate = 0;
            }

            IsJumping = false;

        }

        public void Jump(bool input)
        {

            IsJumping = input;
        }
    }
}

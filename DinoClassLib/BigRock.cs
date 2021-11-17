using System;


    namespace DinoClassLib
{
    public class BigRock : IPiece
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

        public BigRock(Position p0)
        {
            position = p0;
            xSize = 1;
            ySize = 2;
            pointVal = 10;
            if (position.getY() != 1  || position.getX() <= 1)
            {
                throw new NotImplementedException();
            }
        }
        public void onFrameUpdate()
        {
            int x = position.getX();//getting the current x value
            position.setX(x - 1);//assuming bottom left is (0,0)
        }
    } }
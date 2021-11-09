using System;

namespace DinoClassLib
{
    public class SmallRock : IPiece { 
        
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

        public SmallRock(int x, int y)
        {
            position = new Position(x,y);
            xSize = 1;
            ySize = 1;
            pointVal = 8;
            if(position.getY() != 1 || position.getX() > 50 || position.getX() <= 1)
            {
                throw new NotImplementedException();
            }
        }
    public void onFrameUpdate()
        {
            int x = position.getX();//getting the current x value
            position.setX(x-1);//assuming bottom left is (0,0)

        }
    }
}

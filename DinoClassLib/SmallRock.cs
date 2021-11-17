using System;

namespace DinoClassLib
{
    public class SmallRock : IPiece { 
        
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

        public SmallRock(Position p0)
        {
            position = p0;
            XSize = 1;
            YSize = 1;
            PointVal = 8;
            //ensures it's constructed in the correct spot
            if(position.getY() != 1 || position.getX() <= 1)
            {
                throw new NotImplementedException();
            }
        }
    public void OnFrameUpdate()
        {
            int x = position.getX();//getting the current x value
            position.setX(x-1);//assuming bottom left is (0,0)

        }
    }
}

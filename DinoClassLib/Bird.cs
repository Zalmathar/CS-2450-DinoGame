using System;

namespace DinoClassLib
{
    public class Bird : IPiece { 
        
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

        public Bird(Position p0)
        {
            position = p0;
            XSize = 1;//unsure about this, clarify later
            YSize = 1;
            PointVal = 20;
            if(position.getY() < 3 || position.getY() > 4  || position.getX() <= 1)
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

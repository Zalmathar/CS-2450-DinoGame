using System;

namespace DinoClassLib
{
    public class Bird : IPiece { 
        
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

        public Bird(int x, int y)
        {
            position = new Position(x,y);
            xSize = 1;//unsure about this, clarify later
            ySize = 1;
            pointVal = 20;
            if(position.getY() < 3 || position.getY() > 4 || position.getX() > 50 || position.getX() <= 1)
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

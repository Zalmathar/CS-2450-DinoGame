using System;

namespace DinoClassLib
{
    interface IPiece
    {
        Position position
        {
            get;
        }  //protected? or private
        int pointVal
        {
            get;
        }
        public void onFrameUpdate();
    }

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

        SmallRock(int x)
        {
            position = new Position(x,0);
            pointVal = 8;
        }
    public void onFrameUpdate()
        {
            int x = position.getX();//getting the current x value
            position.setX(x-1);//assuming bottom left is (0,0)
        }
    }

}

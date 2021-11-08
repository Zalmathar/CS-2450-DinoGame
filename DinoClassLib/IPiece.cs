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
        int xSize
        {
            get;
        }

        int ySize
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

}//build test lines in steps file
//write test conditions
//figure out sc better- use romanizing as reference
//include this file in the steps file
//figure out what to do considering the piece interface isn't completely done
//finish it myself?

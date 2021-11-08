using System;

namespace DinoClassLib
{

	public class BigRock
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

        public BigRock(position po)
		{
            position = po;
            xSize = 1;
            ySize = 2;
            pointVal = 10;
            if (position.getY() != 1 || position.getX() > 50 || position.getX() <= 1)
            {
                throw new NotImplementedException();
            }
        }
	}

}

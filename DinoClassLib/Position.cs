using System;

namespace DinoClassLib
{
    public class Position
    {
        private int x_;
        private int y_;

        public Position(int x, int y)
        {
            x_ = x;
            y_ = y;
        }

        public void setX(int x)
        {
            x_ = x;
        }

        public void setY(int y)
        {
            y_ = y;
        }

        public int getX()
        {
            return x_;
        }

        public int getY()
        {
            return y_;
        }

    }
}
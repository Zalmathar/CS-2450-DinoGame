using System;

namespace DinoClassLib
{
    interface IPiece
    {
        Position position
        {
            get;
            set;
        }
        int pointVal
        {
            get;
            set;
        }
        int xSize
        {
            get;
            set;
        }

        int ySize
        {
            get;
            set;
        }
        public void onFrameUpdate();
    }
}

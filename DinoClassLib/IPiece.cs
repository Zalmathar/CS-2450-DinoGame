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
}

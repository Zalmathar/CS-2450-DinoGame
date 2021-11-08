using System;

namespace DinoClassLib
{
    public class BigRock : Ipiece
    {

        public BigRock(Position po)
        {
            position.set(po);
            pointVal.set(10);
            xSize.set(1);
            ySize.set(2);
        }

        public void onFrameUpdate()
        {
            position.setX(position.getX - 1);
        }

    }

}

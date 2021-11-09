namespace DinoClassLib
{
    public interface IPiece
    {
        Position position
        {
            get;
        }
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
}

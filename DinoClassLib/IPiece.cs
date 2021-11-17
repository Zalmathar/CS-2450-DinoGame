namespace DinoClassLib
{
    public interface IPiece
    {
        Position position
        {
            get;
        }
        int PointVal
        {
            get;
        }
        int XSize
        {
            get;
        }

        int YSize
        {
            get;
        }
        public void OnFrameUpdate();
    }
}

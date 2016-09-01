namespace GameOfLife
{
    public class Coordinate
    {
        public int XPosition { get; private set; }
        public int YPosition { get; private set; }
        
        public Coordinate(int xPosition, int yPosition)
        {
            XPosition = xPosition;
            YPosition = yPosition;
        }
    }
}
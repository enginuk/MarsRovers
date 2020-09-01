namespace MarsRovers
{
    public class Position
    {
        public int RoverXPosition { get; }
        public int RoverYPosition { get; }

        public Position(int roverXPosition, int roverYPosition)
        {
            RoverXPosition = roverXPosition;
            RoverYPosition = roverYPosition;
        }
    }
}
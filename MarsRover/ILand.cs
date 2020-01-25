namespace MarsRover
{
    public interface ILand
    {
        bool SetRoverLocation(Position spot);
        bool CheckCoordinate(Position spot);
    }
}
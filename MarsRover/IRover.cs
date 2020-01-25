namespace MarsRover
{
    public interface IRover
    {
        void RePosition(string instructions);
        string GetLocationInfo();
        bool IsLanded { get; set; }
    }
}
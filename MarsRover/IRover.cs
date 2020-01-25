namespace MarsRover
{
    public interface IRover
    {
        void RePosition(string instructions);
        void Move(Enums.Moving moving);
        string GetLocationInfo();
        bool IsLanded { get; set; }
    }
}
namespace MarsRover
{
    public class Position
    {
        private const char Separator = ' ';

        public Position(string coordinate)
        {
            X = byte.Parse(coordinate.Split(Separator)[0]);
            Y = byte.Parse(coordinate.Split(Separator)[1]);
        }

        public Position(Position location)
        {
            this.X = location.X;
            this.Y = location.Y;
        }

        public byte X { get; set; }
        public byte Y { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", X, Y);
        }
    }
}

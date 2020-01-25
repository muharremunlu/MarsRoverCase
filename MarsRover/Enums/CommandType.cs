namespace MarsRover.Enums
{
    /// <summary>
    /// Using for Inputs correction
    /// </summary>
    public enum CommandType
    {
        /// <summary>
        /// if the command is resizing the land
        /// </summary>
        LandSizing, 
        /// <summary>
        /// if the command is landing the rover
        /// </summary>
        RoverCoordinate, 
        /// <summary>
        /// if the command is moving the rover
        /// </summary>
        Instructions, 
        /// <summary>
        /// otherwise command
        /// </summary>
        Others
    }
}

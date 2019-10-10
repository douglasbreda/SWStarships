namespace SWStarships.Infrastructure
{
    /// <summary>
    /// Enum to know the time's unit of the starship
    /// </summary>
    public enum TimeUnit
    {
        None = 0,
        Day = 1,
        Week = 2,
        Month = 3,
        Year = 4
    }

    /// <summary>
    /// To know the type of message and set the color of the console
    /// </summary>
    public enum MessageType
    {
        Success = 0,
        Error = 1,
        Normal = 2
    }
}

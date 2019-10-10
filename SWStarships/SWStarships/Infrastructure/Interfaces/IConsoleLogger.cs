namespace SWStarships.Infrastructure.Interfaces
{
    public interface IConsoleLogger
    {
        #region [Methods]

        void Success( string message );

        void Error( string message );

        void Message( string message );

        #endregion
    }
}

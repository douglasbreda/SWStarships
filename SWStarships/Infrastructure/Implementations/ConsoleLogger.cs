using System;
using SWStarships.Infrastructure.Interfaces;

namespace SWStarships.Infrastructure.Implementations
{
    public class ConsoleLogger : IConsoleLogger
    {
        #region [Methods]

        /// <summary>
        /// Error message
        /// </summary>
        /// <param name="message"></param>
        public void Error( string message )
        {
            Write( message, MessageType.Error );
        }

        /// <summary>
        /// Normal message
        /// </summary>
        /// <param name="message"></param>
        public void Message( string message )
        {
            Write( message, MessageType.Normal );
        }

        /// <summary>
        /// Successful message
        /// </summary>
        /// <param name="message"></param>
        public void Success( string message )
        {
            Write( message, MessageType.Success );
        }

        /// <summary>
        /// Writes the message in the console
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        private void Write( string message, MessageType type )
        {
            var foregroundColor = Console.ForegroundColor;

            Console.ForegroundColor = GetColor( type );

            Console.WriteLine( message );

            Console.ForegroundColor = foregroundColor;
        }

        /// <summary>
        /// Returns the color of the letters according to the type of message
        /// </summary>
        /// <param name="messageType"></param>
        private ConsoleColor GetColor( MessageType messageType )
        {
            switch ( messageType )
            {
                case MessageType.Success:
                    return ConsoleColor.Green;
                case MessageType.Error:
                    return ConsoleColor.Red;
                case MessageType.Normal:
                    return ConsoleColor.White;
                default:
                    return ConsoleColor.White;
            }
        }

        #endregion
    }
}

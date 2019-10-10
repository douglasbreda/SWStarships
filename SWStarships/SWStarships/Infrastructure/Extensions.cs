using System;

namespace SWStarships.Infrastructure
{
    public static class Extensions
    {
        #region [Methods]

        /// <summary>
        /// Checks if a string has value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool HasValue( this string value )
        {
            return !string.IsNullOrEmpty( value );
        }

        /// <summary>
        /// Try to convert a string to long
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ToInt64( this string value )
        {
            try
            {
                return Convert.ToInt64( value );
            }
            catch
            {
                return 0;
            }
        }

        #endregion
    }
}

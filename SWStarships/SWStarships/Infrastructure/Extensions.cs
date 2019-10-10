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

        #endregion
    }
}

using System;
using SWStarships.Domain.Models;
using SWStarships.Infrastructure.Interfaces;

namespace SWStarships.Infrastructure.Implementations
{
    /// <summary>
    /// Class that contains the main functions used in the app
    /// </summary>
    public class Function : IFunction
    {
        #region [Interface]

        /// <summary>
        /// Calculates the hours according with the time's unit
        /// </summary>
        /// <param name="consumable"></param>
        /// <returns></returns>
        public long CalculateHours( Consumable consumable )
        {
            switch ( consumable.Unit )
            {
                case TimeUnit.Day:
                    return 24 * consumable.Time;
                case TimeUnit.Week:
                    return 168 * consumable.Time;
                case TimeUnit.Month:
                    return 730 * consumable.Time;
                case TimeUnit.Year:
                    return 8760 * consumable.Time;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Calculate the number of stops needed by each starship
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="mglt"></param>
        /// <param name="hours"></param>
        /// <returns></returns>
        public long CalculateStops( long distance, long mglt, long hours )
        {
            return distance / ( hours * mglt );
        }

        /// <summary>
        /// Split the complete url to get the next page
        /// </summary>
        /// <param name="completePath"></param>
        /// <returns></returns>
        public string GetNextPage( string completePath )
        {
            return completePath.Substring( completePath.LastIndexOf( "/" ) + 1 );
        }

        /// <summary>
        /// Splits the consumable's string to get the unit and the time
        /// </summary>
        /// <param name="consumableString"></param>
        /// <returns></returns>
        public Consumable SeparateConsumable( string consumableString )
        {
            if ( !consumableString.HasValue() )
                throw new ArgumentNullException( consumableString );

            string[] part = consumableString.Split( ' ' );

            return new Consumable( ToTimeUnit( part[1] ), Convert.ToInt64( part[0] ) );
        }

        /// <summary>
        /// Converts the string to TimeUnit class
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public TimeUnit ToTimeUnit( string unit )
        {
            switch ( unit )
            {
                case "day":
                case "days":
                    return TimeUnit.Day;
                case "month":
                case "months":
                    return TimeUnit.Month;
                case "week":
                case "weeks":
                    return TimeUnit.Week;
                case "year":
                case "years":
                    return TimeUnit.Year;
                default:
                    return TimeUnit.None;

            }
        }

        #endregion
    }
}
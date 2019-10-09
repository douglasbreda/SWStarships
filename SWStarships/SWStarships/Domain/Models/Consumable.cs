using SWStarships.Infrastructure;

namespace SWStarships.Domain.Models
{
    public class Consumable
    {
        #region [Properties]

        public TimeUnit Unit { get; set; }

        public long Time { get; set; }

        #endregion

        #region [Constructor]

        /// <summary>
        /// Default constructor
        /// </summary>
        public Consumable( TimeUnit unit, long time )
        {
            Unit = unit;
            Time = time;
        }

        #endregion
    }
}

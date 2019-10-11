using System.Collections.Generic;
using System.Threading.Tasks;
using SWStarships.Domain.Models;
using SWStarships.Infrastructure;
using SWStarships.Infrastructure.Interfaces;

namespace SWStarships
{
    public class App
    {
        #region [Properties]

        private readonly IDownload _download;
        private readonly IConsoleLogger _logger;
        private readonly IFunction _function;

        #endregion

        #region [Constructor]

        /// <summary>
        /// Constructor who receives an provider to get the instances and send to the classes
        /// </summary>
        /// <param name="provider"></param>
        public App( IDownload download, IConsoleLogger logger, IFunction function )
        {
            _download = download;
            _logger = logger;
            _function = function;
        }

        #endregion

        #region [Methods]

        /// <summary>
        /// Configures the app and run
        /// </summary>
        public async Task Start( long distance )
        {
            List<Starship> starships = await DownloadStarships();
            CalculateStops( distance, starships );
        }

        /// <summary>
        /// Download all the starships from the API
        /// </summary>
        /// <returns></returns>
        private async Task<List<Starship>> DownloadStarships()
        {
            _logger.Message( "Downloading starships from API.." );
            List<Starship> _starships = await _download.GetStarships();

            if ( _starships == null || _starships.Count == 0 )
                _logger.Error( "Was not possible to get the starthips from the API." );
            else
                _logger.Message( $"Found {_starships.Count} starships" );

            return _starships;
        }

        /// <summary>
        /// Calculates the distance for each starship
        /// </summary>
        /// <param name="starships"></param>
        private void CalculateStops( long distance, List<Starship> starships )
        {
            foreach ( Starship starship in starships )
            {
                if ( starship.MGLT.ToLower().Equals( "unknown" ) )
                {
                    _logger.Error( $"Unknown MGLT for {starship.name}" );
                    continue;
                }
                Consumable consumable = _function.SeparateConsumable( starship.consumables );

                long hours = _function.CalculateHours( consumable );

                long stops = _function.CalculateStops( distance, starship.MGLT.ToInt64(), hours );

                _logger.Success( $"The starship {starship.name} needs {stops} stop(s)" );
            }
        }

        #endregion
    }
}

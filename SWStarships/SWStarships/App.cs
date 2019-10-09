using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SWStarships.Domain.API;
using SWStarships.Domain.Models;
using SWStarships.Infrastructure.Interfaces;

namespace SWStarships
{
    public class App
    {
        #region [Properties]

        private readonly IDownload _download;
        private readonly IApi _api;

        #endregion

        #region [Constructor]

        /// <summary>
        /// Constructor who receives an provider to get the instances and send to the classes
        /// </summary>
        /// <param name="provider"></param>
        public App( IDownload download, IApi api )
        {
            _download = download;
            _api = api;
        }

        #endregion

        #region [Methods]

        /// <summary>
        /// Configures the app and run
        /// </summary>
        public async Task Start()
        {
            await DownloadStarships();
            long userInput = GetUserInput();

        }

        /// <summary>
        /// Download all the starships from the API
        /// </summary>
        /// <returns></returns>
        private async Task<List<Starship>> DownloadStarships()
        {
            Console.WriteLine( "Downloading starships from API.." );
            List<Starship> _starships = await _download.GetStarships();

            Console.WriteLine( $"Found {_starships.Count} starships" );

            return _starships;
        }

        /// <summary>
        /// Gets the user's input
        /// </summary>
        /// <returns></returns>
        private long GetUserInput()
        {
            long convertedValue = 0;
            Console.WriteLine( "Type the distance in MGLT: " );
            string value = Console.ReadLine();

            long.TryParse( value, out convertedValue );

            return convertedValue;
        }

        /// <summary>
        /// Calculates the distance for each starship
        /// </summary>
        /// <param name="starships"></param>
        private void CalculateStops( List<Starship> starships )
        {
            foreach ( Starship starship in starships )
            {

            }
        }

        #endregion
    }
}

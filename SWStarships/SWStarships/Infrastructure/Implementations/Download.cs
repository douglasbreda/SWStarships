using System.Collections.Generic;
using System.Threading.Tasks;
using SWStarships.Domain.API;
using SWStarships.Domain.Models;
using SWStarships.Infrastructure.Interfaces;

namespace SWStarships.Infrastructure.Implementations
{
    /// <summary>
    /// Class executed at the beginning to bring information about the starships from the API
    /// </summary>
    public class Download : IDownload
    {
        #region [Properties]

        private readonly IApi _api;

        #endregion

        #region [Constructor]

        /// <summary>
        /// Default constructor which receives an interface of IApi as parameter via dependecy injection
        /// </summary>
        /// <param name="api"></param>
        public Download( IApi api )
        {
            _api = api;
        }

        #endregion

        #region [Methods]

        

        /// <summary>
        /// Extract information about the startships from the API
        /// </summary>
        /// <returns></returns>
        public async Task<List<Starship>> GetStarships( string path = "" )
        {
            List<Starship> _starships = new List<Starship>();
            Result _result = await _api.Get<Result>();

            if ( string.IsNullOrEmpty( _result.next ) )
            {
                string page = Function.GetNextPage( path );
                _starships.AddRange( await GetStarships( page ) );
            }

            return _starships;
        }

        #endregion
    }
}

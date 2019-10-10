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
        private readonly IFunction _function;
        private List<Starship> _starships;

        #endregion

        #region [Constructor]

        /// <summary>
        /// Default constructor which receives an interface of IApi as parameter via dependecy injection
        /// </summary>
        /// <param name="api"></param>
        public Download( IApi api, IFunction function )
        {
            _api = api;
            _function = function;
            _starships = new List<Starship>();
        }

        #endregion

        #region [Methods]



        /// <summary>
        /// Extract information about the startships from the API
        /// </summary>
        /// <returns></returns>
        public async Task<List<Starship>> GetStarships( string path = "" )
        {
            Result _result = await _api.Get<Result>( path );

            if ( _result.next.HasValue() )
            {
                string page = _function.GetNextPage( _result.next );
                await GetStarships( page );

                _starships.AddRange( _result.starships );
            }
            else
                _starships.AddRange( _result.starships );


            //return _result.starships.ToList();
            return _starships;
        }

        #endregion
    }
}

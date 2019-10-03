using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SWStarships.Domain.API
{
    public class BaseApi : IApi
    {
        #region [Properties]

        private HttpClient _httpClient;

        #endregion

        #region [Constructor]

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseApi()
        {
            _httpClient = new HttpClient();
            //Create a configuration file to set the API path
        }

        #endregion

        #region [Interface]

        public string BaseUrl { get => "https://swapi.co/api/starships/"; }

        public T Get<T>( string path ) where T : class
        {
            throw new NotImplementedException();
        }

        #endregion

        #region [Methods]

        /// <summary>
        /// Configures the connection using HttpClient
        /// </summary>
        private void StartConnection()
        {
            _httpClient.BaseAddress = new Uri( BaseUrl );
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );
        }

        #endregion
    }
}

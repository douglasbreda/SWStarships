using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SWStarships.Domain.Models;

namespace SWStarships.Domain.API
{
    public class StarWarsApi : IApi
    {
        #region [Properties]

        private HttpClient _httpClient;

        #endregion

        #region [Constructor]

        /// <summary>
        /// Default constructor
        /// </summary>
        public StarWarsApi()
        {
            _httpClient = new HttpClient();
            StartConnection();
        }

        #endregion

        #region [Interface]

        //"https://swapi.co/api/starships/"
        public string BaseUrl { get => "https://swapi.co/api/"; }

        public async Task<T> Get<T>( string path ) where T : class
        {            
            HttpResponseMessage response = await _httpClient.GetAsync( path );

            string jsonString = await response.Content.ReadAsStringAsync();

            T starshipObject = JsonConvert.DeserializeObject<T>( jsonString );

            return starshipObject;
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

        /// <summary>
        /// Disposes the connection
        /// </summary>
        public void DisposeConnection()
        {
            _httpClient.Dispose();
        }

        #endregion
    }
}

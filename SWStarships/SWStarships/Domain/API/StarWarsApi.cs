using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SWStarships.Domain.API
{
    public class StarWarsApi : IApi
    {
        #region [Properties]

        private HttpClient _httpClient;
        private string _baseUrl = string.Empty;

        #endregion

        #region [Constructor]

        /// <summary>
        /// Default constructor
        /// </summary>
        public StarWarsApi()
        {
            _httpClient = new HttpClient();
            _baseUrl = "https://swapi.co/api/starships/";
            StartConnection();
        }

        #endregion

        #region [Interface]

        //"https://swapi.co/api/starships/"
        public string BaseUrl { get => _baseUrl; }

        /// <summary>
        /// Makes the first call to the api
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task<T> Get<T>( string path = "" ) where T : class
        {
            HttpResponseMessage response = null;

            if ( string.IsNullOrEmpty( path ) )
                response = await _httpClient.GetAsync( "" );
            else
                response = await _httpClient.GetAsync( path );

            string jsonString = await response.Content.ReadAsStringAsync();

            T starshipObject = JsonConvert.DeserializeObject<T>( jsonString );

            return starshipObject;
        }

        /// <summary>
        /// Get the result from the next returned on the previous request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        //public Task<T> GetNextPage<T>( string url ) where T : class
        //{
        //    string path = url.Substring( url.LastIndexOf( "/" ) + 1 );
        //    return Get<T>( path );
        //}

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

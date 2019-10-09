using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SWStarships.Domain.API;
using SWStarships.Domain.Models;
using Xunit;

namespace SWStarshipsTest.API
{
    public class ApiTest
    {
        #region [Tests]

        [Fact]
        public async void GetStartShipsTest()
        {
            StarWarsApi api = new StarWarsApi();

            var result = await api.Get<Result>();

            List<Starship> starships = result.starships.ToList();

            if ( !string.IsNullOrEmpty( result.next ) )
            {
                Result newPage = result;
                do
                {
                    string path = newPage.next.Substring( newPage.next.LastIndexOf( "/" ) + 1 );
                    newPage = await api.Get<Result>( path );
                    starships.AddRange( newPage.starships );

                } while ( !string.IsNullOrEmpty( newPage.next ) );
            }

        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
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

            var starships = await api.Get<RootObject>( "starships" );
        }

        #endregion
    }
}

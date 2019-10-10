using System.Collections.Generic;
using SWStarships.Domain.API;
using SWStarships.Domain.Models;
using Xunit;

namespace SWStarshipsTest.Domain
{
    public class ApiTest : Base
    {
        #region [Properties]

        private IApi _api;

        #endregion

        #region [Constructor]

        public ApiTest()
        {
            _api = GetService<IApi>();
        }

        #endregion

        #region [Tests]

        [Fact]
        public async void GetStartShipsTest()
        {
            Result result = await _api.Get<Result>();

            Assert.Equal( 37, result.count );
            Assert.Equal( "https://swapi.co/api/starships/?page=2", result.next );
            Assert.Null( result.previous );
            Assert.Equal( 37, result.starships.Length );
        }

        #endregion
    }
}

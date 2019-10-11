using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using SWStarships;
using SWStarships.Domain.API;
using SWStarships.Domain.Models;
using SWStarships.Infrastructure;
using SWStarships.Infrastructure.Interfaces;
using SWStarshipsTest.Auxiliar;
using Xunit;

namespace SWStarshipsTest
{
    public class TestApp : Base
    {
        #region [Properties]

        private readonly IDownload _download;
        private readonly IApi _api;
        private readonly IConsoleLogger _logger;
        private readonly IFunction _function;

        #endregion

        #region [Constructor]

        public TestApp()
        {
            _download = Substitute.For<IDownload>();
            _api = Substitute.For<IApi>();
            _logger = Substitute.For<IConsoleLogger>();
            _function = Substitute.For<IFunction>();
        }

        #endregion

        #region [Tests]

        [Fact]
        public async Task Test_app_mglt_invalid()
        {
            _download.GetStarships().Returns( TestFactory.CreateMockResultMGLTUnknown() );
            App app = new App( _download, _logger, _function );
            await app.Start( 100000 );

            _logger.Received().Error( "Unknown MGLT for Millennium Falcon" );
        }


        [Fact]
        public async Task Test_app_full()
        {
            long distance = 1000000;
            long hours = 13440;
            _download.GetStarships().Returns( TestFactory.CreateMock() );

            Starship starship = TestFactory.CreateMock().FirstOrDefault();
            Consumable consumable = new Consumable( TimeUnit.Week, 1 );

            _function.SeparateConsumable( starship.consumables ).Returns( consumable );
            _function.CalculateHours( consumable ).Returns( hours );
            _function.CalculateStops( distance, starship.MGLT.ToInt64(), hours ).Returns( 74 );

            App app = new App( _download, _logger, _function );
            await app.Start( distance );

            long expected = 74;

            _logger.Received().Success( $"The starship Millennium Falcon needs {expected} stop(s)" );

            _logger.Received( 2 ).Message( Arg.Any<string>() );
            _logger.Received( 1 ).Success( Arg.Any<string>() );
            _logger.Received( 0 ).Error( Arg.Any<string>() );
        }

        #endregion
    }
}

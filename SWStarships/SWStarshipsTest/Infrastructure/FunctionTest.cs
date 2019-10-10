using System;
using System.Collections.Generic;
using System.Text;
using SWStarships.Domain.Models;
using SWStarships.Infrastructure;
using SWStarships.Infrastructure.Interfaces;
using Xunit;


namespace SWStarshipsTest.Infrastructure
{
    public class FunctionTest : Base
    {
        #region [Properties]

        private IFunction _function;

        #endregion

        #region [Constructor]

        public FunctionTest()
        {
            _function = GetService<IFunction>();
        }

        #endregion

        #region [Calculate Hours Function]

        [Fact]
        public void Test_calculate_hours_day()
        {
            var hours = _function.CalculateHours( new Consumable( TimeUnit.Day, 12 ) );

            Assert.Equal( 288, hours );
        }

        [Fact]
        public void Test_calculate_hours_week()
        {
            var hours = _function.CalculateHours( new Consumable( TimeUnit.Week, 7 ) );

            Assert.Equal( 1176, hours );
        }

        [Fact]
        public void Test_calculate_hours_month()
        {
            var hours = _function.CalculateHours( new Consumable( TimeUnit.Month, 4 ) );

            Assert.Equal( 2920, hours );
        }

        [Fact]
        public void Test_calculate_hours_year()
        {
            var hours = _function.CalculateHours( new Consumable( TimeUnit.Year, 8 ) );

            Assert.Equal( 70080, hours );
        }

        [Fact]
        public void Test_calculate_hours_none()
        {
            var hours = _function.CalculateHours( new Consumable( TimeUnit.None, 220 ) );

            Assert.Equal( 0, hours );
        }

        [Fact]
        public void Test_calculate_hours_null()
        {
            Assert.Throws<ArgumentNullException>( () => _function.CalculateHours( null ) );
        }

        #endregion

        #region [Calculate Stops Function]

        [Fact]
        public void Test_calculate_stops()
        {
            var stops = _function.CalculateStops( 1000000, 80, 168 );

            Assert.Equal( 74, stops );
        }

        #endregion

        #region [Get Next Page Function]

        [Fact]
        public void Test_get_next_page()
        {
            string url = "https://swapi.co/api/starships/?page=2";

            var next_page = _function.GetNextPage( url );

            Assert.Equal( "?page=2", next_page );
        }

        [Fact]
        public void Test_get_next_page_empty()
        {
            var next_page = _function.GetNextPage( "" );

            Assert.Equal( "", next_page );
        }

        #endregion

        #region [Separate Consumable Function]

        [Fact]
        public void Test_separate_consumable()
        {
            var consumable = _function.SeparateConsumable( "1 week" );

            Assert.Equal( TimeUnit.Week, consumable.Unit );
            Assert.Equal( 1, consumable.Time );
        }

        [Fact]
        public void Test_separate_consumable_wrong()
        {
            var consumable = _function.SeparateConsumable( "2year" );

            Assert.Equal( TimeUnit.None, consumable.Unit );
            Assert.Equal( 0, consumable.Time );
        }

        [Fact]
        public void Test_separate_consumable_empty()
        {
            Assert.Throws<ArgumentNullException>( () => _function.SeparateConsumable( "" ) );   
        }

        #endregion

        #region [ToTimeUnit Function]

        [Fact]
        public void Test_time_unit_day()
        {
            var day = _function.ToTimeUnit( "day" );

            var days = _function.ToTimeUnit( "days" );

            Assert.Equal( TimeUnit.Day, day );
            Assert.Equal( TimeUnit.Day, days );
        }

        [Fact]
        public void Test_time_unit_week()
        {
            var week = _function.ToTimeUnit( "week" );

            var weeks = _function.ToTimeUnit( "weeks" );

            Assert.Equal( TimeUnit.Week, week );
            Assert.Equal( TimeUnit.Week, weeks );
        }


        [Fact]
        public void Test_time_unit_year()
        {
            var year = _function.ToTimeUnit( "year" );

            var years = _function.ToTimeUnit( "years" );

            Assert.Equal( TimeUnit.Year, year );
            Assert.Equal( TimeUnit.Year, years );
        }

        [Fact]
        public void Test_time_unit_empty()
        {
            var none = _function.ToTimeUnit( "" );

            Assert.Equal( TimeUnit.None, none );
        }

        [Fact]
        public void Test_time_unit_null()
        {
            var none = _function.ToTimeUnit( null );

            Assert.Equal( TimeUnit.None, none );
        }

        #endregion
    }
}

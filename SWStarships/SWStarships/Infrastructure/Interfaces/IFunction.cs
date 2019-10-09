using System;
using System.Collections.Generic;
using System.Text;
using SWStarships.Domain.Models;

namespace SWStarships.Infrastructure.Interfaces
{
    public interface IFunction
    {
        string GetNextPage( string completePath );

        TimeUnit ToTimeUnit( string unit );

        Consumable SeparateConsumable( string consumableString );

        long CalculateHours( Consumable consumable );

        long CalculateStops( long distance, long mglt, long hours );
    }
}

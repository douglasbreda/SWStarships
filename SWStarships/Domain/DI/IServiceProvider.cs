using System;

namespace SWStarships.Domain.DI
{
    public interface IServiceProvider
    {
        object GetService( Type serviceType );
    }
}

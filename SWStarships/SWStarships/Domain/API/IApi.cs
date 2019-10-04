using System.Collections.Generic;
using System.Threading.Tasks;

namespace SWStarships.Domain.API
{
    public interface IApi
    {
        string BaseUrl { get; }

        Task<T> Get<T>( string path ) where T : class;
    }
}

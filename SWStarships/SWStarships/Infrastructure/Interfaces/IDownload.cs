using System.Collections.Generic;
using System.Threading.Tasks;
using SWStarships.Domain.Models;

namespace SWStarships.Infrastructure.Interfaces
{
    public interface IDownload
    {
        #region [Definitions]

        Task<List<Starship>> GetStarships( string path = "" );

        #endregion
    }
}

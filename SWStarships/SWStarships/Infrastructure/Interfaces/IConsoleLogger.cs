using System;
using System.Collections.Generic;
using System.Text;

namespace SWStarships.Infrastructure.Interfaces
{
    public interface IConsoleLogger
    {
        #region [Methods]

        void Success( string message );

        void Error( string message );

        #endregion
    }
}

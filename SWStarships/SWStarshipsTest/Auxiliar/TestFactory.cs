using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SWStarships.Domain.Models;

namespace SWStarshipsTest.Auxiliar
{
    public static class TestFactory
    {
        public static List<Starship> CreateMock()
        {
            return new List<Starship>
            {
                new Starship
                {
                    name = "Millennium Falcon",
                    MGLT = "80",
                    consumables = "1 week"
                }
            };
        }

        /// <summary>
        /// Create a result with a starship with MGLT unknown
        /// </summary>
        /// <returns></returns>
        public static List<Starship> CreateMockResultMGLTUnknown()
        {
            return new List<Starship>
            {
                new Starship
                {
                    name = "Millennium Falcon",
                    MGLT = "unknown",
                    consumables = "3 days"
                }
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest1._1
{
    class Hex
    {
        public enum terrainType { Desert, Forest, Field, Pasture, Mountains, Hills }

        private terrainType terrain;
        private int token;

        public Hex()
        {

        }

        public Hex(terrainType terra, int num)
        {
            terrain = terra;
            token = num;
        }

        public terrainType Terrain
        {
            get
            {
                return terrain;
            }
        }

        public int Token
        {
            get
            {
                return token;
            }
        }
    }
}

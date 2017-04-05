using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest1._1.Forms
{
    class Node
    {
        private float locX, locY;
        public Settlement Settlement = null;

        public Node(float x, float y)
        {
            locX = x;
            locY = y;
        }

        public float LocationX
        {
            get { return locX; }
        }

        public float LocationY
        {
            get { return locY; }
        }
    }
}

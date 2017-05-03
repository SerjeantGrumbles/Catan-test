using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace IntegrationTest1._1
{
    public class Edge
    {
        private PointF ptA;
        private PointF ptB;
        public Road Road = null;

        public Edge(PointF a, PointF b)
        {           
            ptA = a;
            ptB = b;
        }

        public PointF PointA
        {
            get { return ptA; }
        }

        public PointF PointB
        {
            get { return ptB; }
        }
    }
}

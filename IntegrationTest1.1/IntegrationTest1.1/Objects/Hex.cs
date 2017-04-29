using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using IntegrationTest1._1.Properties;

namespace IntegrationTest1._1
{
    public class Hex
    {
        public enum terrainType { Desert, Forest, Field, Pasture, Mountains, Hills }

        private terrainType terrain;
        private int token;
        private PointF[] points = new PointF[6];
        private float midX, midY;
        private static float rad = 60;
        private bool thief = false;

        public Hex(terrainType terra)
        {
            terrain = terra;
        }

        public Hex(Hex h, int num, float x, float y)
        {
            terrain = h.Terrain;
            token = num;
            midX = x;
            midY = y;
            if (Terrain == terrainType.Desert)
            {
                thief = true;
            }
        }

        public terrainType Terrain
        {
            get
            { return terrain; }
        }

        public int Token
        {
            get
            { return token; }
        }

        public Image Image
        {
            get
            {
                object O = Resources.ResourceManager.GetObject(Convert.ToString(Terrain));
                Image image = (Image)O;
                return image;
            }
        }

        public float MidpointX
        {
            get { return midX; }
        }

        public float MidpointY
        {
            get { return midY; }
        }

        public static float Radius
        {
            get { return rad; }
        }

        public PointF[] Points
        {
            get
            {
                PointF[] points = new PointF[6];
                //Create 6 points
                for (int a = 0; a < 6; a++)
                {
                    float xCoord = MidpointX + Hex.Radius * (float)Math.Sin(a * 60 * Math.PI / 180f);
                    float yCoord = MidpointY + Hex.Radius * (float)Math.Cos(a * 60 * Math.PI / 180f);
                    points[a] = new PointF(xCoord, yCoord);
                }
                return points;
            }
        }

        public bool Thief
        {
            get { return thief; }
        }

        public void MoveThief(Hex destinationHex)
        {
            thief = false;
            destinationHex.thief = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2008.Classes
{
    class MapData
    {

        public int X, Y;
        public MapData(int X, int Y)
        {
            int[,] map = new int[Y, X];
            this.X = X;
            this.Y = Y;
            Noise2d.Reseed();

            for(int y = 0; y < Y; y++)
            {
                for(int x = 0; x < X; x++)
                {

                }
            }
        }
    }
}

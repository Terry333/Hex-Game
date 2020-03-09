using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _2008.Classes
{
    class MapData
    {

        public int X, Y;
        public MapData(int X, int Y)
        {
            int[,] terrainMap = new int[Y, X];
            int[,] developmentMap = new int[Y, X];
            this.X = X;
            this.Y = Y;
            Noise2d.Generate(X, Y, 8, 6, out terrainMap, out developmentMap);

            string dataMap = string.Empty;
            string dataMapTerrain = string.Empty;
            string dataMapDevelopment = string.Empty;

            for (int y = 0; y < Y; y++)
            {
                for (int x = 0; x < X; x++)
                {
                    dataMapTerrain = dataMapTerrain + terrainMap[y, x].ToString();
                    dataMapDevelopment = dataMapDevelopment + developmentMap[y, x].ToString();
                }
                dataMapTerrain = dataMapTerrain + "\n";
                dataMapDevelopment = dataMapDevelopment + "\n";
            }

            dataMap = dataMap + dataMapTerrain + ";" + dataMapDevelopment;

            File.WriteAllText(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory.ToString()).ToString()) + "\\Data\\Map.data", dataMap);

            Console.WriteLine("Finished!");
        }
    }
}

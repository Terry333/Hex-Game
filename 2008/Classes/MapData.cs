using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using _2008.Enums;
using SimplexNoise;

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

            string dataMap = string.Empty;
            string dataMapTerrain = string.Empty;
            string dataMapDevelopment = string.Empty;

            SimplexNoise.Noise.Seed = new Random().Next();
            float[,] noiseValues = SimplexNoise.Noise.Calc2D(this.X, this.Y, 0.1f);

            float maxValue = GetMaxValue(noiseValues);

            int[,] terrainIntArray;

            NormalizeArray(noiseValues, maxValue, out terrainIntArray);

            for (int y = 0; y < this.Y; y++)
            {
                for (int x = 0; x < this.X; x++)
                {
                    dataMapTerrain = dataMapTerrain + terrainIntArray[x, y].ToString() + " , ";
                    //dataMapDevelopment = dataMapDevelopment + developmentMap[y, x].ToString();
                }
                dataMapTerrain = dataMapTerrain + "\n";
                dataMapDevelopment = dataMapDevelopment + "\n";
            }

            dataMap = dataMap + dataMapTerrain + ";" + dataMapDevelopment;

            File.WriteAllText(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory.ToString()).ToString()) + "\\Data\\Map.data", dataMap);

            Console.WriteLine("Finished!");
        }

        private float GetMaxValue(float[,] array)
        {
            float max = 0.0f;
            for (int y = 0; y < Y; y++)
            {
                for(int x = 0; x < X; x++)
                {
                    max = max < array[x, y] ? array[x, y] : max;
                }
            }
            return max;
        }

        private void NormalizeArray(float[,] inArray, float maxValue, out int[,] outArray)
        {
            outArray = new int[X,Y];
            int max = Enum.GetValues(typeof(Terrain)).Length;
            float[] upperBounds = new float[max];

            float baseIncrement = maxValue / max;
            for(int i = 1; i <= max; i++)
            {
                upperBounds[i - 1] = baseIncrement * i;
                Console.WriteLine(upperBounds[i - 1].ToString());
            }

            for(int y = Y; y < Y; y++)
            {
                for(int x = 0; x < X; x++)
                {
                    float value = inArray[x, y];
                    for(int i = 0; i < max; i++)
                    {
                        if (value <= upperBounds[i])
                            outArray[x, y] = i;
                    }
                }
            }
        }
    }
}

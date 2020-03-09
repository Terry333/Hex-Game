using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public static class Noise2d
{
    public static void Generate(int X, int Y, int amplitude, int cityNodes, out int [,] terrainMap, out int[,] developmentMap)
    {
        int plateauLength = amplitude / 4;
        terrainMap = new int[Y,X];
        developmentMap = new int[Y,X];
        Random rand = new Random();
        int[] takenCitySpacesX = new int[cityNodes];
        int[] takenCitySpacesY = new int[cityNodes];
        for(int y = 0; y < Y; y++)
        {
            for(int x = 0; x < X; x++)
            {
                terrainMap[y, x] = 3;
                developmentMap[y, x] = rand.Next(1, 5);
            }
        }
        for(int i = 0; i < cityNodes; i++)
        {
            // Finding some coordinates for a city.
            bool foundRealCityCoords = false;
            int randCityX = 0;
            int randCityY = 0;
            while (foundRealCityCoords == false)
            {
                randCityX = rand.Next(0, X);
                randCityY = rand.Next(0, Y);
                for(int y1 = 0; y1 < cityNodes; y1++)
                {
                    for(int x1 = 0; x1 < cityNodes; x1++)
                    {
                        if(takenCitySpacesY[y1] != randCityY && takenCitySpacesX[x1] != randCityX)
                        {
                            foundRealCityCoords = true;
                        }
                    }
                }

            }
            // Found coordinates for a city.
            for(int away = 0; away < amplitude; away++)
            {
                for(int aroundY = -plateauLength; aroundY < plateauLength; aroundY++)
                {
                    for(int aroundX = -away; aroundX < amplitude; aroundX++)
                    {
                        try
                        {
                            int trueX = randCityX - (away + aroundX);
                            int trueY = randCityY - (away + aroundY);
                            int bottomX = trueX + away;
                            int bottomY = randCityY + away;
                            terrainMap[trueY, trueX] = 3 - (away / plateauLength);
                            developmentMap[trueY, trueX] = ((away / plateauLength) - 4) * rand.Next(1, 6);

                            terrainMap[bottomY, bottomX] = 3 - (away / plateauLength);
                            developmentMap[bottomY, bottomX] = ((away / plateauLength) - 4) * rand.Next(1, 6);
                        }
                        catch
                        {
                            Console.WriteLine("Hit Edge.");
                        }
                    }
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

public static class Noise2d
{
    public static void Generate(int x, int y, int amplitude, int cityNodes, out int [,] terrainMap, out int[,] developmentMap)
    {
        int plateauLength = amplitude / 4;
        terrainMap = new int[y,x];
        developmentMap = new int[y, x];
        Random rand = new Random();
        int[] takenCitySpacesX = new int[cityNodes];
        int[] takenCitySpacesY = new int[cityNodes];
        for(int i = 0; i < cityNodes; i++)
        {
            // Finding some coordinates for a city.
            bool foundRealCityCoords = false;
            int randCityX;
            int randCityY;
            while (foundRealCityCoords == false)
            {
                randCityX = rand.Next(0, x);
                randCityY = rand.Next(0, y);
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
        }
    }
}
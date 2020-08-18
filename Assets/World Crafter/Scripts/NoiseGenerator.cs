using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldCrafter
{
    public static class NoiseGenerator
    {
        public static float[,] GeneratePerlinNoise(int width,int height,float scale)
        {
            if (scale == 0)
                scale = 0.00001f;

            var noise = new float[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var x = i / scale;
                    var y = j / scale;

                    noise[i, j] = Mathf.PerlinNoise(x, y);
                }
            }

            return noise;
        }
    }

}
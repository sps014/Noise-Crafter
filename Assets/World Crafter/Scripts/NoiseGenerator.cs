using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldCrafter
{
    public readonly struct NoiseConfig
    {
        public int NoOfLayers { get; }
        public float Persistance { get; }
        public float Lacunarity { get; }

        public NoiseConfig(int noOfLayers, float persistance, float lacunarity)
        {
            NoOfLayers = noOfLayers;
            Persistance = persistance;
            Lacunarity = lacunarity;
        }

    }
    public static class NoiseGenerator
    {
        public static float[,] GeneratePerlinNoise(int width,int height,float scale,int seed,NoiseConfig noiseConfig,Vector2 offset)
        {
        var RandomGen = new System.Random(seed);
            if (scale == 0)
                scale = 0.00001f;
            var octaveOffset = new Vector2[noiseConfig.NoOfLayers];
            for (int i = 0; i < octaveOffset.Length; i++)
            {
                var offsetX = RandomGen.Next(-100000, 100000)+offset.x;
                var offsetY = RandomGen.Next(-100000, 100000)+offset.y;
                octaveOffset[i] = new Vector2(offsetX, offsetY);

            }

            var noise = new float[width, height];
            var maxNoiseHeight = float.MinValue;
            var minNoiseHeight = float.MaxValue;

            var halfWidth = width / 2;
            var halfHeight = height / 2;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    float noiseHeight=0.0f;
                    float frequency = 1;
                    float amplitude = 1;
                    for (int k = 0; k < noiseConfig.NoOfLayers; k++)
                    {
                        var x = (i-halfWidth) / scale*frequency+octaveOffset[k].x;
                        var y = (j-halfHeight) / scale*frequency+octaveOffset[k].y;
                        float perlin = Mathf.PerlinNoise(x, y) * 2 - 1;
                        noiseHeight += perlin * amplitude;
                        amplitude *= noiseConfig.Persistance;
                        frequency *= noiseConfig.Lacunarity;
                    }
                    if (noiseHeight > maxNoiseHeight)
                        maxNoiseHeight = noiseHeight;
                    else if (noiseHeight < minNoiseHeight)
                        minNoiseHeight = noiseHeight;

                    noise[i, j] = noiseHeight;

                }
            }

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    noise[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noise[x, y]);
                }
            }

            return noise;
        }
    }

}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldCrafter.EditorUtility
{
    public class MapGenerator : MonoBehaviour
    {
        public int Width = 256;
        public int Height = 256;
        public float Scale = 27.0f;
        public bool AutoGenerate = false;
        public int NoOfLayers=7;
        [Range(0,1)]
        public float Persistane = 0.5f;
        public float Lacunarity = 1.87f;
        public Vector2 Offset;
        public int Seed = 124;
        public TerrainLayer[] Layers;
        public void GenerateMap()
        {
            var map = NoiseGenerator.GeneratePerlinNoise(Width, Height, Scale,Seed,new NoiseConfig(NoOfLayers,Persistane,Lacunarity),Offset);
            GenerateColors();
            var display = FindObjectOfType<MapTextureRenderer>();
            display.DrawNoiseMap(map);
        }
        void GenerateColors(float[,] map)
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    var current = map[i, j];
                    
                }
            }
        }
        void OnValidate()
        {
            if (Width < 1)
                Width = 1;
            if (Height < 1)
                Height = 1;
            if(Lacunarity<1)
            {
                Lacunarity = 1;
            }
            if(NoOfLayers<0)
            {
                NoOfLayers = 1;
            }
        }

        [Serializable]
        public struct TerrainLayer
        {
            public string Name;
            public float Height;
            public Color Color;
        }
    }

}

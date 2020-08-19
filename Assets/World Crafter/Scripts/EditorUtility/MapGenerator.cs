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
        public float Persistane = 0.5f;
        public float Lacunarity = 1.87f;
        public void GenerateMap()
        {
            var map = NoiseGenerator.GeneratePerlinNoise(Width, Height, Scale,new NoiseConfig(NoOfLayers,Persistane,Lacunarity));
            var display = FindObjectOfType<MapTextureRenderer>();
            display.DrawNoiseMap(map);
        }

    }

}

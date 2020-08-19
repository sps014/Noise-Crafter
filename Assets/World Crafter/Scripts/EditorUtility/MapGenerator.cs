using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldCrafter.EditorUtility
{
    public class MapGenerator : MonoBehaviour
    {
        public int Width = 256;
        public int Height = 256;
        public float Scale = 0.3f;
        public bool AutoGenerate = false;
        public int NoOfLayers=4;
        public float Persistane = 0.1f;
        public float Lacunarity = 0.1f;
        public void GenerateMap()
        {
            var map = NoiseGenerator.GeneratePerlinNoise(Width, Height, Scale,new NoiseConfig(NoOfLayers,Persistane,Lacunarity));
            var display = FindObjectOfType<MapTextureRenderer>();
            display.DrawNoiseMap(map);
        }

    }

}

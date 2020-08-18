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
        public void GenerateMap()
        {
            var map = NoiseGenerator.GeneratePerlinNoise(Width, Height, Scale);
            var display = FindObjectOfType<MapTextureRenderer>();
            display.DrawNoiseMap(map);
        }

    }

}

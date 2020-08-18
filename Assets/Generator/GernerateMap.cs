using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldCrafter;

public class GernerateMap : MonoBehaviour
{
    public int Width=256;
    public int Height=256;
    public float Scale = 0.3f;
    public bool AutoGenerate = false;
    public void GenerateMap()
    {
        var map=NoiseGenerator.GeneratePerlinNoise(Width, Height, Scale);
        var display = FindObjectOfType<DisplayMap>();
        display.DrawNoiseMap(map);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMap : MonoBehaviour
{
    public Renderer renderer;

    public void DrawNoiseMap(float[,] map)
    {
        int width = map.GetLength(0);
        int height = map.GetLength(1);
        var texture = new Texture2D(width, height);
        var colorMap = new Color[width*height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                colorMap[x + y * width]=Color.Lerp(Color.black,Color.white,map[x,y]);
            }
        }
        texture.SetPixels(colorMap);
        texture.Apply();
        renderer.sharedMaterial.mainTexture = texture;
        renderer.transform.localScale = new Vector3(width,1,height);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

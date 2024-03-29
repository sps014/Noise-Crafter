﻿using UnityEngine;

namespace WorldCrafter.EditorUtility
{
    public class MapTextureRenderer : MonoBehaviour
    {
        public Renderer TextureRenderer;

        public void DrawNoiseMap(float[,] map)
        {
            int width = map.GetLength(0);
            int height = map.GetLength(1);
            var texture = new Texture2D(width, height);
            texture.filterMode = FilterMode.Point;
            texture.wrapMode = TextureWrapMode.Clamp;
            var colorMap = new Color[width * height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    colorMap[x*height + y] = Color.Lerp(Color.black, Color.white, map[x, y]);
                }
            }
            texture.SetPixels(colorMap);
            texture.Apply();
            TextureRenderer.sharedMaterial.mainTexture = texture;
            TextureRenderer.transform.localScale = new Vector3(width, 1, height);
        }
        public void DrawColorMap(Color[] colorMap,int width,int height)
        {
            var texture = new Texture2D(width, height);
            texture.filterMode = FilterMode.Point;
            texture.wrapMode = TextureWrapMode.Clamp;
            texture.SetPixels(colorMap);
            texture.Apply();
            TextureRenderer.sharedMaterial.mainTexture = texture;
            TextureRenderer.transform.localScale = new Vector3(width, 1, height);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace WorldCrafter
{
    [CustomEditor(typeof(MapGenerator))]
    public class WorldCrafterEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var mapGenerator = target as MapGenerator;
            if (DrawDefaultInspector())
            {
                if (mapGenerator.AutoGenerate)
                {
                    mapGenerator.GenerateMap();
                }
            }
            if (GUILayout.Button("Generate"))
            {
                mapGenerator.GenerateMap();
            }
        }
    }

}

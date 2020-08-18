using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GernerateMap))]
public class WorldCrafterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var mapgen = target as GernerateMap;
        if(DrawDefaultInspector())
        {
            if(mapgen.AutoGenerate)
            {
                mapgen.GenerateMap();
            }
        }
        if(GUILayout.Button("Generate"))
        {
            mapgen.GenerateMap();
        }
    }
}

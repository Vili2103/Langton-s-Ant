using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GridGenerator), true)]
public class DungeonEditor : Editor
{
    GridGenerator generator;
    

    private void Awake()
    {
        generator = (GridGenerator)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Generate Grid"))
        {
            generator.GenerateGrid();
        }
        if (GUILayout.Button("Clear Tiles"))
        {
            generator.ClearAll();
        }
    }
}
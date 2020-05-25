using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Sample1))]
public class Sample1Editor : Editor
{
    private void OnSceneGUI()
    {
        // Starts an area to draw elements
        GUILayout.BeginArea(new Rect(10, 10, 100, 100));
        GUILayout.Button("Click me");
        GUILayout.Button("Or me");
        GUILayout.EndArea();
    }
}

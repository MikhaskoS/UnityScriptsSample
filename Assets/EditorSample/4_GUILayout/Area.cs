using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;


public class Area : MonoBehaviour
{
    // Кнопки и все остальное появляются во время выполнения

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 100, 100));

        GUILayout.Button("Click me");
        GUILayout.Button("Or me");

        GUILayout.EndArea();
    }
}

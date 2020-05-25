using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

[CustomEditor(typeof(AI))]
public class AIInspector : Editor
{
    AI ai;

    private void OnEnable()
    {
        ai = (AI)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
    }

    private void OnSceneGUI()
    {
        //-----------
        Handles.Label(ai.transform.position + 5 * Vector3.up, "Hello Handler: " + ai.name);
        ai.AreaRadius = Handles.RadiusHandle(Quaternion.identity, ai.transform.position, ai.AreaRadius);

        ai.Speed = Handles.ScaleValueHandle(ai.Speed, ai.transform.position, Quaternion.identity,
            ai.Speed, Handles.ArrowHandleCap, 0.5f);
        //-----------
        if (ai.ShowNodeHandles)
        {
            for (int i = 0; i < ai.NodePoints.Length; i++)
            {
                ai.NodePoints[i] = Handles.PositionHandle(ai.NodePoints[i], ai.NodePointsRotation[i]);
            }
        }

        Handles.color = Color.blue;

        for (int i = 0; i < ai.NodePoints.Length; i++)
        {
            Handles.DrawLine(ai.NodePoints[i],
                ai.NodePoints[(int)Mathf.Repeat(i + 1, ai.NodePoints.Length)]);
        }

        if (ai.ShowNodeHandles)
        {
            for (int i = 0; i < ai.NodePointsRotation.Length; i++)
            {
                ai.NodePointsRotation[i] = Handles.RotationHandle(ai.NodePointsRotation[i],
                    ai.NodePoints[i]);
            }
        }

        Handles.BeginGUI();

        GUILayout.BeginVertical();
        
        GUILayout.Label("Test");

        GUILayout.BeginArea(new Rect(20, 50, 50, 500));
        if (GUILayout.Button("Test", GUILayout.MinHeight(50)))
        {
            Debug.Log("Ups...");
        }
        if (GUILayout.Button("Test", GUILayout.MinHeight(50)))
        {
            Debug.Log("Ups...");
        }
        if (GUILayout.Button("Test", GUILayout.MinHeight(50)))
        {
            Debug.Log("Ups...");
        }
        if (GUILayout.Button("Test", GUILayout.MinHeight(50)))
        {
            Debug.Log("Ups...");
        }
        if (GUILayout.Button("Test", GUILayout.MinHeight(50)))
        {
            Debug.Log("Ups...");
        }
        GUILayout.EndArea();

        GUILayout.EndVertical();
        Handles.EndGUI();
    }
}

using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(LabelExample))]
public class LabelExampleEditor : Editor
{
    void OnSceneGUI()
    {
        LabelExample labelExample = (LabelExample)target;
        if (labelExample == null)
        {
            return;
        }

        Handles.color = Color.blue;
        Handles.Label(labelExample.transform.position + Vector3.up * 2,
            labelExample.transform.position.ToString() + "\nShieldArea: " +
            labelExample.shieldArea.ToString());

        Handles.BeginGUI();
        if (GUILayout.Button("Reset Area", GUILayout.Width(100)))
        {
            labelExample.shieldArea = 5;
        }
        Handles.EndGUI();


        Handles.DrawWireArc(labelExample.transform.position,
            labelExample.transform.up,
            -labelExample.transform.right,
            180,
            labelExample.shieldArea);

        labelExample.shieldArea =
            Handles.ScaleValueHandle(labelExample.shieldArea,
                labelExample.transform.position + labelExample.transform.forward * labelExample.shieldArea,
                labelExample.transform.rotation,
                1,
                Handles.ConeHandleCap,
                1);
    }
}

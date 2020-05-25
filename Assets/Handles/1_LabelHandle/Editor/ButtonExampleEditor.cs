using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ButtonExample)), CanEditMultipleObjects]
class ButtonExampleEditor : Editor
{
    // https://docs.unity3d.com/ScriptReference/Handles.Button.html

    protected virtual void OnSceneGUI()
    {
        ButtonExample buttonExample = (ButtonExample)target;

        Vector3 position = buttonExample.transform.position + Vector3.up * 2f;
        float size = 2f;
        float pickSize = size * 2f;

        if (Handles.Button(position, Quaternion.identity, size, pickSize, Handles.RectangleHandleCap))
            Debug.Log("The button was pressed!");
    }
}

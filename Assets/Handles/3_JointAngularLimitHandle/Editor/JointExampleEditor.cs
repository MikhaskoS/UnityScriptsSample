using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

// https://docs.unity3d.com/ScriptReference/IMGUI.Controls.JointAngularLimitHandle.html
[CustomEditor(typeof(JointExample)), CanEditMultipleObjects]
public class JointExampleEditor : Editor
{
    JointAngularLimitHandle m_Handle = new JointAngularLimitHandle();

    // the OnSceneGUI callback uses the Scene view camera for drawing handles by default
    protected virtual void OnSceneGUI()
    {
        var jointExample = (JointExample)target;

        // copy the target object's data to the handle
        m_Handle.xMin = jointExample.xMin;
        m_Handle.xMax = jointExample.xMax;

        // CharacterJoint and ConfigurableJoint implement y- and z-axes symmetrically
        m_Handle.yMin = -jointExample.yMax;
        m_Handle.yMax = jointExample.yMax;

        m_Handle.zMin = -jointExample.zMax;
        m_Handle.zMax = jointExample.zMax;

        // set the handle matrix to match the object's position/rotation with a uniform scale
        Matrix4x4 handleMatrix = Matrix4x4.TRS(
            jointExample.transform.position,
            jointExample.transform.rotation,
            Vector3.one
        );

        EditorGUI.BeginChangeCheck();

        using (new Handles.DrawingScope(handleMatrix))
        {
            // maintain a constant screen-space size for the handle's radius based on the origin of the handle matrix
            m_Handle.radius = 2*HandleUtility.GetHandleSize(Vector3.zero);

            // draw the handle
            EditorGUI.BeginChangeCheck();
            m_Handle.DrawHandle();
            if (EditorGUI.EndChangeCheck())
            {
                // record the target object before setting new values so changes can be undone/redone
                Undo.RecordObject(jointExample, "Change Joint Example Properties");

                // copy the handle's updated data back to the target object
                jointExample.xMin = m_Handle.xMin;
                jointExample.xMax = m_Handle.xMax;

                jointExample.yMax = m_Handle.yMax == jointExample.yMax ? -m_Handle.yMin : m_Handle.yMax;

                jointExample.zMax = m_Handle.zMax == jointExample.zMax ? -m_Handle.zMin : m_Handle.zMax;
            }
        }
    }
}
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;


[CustomEditor(typeof(ProjectileExample))]
public class ProjectileExampleEditor : Editor
{
    ArcHandle m_ArcHandle = new ArcHandle();

    protected virtual void OnEnable()
    {
        // arc handle has no radius handle by default
        m_ArcHandle.SetColorWithRadiusHandle(Color.white, 0.1f);
    }

    // the OnSceneGUI callback uses the Scene view camera for drawing handles by default
    protected virtual void OnSceneGUI()
    {
        ProjectileExample projectileExample = (ProjectileExample)target;

        // copy the target object's data to the handle
        m_ArcHandle.angle = projectileExample.elevationAngle;
        m_ArcHandle.radius = projectileExample.impulse;

        // set the handle matrix so that angle extends upward from target's facing direction along ground
        Vector3 handleDirection = projectileExample.facingDirection;
        Vector3 handleNormal = Vector3.Cross(handleDirection, Vector3.up);
        // https://docs.unity3d.com/ScriptReference/Matrix4x4.TRS.html
        Matrix4x4 handleMatrix = Matrix4x4.TRS(
            projectileExample.transform.position,
            Quaternion.LookRotation(handleDirection, handleNormal),
            Vector3.one
        );

        using (new Handles.DrawingScope(handleMatrix))
        {
            // draw the handle
            EditorGUI.BeginChangeCheck();
            m_ArcHandle.DrawHandle();
            if (EditorGUI.EndChangeCheck())
            {
                // record the target object before setting new values so changes can be undone/redone
                Undo.RecordObject(projectileExample, "Change Projectile Properties");

                // copy the handle's updated data back to the target object
                projectileExample.elevationAngle = m_ArcHandle.angle;
                projectileExample.impulse = m_ArcHandle.radius;
            }
        }
    }
}

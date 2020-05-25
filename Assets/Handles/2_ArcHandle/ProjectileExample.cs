using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//https://docs.unity3d.com/ScriptReference/IMGUI.Controls.ArcHandle.html

public class ProjectileExample : MonoBehaviour
{
    public float elevationAngle { get { return m_ElevationAngle; } set { m_ElevationAngle = value; } }
    [SerializeField]
    float m_ElevationAngle = 45f;

    public float impulse { get { return m_Impulse; } set { m_Impulse = value; } }
    [SerializeField]
    float m_Impulse = 20f;

    public Vector3 facingDirection
    {
        get
        {
            Vector3 result = transform.forward;
            result.y = 0f;
            return result.sqrMagnitude == 0f ? Vector3.forward : result.normalized;
        }
    }

    protected virtual void Start()
    {
        GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        Vector3 direction = facingDirection;
        direction = Quaternion.AngleAxis(elevationAngle, Vector3.Cross(direction, Vector3.up)) * direction;
        ball.AddComponent<Rigidbody>().AddForce(direction * impulse, ForceMode.Impulse);
    }
}

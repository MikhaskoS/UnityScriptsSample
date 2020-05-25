using UnityEngine;


// https://docs.unity3d.com/ScriptReference/IMGUI.Controls.JointAngularLimitHandle.html
public class JointExample : MonoBehaviour
{
    public float xMin { get { return m_XMin; } set { m_XMin = value; } }
    [SerializeField]
    float m_XMin = -45f;

    public float xMax { get { return m_XMax; } set { m_XMax = value; } }
    [SerializeField]
    float m_XMax = 45f;

    public float yMax { get { return m_YMax; } set { m_YMax = value; } }
    [SerializeField]
    float m_YMax = 45f;

    public float zMax { get { return m_ZMax; } set { m_ZMax = value; } }
    [SerializeField]
    float m_ZMax = 45f;

    protected virtual void Start()
    {
        var joint = gameObject.AddComponent<CharacterJoint>();

        var limit = joint.lowTwistLimit;
        limit.limit = m_XMin;
        joint.lowTwistLimit = limit;

        limit = joint.highTwistLimit;
        limit.limit = m_XMax;
        joint.highTwistLimit = limit;

        limit = joint.swing1Limit;
        limit.limit = m_YMax;
        joint.swing1Limit = limit;

        limit = joint.swing2Limit;
        limit.limit = m_ZMax;
        joint.swing2Limit = limit;
    }
}

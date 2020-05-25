using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCastSample : MonoBehaviour
{
    [SerializeField] float m_MaxDistance = 300;
    [SerializeField] float m_Speed = 2;
    [SerializeField]  bool m_HitDetect = false;

    Collider m_Collider;
    RaycastHit m_Hit;

    void Start()
    {
        m_Collider = GetComponent<Collider>();
    }

    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal") * m_Speed;
        float zAxis = Input.GetAxis("Vertical") * m_Speed;
        transform.Translate(new Vector3(xAxis, 0, zAxis));
    }

    void FixedUpdate()
    {
        m_HitDetect = Physics.BoxCast(m_Collider.bounds.center,
            transform.localScale * 0.5f, transform.forward, out m_Hit, transform.rotation, m_MaxDistance);
       
        if (m_HitDetect)
        {
            Debug.Log("Hit : " + m_Hit.collider.name);
        }
    }

    void OnDrawGizmos()
    {
        if (m_HitDetect)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward * m_Hit.distance);
            Gizmos.DrawWireCube(transform.position + transform.forward * m_Hit.distance,
                transform.localScale);
        }
        else
        {
            Gizmos.color = Color.white;
            Gizmos.DrawRay(transform.position, transform.forward * m_MaxDistance);
            Gizmos.DrawWireCube(transform.position + transform.forward * m_MaxDistance,
                transform.localScale);
        }
    }
}

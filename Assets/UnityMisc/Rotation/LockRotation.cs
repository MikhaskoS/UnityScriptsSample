using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour
{
    [SerializeField] private Transform _target = null;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 directionToFace = _target.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(directionToFace);
        Debug.DrawRay(transform.position, directionToFace, Color.red);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
    }
}

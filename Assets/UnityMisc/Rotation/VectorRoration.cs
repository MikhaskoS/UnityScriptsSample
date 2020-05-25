using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorRoration : MonoBehaviour
{
    [SerializeField] Transform _originalA = null;
    [SerializeField] Transform _originalB = null;
    [SerializeField] float _angleX = 30;


    Vector3 rotator;
    Vector3 original;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    // поворот вектора на нужный угол
    private void OnDrawGizmos()
    {
        original = _originalB.position - _originalA.position;
        rotator = Quaternion.AngleAxis(_angleX, Vector3.up) * original;

        Debug.DrawLine(_originalA.position, _originalB.position);
        Debug.DrawLine(_originalA.position, _originalA.position + rotator, Color.red);
    }
}

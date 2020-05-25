using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] private float _areaRadius = 3;
    [SerializeField] private float _speed = 1;
    [SerializeField] private bool _showNodeHandles = false;

    [SerializeField] Vector3[] _nodePoints;
    [SerializeField] Quaternion[] _nodePointsRotation;



    public float AreaRadius { get => _areaRadius; set => _areaRadius = value; }
    public float Speed { get => _speed; set => _speed = value; }
    public Vector3[] NodePoints { get => _nodePoints; set => _nodePoints = value; }
    public Quaternion[] NodePointsRotation { get => _nodePointsRotation; set => _nodePointsRotation = value; }
    public bool ShowNodeHandles { get => _showNodeHandles; set => _showNodeHandles = value; }
}

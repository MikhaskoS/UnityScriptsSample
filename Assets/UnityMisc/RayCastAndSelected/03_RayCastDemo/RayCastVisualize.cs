using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RayCastVisualize : MonoBehaviour
{
    private enum TypeCast { Ray, Sphere }

    [SerializeField] TypeCast _typeCast = TypeCast.Ray;
    [SerializeField] Transform _start = null;
    [SerializeField] Transform _end = null;
    [SerializeField] LayerMask _hitLayers = 0;
    [SerializeField] float _radius = 0.5f;

    private Ray _ray = new Ray(Vector3.zero, Vector3.right);
    private RaycastHit _hit;

 

    private void Test()
    {
        _ray = new Ray(_start.position, _end.position - _start.position);
        switch (_typeCast)
        {
            case TypeCast.Ray:
                {
                    Physics.Raycast(_ray, out _hit, 
                        Vector3.Distance(_start.position, _end.position), _hitLayers);
                }
                break;
            case TypeCast.Sphere:
                {
                    Physics.SphereCast(_ray, _radius, out _hit, 
                        Vector3.Distance(_start.position, _end.position), _hitLayers);
                }
                break;
        }
    }

    void Update()
    {
        //Test();
    }

    private void OnDrawGizmos()
    {
        Test();

        switch (_typeCast)
        {
            case TypeCast.Ray:
                {
                    if (_hit.collider == null)
                        Debug.DrawLine(_start.position, _end.position, Color.white);
                    else
                        Debug.DrawLine(_start.position, _end.position, Color.red);

                    Debug.DrawRay(_ray.origin, _ray.direction, Color.red);
                }
                break;
            case TypeCast.Sphere:
                {
                    if (_hit.collider == null)
                        DrawWireCapsule(_start.position, _end.position, _radius, 
                        Vector3.Distance(_start.position, _end.position), Color.white);
                    else
                        DrawWireCapsule(_start.position, _end.position, _radius,
                       Vector3.Distance(_start.position, _end.position), Color.red);
                }
                break;
        }
    }

    #region Helpers

    public static void DrawWireCapsule(Vector3 _pos, Vector3 _pos2,
        float _radius, float _height, Color _color = default)
    {
        if (_color != default) Handles.color = _color;

        var forward = _pos2 - _pos;
        var _rot = Quaternion.LookRotation(forward);
        var pointOffset = _radius / 2f;
        var length = forward.magnitude;
        var center2 = new Vector3(0f, 0, length);

        Matrix4x4 angleMatrix = Matrix4x4.TRS(_pos, _rot, Handles.matrix.lossyScale);

        using (new Handles.DrawingScope(angleMatrix))
        {
            Handles.DrawWireDisc(Vector3.zero, Vector3.forward, _radius);
            Handles.DrawWireArc(Vector3.zero, Vector3.up, Vector3.left * pointOffset, -180f, _radius);
            Handles.DrawWireArc(Vector3.zero, Vector3.left, Vector3.down * pointOffset, -180f, _radius);
            Handles.DrawWireDisc(center2, Vector3.forward, _radius);
            Handles.DrawWireArc(center2, Vector3.up, Vector3.right * pointOffset, -180f, _radius);
            Handles.DrawWireArc(center2, Vector3.left, Vector3.up * pointOffset, -180f, _radius);

            DrawLine(_radius, 0f, length);
            DrawLine(-_radius, 0f, length);
            DrawLine(0f, _radius, length);
            DrawLine(0f, -_radius, length);
        }
    }

    private static void DrawLine(float arg1, float arg2, float forward)
    {
        Handles.DrawLine(new Vector3(arg1, arg2, 0f), new Vector3(arg1, arg2, forward));
    }

    #endregion
}

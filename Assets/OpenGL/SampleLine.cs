using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleLine : MonoBehaviour
{
    [SerializeField] Material _mat = null;
    [SerializeField] Transform[] _points = null;

    void OnRenderObject()
    {
        DrawLine();
    }

    private void DrawLine()
    {
         GL.PushMatrix(); 

        GL.Begin(GL.LINE_STRIP);
        _mat.SetPass(0);// Материал
        for(int i =0; i< _points.Length; i++)
            GL.Vertex(_points[i].position);
        GL.End();

        GL.PopMatrix();
    }

    private void OnDrawGizmos()
    {
        DrawLine();
    }
}

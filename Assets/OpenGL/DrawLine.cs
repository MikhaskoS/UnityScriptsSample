using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://qastack.ru/gamedev/96964/how-to-correctly-draw-a-line-in-unity
public class DrawLine : MonoBehaviour
{
    public Material lineMat;

    public GameObject mainPoint;
    public GameObject[] points;

    // Connect all of the `points` to the `mainPoint`
    void DrawConnectingLines()
    {
        if (mainPoint && points.Length > 0)
        {
            // Loop through each point to connect to the mainPoint
            foreach (GameObject point in points)
            {
                Vector3 mainPointPos = mainPoint.transform.position;
                Vector3 pointPos = point.transform.position;

                GL.Begin(GL.LINES);
                lineMat.SetPass(0);
                GL.Color(new Color(lineMat.color.r, lineMat.color.g, lineMat.color.b, lineMat.color.a));
                GL.Vertex3(mainPointPos.x, mainPointPos.y, mainPointPos.z);
                GL.Vertex3(pointPos.x, pointPos.y, pointPos.z);
                GL.End();
            }
        }
    }

    // To show the lines in the game window whne it is running
    // Работает, если прикрепить к камере!
    void OnPostRender()
    {
        DrawConnectingLines();
    }

    // To show the lines in the editor
    void OnDrawGizmos()
    {
        DrawConnectingLines();
    }
}

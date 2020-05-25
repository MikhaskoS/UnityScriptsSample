using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MkGame
{
    public class DetectVisObject : DetectedObject, ISelectable
    {
        Mesh _mesh;
        Vector3[] extentsCorners = new Vector3[8];
		UIVisor uiVisor;
		private bool _isVisible;
		Vector3 pos;

		private void Awake()
        {
            _mesh = GetComponent<MeshFilter>().mesh;
			uiVisor = FindObjectOfType<UIVisor>();
        }


		public void DrawArea()
		{
			Vector2 v = GetSizeOnScreen(_mesh, transform, out float x0, out float y0);
			uiVisor.SetPosition(x0 + v.x / 2, y0 + v.y / 2, 1.5f * v.x, 1.5f * v.y);
		}

		// границы меша
		private Vector2 GetSizeOnScreen(Mesh _mesh, Transform _transform, out float x0, out float y0)
		{
			Vector3 extents = _mesh.bounds.extents;
			extentsCorners[0] = extents;
			extentsCorners[1] = new Vector3(-extents.x, extents.y, extents.z);
			extentsCorners[2] = new Vector3(extents.x, -extents.y, extents.z);
			extentsCorners[3] = new Vector3(extents.x, extents.y, -extents.z);
			extentsCorners[4] = new Vector3(-extents.x, -extents.y, -extents.z);
			extentsCorners[5] = new Vector3(-extents.x, -extents.y, extents.z);
			extentsCorners[6] = new Vector3(-extents.x, extents.y, -extents.z);
			extentsCorners[7] = new Vector3(extents.x, -extents.y, -extents.z);


			for (int i = 0; i < 8; ++i)
			{
				extentsCorners[i] = 
					_transform.TransformPoint(_mesh.bounds.center + extentsCorners[i]);

				extentsCorners[i] = Camera.main.WorldToScreenPoint(extentsCorners[i]);
			}

			Vector3 min = extentsCorners[0];
			Vector3 max = extentsCorners[0];
			for (int i = 1; i < 8; ++i)
			{
				min = Vector3.Min(extentsCorners[i], min);
				max = Vector3.Max(extentsCorners[i], max);
			}

			x0 = min.x;
			y0 = min.y;
			return (new Vector3(max.x - min.x, max.y - min.y, 0f));
		}

	}
}

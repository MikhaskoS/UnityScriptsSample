using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditTransformWithCache2 : MonoBehaviour
{
	private bool _positionChanged;
	private Vector3 _newPosition;
	private new Transform transform;


	private void Awake()
	{
		transform = GetComponent<Transform>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			int numTests = 1_000_000_0;
			using (new CustomTimer("Edit Transform Without Cache", numTests))
			{
				for (int i = 0; i < numTests; ++i)
				{
					transform.position = new Vector3(i, 0, 0);
				}
				transform.position = new Vector3(0, 0, 0);
			}
		}
	}
}

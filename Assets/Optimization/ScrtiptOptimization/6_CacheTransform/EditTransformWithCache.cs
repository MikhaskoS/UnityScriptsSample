using UnityEngine;
using System.Collections;

public class EditTransformWithCache : MonoBehaviour {

	private bool _positionChanged;
	private Vector3 _newPosition;

	void Update() {
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			int numTests = 1_000_000_0;
			using (new CustomTimer("Edit Transform With Cache", numTests)) {
				for(int i = 0; i < numTests; ++i) {
					SetPosition (new Vector3(i, 0, 0));
				}
				SetPosition (new Vector3(0,0,0));
			}
		}
	}
	
	public void SetPosition(Vector3 position) {
		_newPosition = position;
		_positionChanged = true;
	}
	
	void FixedUpdate() {
		if (_positionChanged) {
			transform.position = _newPosition;
			_positionChanged = false;
		}
	}

}

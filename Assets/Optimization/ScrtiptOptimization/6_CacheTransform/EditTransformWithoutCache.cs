using UnityEngine;
using System.Collections;

public class EditTransformWithoutCache : MonoBehaviour {

	void Update() {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			int numTests = 1_000_000_0;
			using (new CustomTimer("Edit Transform Without Cache", numTests)) {
				for(int i = 0; i < numTests; ++i) {
					transform.position = new Vector3(i, 0, 0);
				}
				transform.position = new Vector3 (0,0,0);
			}
		}
	}
}

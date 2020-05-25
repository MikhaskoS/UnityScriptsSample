using UnityEngine;
using System.Collections;

public class NullReferenceTester : MonoBehaviour {

	void Update () {
		int numTests = 10000000;

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			using (new CustomTimer("Equality operator", numTests)) {
				for(int i = 0; i < numTests; ++i) {
					if (GetComponent<Transform>() == null) {

					}
				}
			}
		}

		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			using (new CustomTimer("System.Object.ReferenceEquals()", numTests)) {
				for(int i = 0; i < numTests; ++i) {
					if (System.Object.ReferenceEquals(GetComponent<Transform>(), null)) {

					}
				}
			}
		}
	}
}

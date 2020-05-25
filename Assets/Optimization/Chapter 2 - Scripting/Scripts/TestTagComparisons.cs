using UnityEngine;
using System.Collections;

public class TestTagComparisons : MonoBehaviour {

	void Update() {
		int numTests = 10000000;
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			using (new CustomTimer("Get .tag property", numTests)) {
				for(int i = 0; i < numTests; ++i) {
					if (gameObject.tag == "Player") {
						// do stuff
					}
				}
			}
		}
		
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			using (new CustomTimer("Using CompareTag()", numTests)) {
				for(int i = 0; i < numTests; ++i) {
					if (gameObject.CompareTag ("Player")) {
						// do stuff
					}
				}
			}
		}
	}

}

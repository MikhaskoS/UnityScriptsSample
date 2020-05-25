using UnityEngine;
using System.Collections;

public class SingletonAsComponentTester2 : MonoBehaviour {

	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			TestSingletonComponent.Instance.PrintMessage("This is COMPLETELY DIFFERENT message that is being sent to the Singleton Component");
		}
	}
}

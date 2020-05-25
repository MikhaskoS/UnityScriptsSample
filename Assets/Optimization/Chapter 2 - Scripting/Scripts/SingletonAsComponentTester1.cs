using UnityEngine;
using System.Collections;

public class SingletonAsComponentTester1 : MonoBehaviour {
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			TestSingletonComponent.Instance.PrintMessage("This is the message sent to the Singleton Component");
		}
	}
}

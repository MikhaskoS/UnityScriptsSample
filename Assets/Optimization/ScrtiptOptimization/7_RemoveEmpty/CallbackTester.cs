using UnityEngine;
using System.Collections;

public class CallbackTester : MonoBehaviour {

	[SerializeField] GameObject _callbackRoot = null;
	[SerializeField] GameObject _emptyRoot = null;

	void Update() {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			_callbackRoot.SetActive(!_callbackRoot.activeSelf);
		}

		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			_emptyRoot.SetActive(!_emptyRoot.activeSelf);
		}
	}
}

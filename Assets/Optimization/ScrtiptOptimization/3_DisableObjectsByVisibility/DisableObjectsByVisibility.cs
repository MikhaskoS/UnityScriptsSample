using UnityEngine;
using System.Collections;

public class DisableObjectsByVisibility : MonoBehaviour {

	[SerializeField] string _objectName = string.Empty;

	void OnBecameVisible() { 
		Debug.Log (string.Format ("{0} became visible", _objectName));
		enabled = true;
	}
	void OnBecameInvisible() { 
		Debug.Log (string.Format ("{0} became invisible", _objectName));
		enabled = false;
	}
}

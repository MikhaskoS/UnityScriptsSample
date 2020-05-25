using UnityEngine;
using System.Collections;

// Note: This code varies slightly from the code in the book. 
// This version disables an assigned object, rather than deactivating the Component.

public class DisableObjectsByDistance : MonoBehaviour {

	[SerializeField] GameObject _target = null;
	[SerializeField] float _maxDistance = 0;
	[SerializeField] int _coroutineFrequency = 0;
	[SerializeField] string _objectName = string.Empty;
	[SerializeField] GameObject _objectToDisable = null;
	
	void Start() {
		StartCoroutine(DisableAtADistance());
	}
	
	IEnumerator DisableAtADistance() {
		while(true) {
			float distSqrd = (transform.position - _target.transform.position).sqrMagnitude;
			

			if (distSqrd < _maxDistance * _maxDistance) {
				if (!_objectToDisable.activeSelf) {
					Debug.Log (string.Format ("{0} enabled", _objectName));
					_objectToDisable.SetActive(true);
				}
			} else {
				if (_objectToDisable.activeSelf) {
					Debug.Log (string.Format ("{0} disabled", _objectName));
					_objectToDisable.SetActive(false);
				}
			}
			
			for (int i = 0; i < _coroutineFrequency; ++i) {
				yield return new WaitForEndOfFrame();
			}
		}
	}

}

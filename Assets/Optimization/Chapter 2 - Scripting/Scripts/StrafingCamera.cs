using UnityEngine;
using System.Collections;

public class StrafingCamera : MonoBehaviour {

	[SerializeField] bool _allowForwardAndBackward = true;
	[SerializeField] bool _allowSideToSide = true;

	[SerializeField] float _speed = 0;

	void Update () {

		if (Input.GetKey(KeyCode.W)) {
			Vector3 pos = transform.position;
			pos += Vector3.forward * _speed * Time.deltaTime;
			transform.position = pos;
		}
		if (Input.GetKey(KeyCode.S)) {
			Vector3 pos = transform.position;
			pos -= Vector3.forward * _speed * Time.deltaTime;
			transform.position = pos;
		}

		if (Input.GetKey(KeyCode.A)) {
			Vector3 pos = transform.position;
			pos += Vector3.left * _speed * Time.deltaTime;
			transform.position = pos;
		}
		if (Input.GetKey(KeyCode.D)) {
			Vector3 pos = transform.position;
			pos += Vector3.right * _speed * Time.deltaTime;
			transform.position = pos;
		}
	}
}

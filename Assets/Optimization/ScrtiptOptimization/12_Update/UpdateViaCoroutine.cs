using UnityEngine;
using System.Collections;

public class UpdateViaCoroutine : AIControllerComponent {

	[SerializeField] float _aiUpdateFrequency = 0;

	void Start () {
		StartCoroutine(UpdateAI());
	}
	
	IEnumerator UpdateAI() {
		while (true) {
			yield return new WaitForSeconds(_aiUpdateFrequency);
			ProcessAI();
		}

	}
}

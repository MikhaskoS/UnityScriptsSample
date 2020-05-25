using UnityEngine;
using System.Collections;

public class UpdateViaInvokeRepeating : AIControllerComponent {

	[SerializeField] float _aiUpdateFrequency = 6;

	void Start() {
		// InvokeRepeating примерно в 1,5 раза медленнее обычной функции
		InvokeRepeating("ProcessAI", 0f, _aiUpdateFrequency);
	}
}

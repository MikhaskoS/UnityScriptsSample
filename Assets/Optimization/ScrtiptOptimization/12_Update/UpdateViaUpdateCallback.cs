using UnityEngine;
using System.Collections;

public class UpdateViaUpdateCallback : AIControllerComponent {

	[SerializeField] float _updateFrequency = 6;

	private float _timer;

	// искусственно созданный таймер
	// посмотри также сюда:  https://docs.unity3d.com/ScriptReference/Time-frameCount.html
	void Update () {
		_timer += Time.deltaTime;
		if (_timer > _updateFrequency) {
			_timer -= _updateFrequency;
			ProcessAI();
		}
	}

}

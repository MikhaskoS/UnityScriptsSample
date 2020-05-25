using UnityEngine;
using System.Collections;

public class TestMessageSender : MonoBehaviour {

	// tweak these values in the Inspector to change the contents of the message
	[SerializeField] [Range(0,100)] int _intVal = 0;
	[SerializeField] [Range(0f, 100f)] float _floatVal = 0;

	public void Update() {
		if (Input.GetKeyDown (KeyCode.Space)) {
			// Send a message through the event system of a particular type.
			// From this end, we really don't care where the message is eventually processed.
			// We only care that it has been sent out at the right time.
			MessagingSystem.Instance.QueueMessage(new MyCustomMessage(_intVal, _floatVal));			
		}
	}
}

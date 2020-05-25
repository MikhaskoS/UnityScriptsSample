using UnityEngine;
using System.Collections;

public class AIControllerComponent : MonoBehaviour {

	public void ProcessAI() {
		// Note: Really lazy string generation here. 
		// As per Chapter 7, we should never use operator+, nor 
		// the .name property to generate strings in real game code
		Debug.Log ("AI updated for " + gameObject.name);
	}

}

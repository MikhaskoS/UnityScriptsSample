using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader2 : MonoBehaviour {

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			SceneManager.LoadScene ("4.2-SingletonAsComponent1");
		}
	}
}

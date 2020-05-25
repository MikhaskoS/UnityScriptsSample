using UnityEngine;
using System.Collections;

public class TestSingletonComponent : SingletonAsComponent<TestSingletonComponent> {

	// boilerplate code to allow us to use the retrieve the property type by calling '.Instance'
	public static TestSingletonComponent Instance {
		get { return ((TestSingletonComponent)_Instance); } 
		set { _Instance = value; }
	}

	void Awake() {
		Debug.Log (this.GetType().Name + " initialized!");
	}
	
	public void PrintMessage (string msg) {
		Debug.Log (msg);
	}
}

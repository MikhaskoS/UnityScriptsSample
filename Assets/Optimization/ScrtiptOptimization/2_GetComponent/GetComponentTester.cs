using UnityEngine;
using System.Collections;

public class GetComponentTester : MonoBehaviour {

	void Update() {
		if (Input.GetKeyDown (KeyCode.Space)) {
			int numTests = 1000000;
			TestComponent test;
			
			using (new CustomTimer("GetComponent(string)", numTests)) {
				for (var i = 0; i < numTests; ++i)
				{
					test = (TestComponent)GetComponent("TestComponent");
				}
			}
			
			using (new CustomTimer("GetComponent<ComponentName>", numTests)) {
				for (var i = 0; i < numTests; ++i)
				{
					test = GetComponent<TestComponent>();
				}
			}
			
			using (new CustomTimer("GetComponent(typeof(ComponentName))", numTests))	{
				for (var i = 0; i < numTests; ++i)	{
					test = (TestComponent)GetComponent(typeof(TestComponent));
				}
			}

		}
	}
}

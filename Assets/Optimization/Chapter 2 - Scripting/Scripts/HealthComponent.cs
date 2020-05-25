using UnityEngine;
using System.Collections;

public class HealthComponent : MonoBehaviour {
	// dummy component used in CacheComponentReferences_Before/After

	private int _health = 10;
	public int health {
		get { return _health; }
		set { _health = value; }
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManagerComponent : MonoBehaviour {

	List<GameObject> _enemies = new List<GameObject>();

	public void AddEnemy(GameObject enemy) {
		_enemies.Add (enemy);
	}
	
	public void RollCall() {
		for(int i = 0; i < _enemies.Count; ++i) {
			Debug.Log (string.Format("Enemy \"{0}\" reporting in...", _enemies[i].name));
		}
	}
}

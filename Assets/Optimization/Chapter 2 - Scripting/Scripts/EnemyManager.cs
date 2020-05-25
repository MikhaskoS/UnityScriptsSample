using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class EnemyManager {
	static List<GameObject> _enemies;

	static EnemyManager() {
		_enemies = new List<GameObject>();
	}

	public static void AddEnemy(GameObject enemy) {
		_enemies.Add (enemy);
	}
	
	public static void RollCall() {
		for(int i = 0; i < _enemies.Count; ++i) {
			Debug.Log (string.Format("Enemy \"{0}\" reporting in...", _enemies[i].name));
		}
	}
}

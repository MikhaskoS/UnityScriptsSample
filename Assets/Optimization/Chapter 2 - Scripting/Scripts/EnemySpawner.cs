using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	[SerializeField] int _numEnemies = 0;
	[SerializeField] GameObject _enemyPrefab = null;

	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			SpawnEnemiesUnoptimized();
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			SpawnEnemiesOptimized();
		}
	}

	void SpawnEnemiesUnoptimized() {
		using (new CustomTimer("SpawnEnemies Unoptimized", _numEnemies)) {
			for(int i = 0; i < _numEnemies; ++i) {
				GameObject enemy = (GameObject)GameObject.Instantiate(_enemyPrefab, Vector3.zero, Quaternion.identity);
				GameObject enemyManagerObj = GameObject.Find("EnemyManager");
				enemyManagerObj.SendMessage("AddEnemy", enemy, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	void SpawnEnemiesOptimized() {
		using (new CustomTimer("SpawnEnemies Optimized", _numEnemies)) {
			GameObject enemyManagerObj = GameObject.Find("EnemyManager");
			EnemyManagerComponent enemyManager = enemyManagerObj.GetComponent<EnemyManagerComponent>();
			for(int i = 0; i < _numEnemies; ++i) {
				GameObject enemy = (GameObject)GameObject.Instantiate(_enemyPrefab, Vector3.zero, Quaternion.identity);

				enemyManager.AddEnemy(enemy);
			}
		}
	}
}

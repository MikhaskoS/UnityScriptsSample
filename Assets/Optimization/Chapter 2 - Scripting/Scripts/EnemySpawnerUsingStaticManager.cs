using UnityEngine;
using System.Collections;

public class EnemySpawnerUsingStaticManager : MonoBehaviour {

	// essentially the same as EnemySpawner, except it uses the static EnemyManager class instead

	[SerializeField] int _numEnemies = 0;
	[SerializeField] GameObject _enemyPrefab = null;
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			SpawnEnemies();
		}
	}
	
	void SpawnEnemies() {

		for(int i = 0; i < _numEnemies; ++i) {
			GameObject enemy = (GameObject)GameObject.Instantiate(_enemyPrefab, Vector3.zero, Quaternion.identity);

			// call straight to the EnemyManager static class
			EnemyManager.AddEnemy(enemy);		
		}
	}
}

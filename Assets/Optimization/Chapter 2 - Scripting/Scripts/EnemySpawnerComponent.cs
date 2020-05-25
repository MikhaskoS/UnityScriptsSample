using UnityEngine;


public class EnemySpawnerComponent : MonoBehaviour {
	
	[SerializeField] private int _numEnemies = 0;
	[SerializeField] private GameObject _enemyPrefab = null;
	[SerializeField] private EnemyManagerComponent _enemyManager = null;
	
	void Start() {
		SpawnEnemies(_numEnemies);
	}
	
	void SpawnEnemies(int _numEnemies) {
		for(int i = 0; i < _numEnemies; ++i) {
			GameObject enemy = (GameObject)GameObject.Instantiate(_enemyPrefab, Vector3.zero, Quaternion.identity);
			_enemyManager.AddEnemy(enemy);
		}
	}
}

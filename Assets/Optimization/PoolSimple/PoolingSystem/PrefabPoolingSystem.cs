using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabPoolingSystem : MonoBehaviour
{
    public static PrefabPoolingSystem Instante;
    private void Awake()
    {
        Instante = this;
    }

     Dictionary<GameObject, PrefabPool> _prefabToPoolMap = 
        new Dictionary<GameObject, PrefabPool>(); 

     Dictionary<GameObject, PrefabPool> _goToPoolMap = 
        new Dictionary<GameObject, PrefabPool>();

    public  GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        if (!_prefabToPoolMap.ContainsKey(prefab)) 
        { 
            _prefabToPoolMap.Add(prefab, new PrefabPool()); 
        } 
        PrefabPool pool = _prefabToPoolMap[prefab]; 
        GameObject go = pool.Spawn(prefab, position, rotation); 
        _goToPoolMap.Add(go, pool);
        return go; 
    }
    public  GameObject Spawn(GameObject prefab)
    { 
        return Spawn(prefab, Vector3.zero, Quaternion.identity); 
    }

    public  bool Despawn(GameObject obj) 
    { 
        if (!_goToPoolMap.ContainsKey(obj)) 
        { 
            Debug.LogError(string.Format("Object {0} not managed by pool system!", obj.name));
            return false; 
        }
        PrefabPool pool = _goToPoolMap[obj]; 
        if (pool.Despawn(obj))
        { 
            _goToPoolMap.Remove(obj); 
            return true;
        } 
        return false;
    }

    //  Создает N экземпляров, а затем сразу же деактивирует их
    //  вызывается во время инициализации объекта (напр в Start())
    public  void Prespawn(GameObject prefab, int numToSpawn)
    { 
        List<GameObject> spawnedObjects = new List<GameObject>(); 
        for (int i = 0; i < numToSpawn; i++)
        { 
            spawnedObjects.Add(Spawn(prefab)); 
        }
        for (int i = 0; i < numToSpawn; i++)
        { 
            Despawn(spawnedObjects[i]); 
        } 
        spawnedObjects.Clear();
    }

    public void Reset() 
    { 
        _prefabToPoolMap.Clear();
        _goToPoolMap.Clear();
    }
} 


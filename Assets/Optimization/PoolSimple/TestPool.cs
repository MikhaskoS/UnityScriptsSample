using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPool : MonoBehaviour
{
    [SerializeField] GameObject _prefab1 = null;
    [SerializeField] GameObject _prefab2 = null;
    [SerializeField] GameObject _prefab3 =  null;

    List<GameObject> _go1 = new List<GameObject>(); 
    List<GameObject> _go2 = new List<GameObject>();
    List<GameObject> _go3 = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        PrefabPoolingSystem.Instante.Prespawn(_prefab1, 5);
        PrefabPoolingSystem.Instante.Prespawn(_prefab2, 5);
        PrefabPoolingSystem.Instante.Prespawn(_prefab3, 5);
    }

    void Update() 
    { 
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            SpawnObject(_prefab1, _go1); 
        } 
        if (Input.GetKeyDown(KeyCode.Alpha2))
        { 
            SpawnObject(_prefab2, _go2);
        } 
        if (Input.GetKeyDown(KeyCode.Alpha3))
        { 
            SpawnObject(_prefab3, _go3); 
        } 
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            DespawnRandomObject(_go1); 
        } 
        if (Input.GetKeyDown(KeyCode.W)) 
        {
            DespawnRandomObject(_go2);
        } 
        if (Input.GetKeyDown(KeyCode.E))
        { 
            DespawnRandomObject(_go3);
        } 
    }
    void SpawnObject(GameObject prefab, List<GameObject> list)
    { 
        GameObject obj = PrefabPoolingSystem.Instante.Spawn(prefab, Random.insideUnitSphere * 8f, Quaternion.identity);
        list.Add(obj);
    }
    void DespawnRandomObject(List<GameObject> list)
    {
        if (list.Count == 0)
        {            
            // Нет объектов для деактивации         
            return;
        }
        int i = Random.Range(0, list.Count); 
        PrefabPoolingSystem.Instante.Despawn(list[i]);
        list.RemoveAt(i);
    }
}

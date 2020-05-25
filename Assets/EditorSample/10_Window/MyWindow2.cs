using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MyWindow2 : EditorWindow
{
    public GameObject ObjectInstantiate;
    private string _nameObject = "Hello World";
    private bool _groupEnabled;
    private bool _randomColor = true;
    private int _countObject = 1;
    private float _radius = 10;
    
    Color[] _colors = new Color[]
    {
        Color.green, Color.black, Color.blue, Color.clear, Color.cyan,
        Color.red, Color.yellow, Color.white,
        Color.red
    };

    [MenuItem("MkGame/My First Window")]
    public static void ShowWindow()
    {
        // Отобразить существующий экземпляр окна. Если его нет, создаем
        EditorWindow.GetWindow(typeof(MyWindow2));
    }

    void OnGUI()
    {
        // Здесь методы отрисовки схожи с методами в пользовательском
        // интерфейсе, который вы разрабатывали на курсе “Unity3D.Уровень 1”
        
        GUILayout.Label("Базовые настройки", EditorStyles.boldLabel);

        ObjectInstantiate =  
            EditorGUILayout.ObjectField("Объект который хотим вставить",ObjectInstantiate, typeof(GameObject), true)
            as GameObject;
        
        _nameObject = EditorGUILayout.TextField("Имя объекта", _nameObject);
        _groupEnabled = EditorGUILayout.BeginToggleGroup("Дополнительные настройки", _groupEnabled);
        _randomColor = EditorGUILayout.Toggle("Случайный цвет", _randomColor);
        _countObject = EditorGUILayout.IntSlider("Количество объектов",  _countObject, 1, 100);
        _radius = EditorGUILayout.Slider("Радиус окружности", _radius, 10,  50);
       
        EditorGUILayout.EndToggleGroup();
        if (GUILayout.Button("Создать объекты"))
        {
            if (ObjectInstantiate)
            {
                GameObject root = new GameObject("Root");
                for (int i = 0; i < _countObject; i++) // Расставляем   выбранный объект по окружности
{
                    float angle = i * Mathf.PI * 2 / _countObject;
                    Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * _radius;
                    GameObject temp = Instantiate(ObjectInstantiate, pos, Quaternion.identity) as GameObject;
                    temp.name = _nameObject + "(" + i + ")";
                    temp.transform.parent = root.transform;

                    if (temp.GetComponent<Renderer>() && _randomColor)
                    {
                        temp.GetComponent<Renderer>().material.color =
                        _colors[Random.Range(0, _colors.Length - 1)];
                        // Unity предупреждает о возможной утечке памяти и  предлагает использовать sharedMaterial
                    }
                }
            }
        }
    }
}

        

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Этот объект создается из Asset/MkGame/HP Data  !!!
// Изменение свойств этого объекта автоматически передается в нужные места !!!

// order: место размещения ассета в Asset Menu. Unity разделяет ассеты на подгруппы с множителем 50. 
// То есть значение 51 поместит новый ассет во вторую группу Asset Menu.
[CreateAssetMenu(fileName = "New HP", menuName = "MkGame/HP Data", order = 51)]
public class HP : ScriptableObject
{
    [SerializeField] 
    int _intValue;

    [SerializeField]
    private string _description;

    public int IntValue { get => _intValue; set => _intValue = value; }
    public string Description { get => _description; set => _description = value; }
}

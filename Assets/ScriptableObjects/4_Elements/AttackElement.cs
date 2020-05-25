using System.Collections.Generic;
using UnityEngine;

namespace MkGame
{
    // Элемент содержит список объектов, с которыми должен взаимодействовать
    [CreateAssetMenu]
    public class AttackElement : ScriptableObject
    {
        [Tooltip("The elements that are defeated by this element.")]
        public List<AttackElement> DefeatedElements = new List<AttackElement>();
    }
}
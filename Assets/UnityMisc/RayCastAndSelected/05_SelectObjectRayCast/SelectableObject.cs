using MkGame;
using UnityEngine;


namespace MkGame
{
    public class SelectableObject : MonoBehaviour, ISelectable
    {
        public string GetMessage()
        {
            return name;
        }
    }
}

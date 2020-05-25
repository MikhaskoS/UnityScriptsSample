using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://habr.com/ru/post/421523/
[CreateAssetMenu(fileName = "New Game Event", menuName = "MkGame/Game Event", order = 55)] 
public class GameEvent : ScriptableObject 
{
    private List<GameEventListener> listeners = new List<GameEventListener>(); 

    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--) 
        {
            listeners[i].OnEventRaised(); 
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener) 
    {
        listeners.Remove(listener);
    }
}

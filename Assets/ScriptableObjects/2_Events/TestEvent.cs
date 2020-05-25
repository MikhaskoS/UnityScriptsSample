using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEvent : MonoBehaviour
{
    [SerializeField] GameEvent OnCube = null;

    private void OnMouseDown()
    {
        OnCube.Raise(); 
    }
}

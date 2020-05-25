using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestUI : MonoBehaviour
{
    private Text _demo;
    int k = 0;

    private void Awake()
    {
        _demo = GetComponent<Text>();
    }

    public void OnClickMouse()
    {
        _demo.text = $"You clicked: {k}";
        k++;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISlider : MonoBehaviour
{
    private Slider _slider;
    [SerializeField] private HP _hP = null;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.minValue = 0;
        _slider.maxValue = 100;
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(val => ChangeValue(val));
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(val => ChangeValue(val));
    }

    private void ChangeValue(float value)
    { 

    }

    private void Update()
    {
        _slider.value = _hP.IntValue;
    }
}

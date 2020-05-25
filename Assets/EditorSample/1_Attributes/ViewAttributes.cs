using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewAttributes : MonoBehaviour
{
    [HideInInspector] 
    public int HideVariable = 0;

    [SerializeField]  
    private int SerializeVariable = 0;

    [Header("Header text")]
    public int HeaderVariable = 0;

    [Range(10, 30)]
    public int RangeVariable = 15;

    [Space(20)]
    public int SpaceVariable = 123;

    [Multiline(5)]
    public string MultilineVariable;

    [TextArea(3, 5)]
    public string TextAreaVariable;

    [Tooltip("Tooltip text")]
    public int ToolTipVariable = 0;

    private void Start()
    {
        SerializeVariable = SerializeVariable++;
    }
}

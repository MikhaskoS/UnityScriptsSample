using UnityEngine;
using System.Collections;


[System.Serializable]
public class ClassWithProperties : System.Object
{
	private int myIntProperty;
	private float myFloatProperty;
	private Color myColorProperty;


	public int MyIntProperty
	{
		get{return myIntProperty;}
		set{if(value <= 10)myIntProperty = value;else myIntProperty=0;}
	}

	public float MyFloatProperty
	{
		get{return myFloatProperty;}
		set{myFloatProperty = value;}
	}

	public Color MyColorProperty
	{
		get{return myColorProperty;}
		set{myColorProperty = value;}
	}
	
}
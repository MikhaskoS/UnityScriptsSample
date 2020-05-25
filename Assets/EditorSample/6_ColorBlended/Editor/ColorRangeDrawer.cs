using UnityEngine;
using UnityEditor;
using System.Collections;


[CustomPropertyDrawer(typeof(ColorRangeAttribute))]
public class ColorRangeDrawer : PropertyDrawer
{
	//Event called by Unity Editor for updating GUI drawing of controls
	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
	{
		//Get color range attribute meta data
		ColorRangeAttribute range  = attribute as ColorRangeAttribute;

		//Add label to inspector
		//https://docs.unity3d.com/ScriptReference/EditorGUI.html
		position = EditorGUI.PrefixLabel (position, new GUIContent ("Color Lerp"));

		//Define sizes for color rect and slider controls
		Rect ColorSamplerRect = new Rect(position.x, position.y, 100, position.height);
		Rect SliderRect = new Rect(position.x+105, position.y, 150, position.height);

		//Show color rect control
		EditorGUI.ColorField(ColorSamplerRect, property.FindPropertyRelative("BlendedColor").colorValue);

		//Show slider control
		property.FindPropertyRelative("BlendFactor").floatValue = 
			EditorGUI.Slider(SliderRect, property.FindPropertyRelative("BlendFactor").floatValue, 0f, 1f);

		//Update blended color based on slider
		property.FindPropertyRelative("BlendedColor").colorValue = 
			Color.Lerp(range.Min, range.Max, property.FindPropertyRelative("BlendFactor").floatValue);
	}
}
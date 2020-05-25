using UnityEngine;
using UnityEditor;
using System.Reflection;


// https://docs.unity3d.com/ScriptReference/PropertyDrawer.html
[CustomPropertyDrawer(typeof(ClassWithProperties))]
public class ClassWithPropertiesEditor : PropertyDrawer
{
	
	float InspectorHeight = 0; 
	float RowHeight = 25;
	float RowSpacing = 5;

	// Draw the property inside the given rect
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) 
	{
		EditorGUI.BeginProperty(position, label, property);

		// Получить объект по ссылке
		object o = property.serializedObject.targetObject;
		ClassWithProperties CP = o.GetType().GetField(property.name).GetValue(o) as ClassWithProperties;

		int indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;

		Rect LayoutRect = new Rect(position.x, position.y, position.width, RowHeight);

		// Найти все свойства объекта
		foreach(var prop in typeof(ClassWithProperties).GetProperties(BindingFlags.Public | BindingFlags.Instance))
		{
			//If integer property
			if(prop.PropertyType.Equals(typeof(int)))
			{
				prop.SetValue(CP, EditorGUI.IntField(LayoutRect, prop.Name, (int)prop.GetValue(CP,null)), null);
				LayoutRect = new Rect(LayoutRect.x, LayoutRect.y + RowHeight+RowSpacing, LayoutRect.width, RowHeight);
			}

			//If float property
			if(prop.PropertyType.Equals(typeof(float)))
			{
				prop.SetValue(CP, EditorGUI.FloatField(LayoutRect, prop.Name, (float)prop.GetValue(CP,null)), null);
				LayoutRect = new Rect(LayoutRect.x, LayoutRect.y + RowHeight+RowSpacing, LayoutRect.width, RowHeight);
			}

			//If color property
			if(prop.PropertyType.Equals(typeof(Color)))
			{
				prop.SetValue(CP, EditorGUI.ColorField(LayoutRect, prop.Name, (Color)prop.GetValue(CP,null)), null);
				LayoutRect = new Rect(LayoutRect.x, LayoutRect.y + RowHeight+RowSpacing, LayoutRect.width, RowHeight);
			}
		}

		//Update inspector height
		InspectorHeight = LayoutRect.y-position.y;

		EditorGUI.indentLevel = indent;
		EditorGUI.EndProperty();
	}

	//----------------------------------------------
	// Эта функция возвращает, какая высота (в пикселях) у поля 
	// Это делается для того, чтобы убедиться, что элементы управления графического 
	// интерфейса не будут перекрывать или перегружать элементы управления ниже
	public override float GetPropertyHeight (SerializedProperty property, GUIContent label)
	{
		return InspectorHeight;
	}
}
using UnityEditor;
using UnityEngine;
using static UnitModify;


[CustomEditor(typeof(UnitModify))]
public class UnitModifyTditor : Editor
{
    public override void OnInspectorGUI()
    {
        GUILayout.Label("Hello inspector");

        UnitModify unit = target as UnitModify;

        GUILayout.BeginHorizontal();
        unit.icon = EditorGUILayout.ObjectField(unit.icon, typeof(Sprite), false, GUILayout.Width(50), GUILayout.Height(50)) as Sprite;
        unit.description = EditorGUILayout.TextArea(unit.description, GUILayout.Height(50));
        GUILayout.EndHorizontal();

        string text = "Мин.здоровья: ";
        unit.minHealth = EditorGUILayout.Slider(text, unit.minHealth, 0, unit.maxHealth);
        text = "Мак.здоровья: ";
        unit.maxHealth = EditorGUILayout.Slider(text, unit.maxHealth, unit.minHealth, 1000);

        text = "Включить дальнобойность: ";
        unit.rangedUnit = EditorGUILayout.BeginToggleGroup(text, unit.rangedUnit);
        text = "Радиус атаки: ";
        unit.rangeAttack = EditorGUILayout.IntSlider(text, unit.rangeAttack, 100, 1000);
        EditorGUILayout.EndToggleGroup();

        text = "Тип атаки: ";
        unit.type = (AttackType)EditorGUILayout.EnumFlagsField(text, unit.type);

        text = "Кол - во урона: ";
        unit.damage = EditorGUILayout.FloatField(text, unit.damage);
    }
}


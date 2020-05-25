using UnityEditor;
using UnityEngine;

namespace Geekbrains.Editor.Test
{
	[CustomEditor(typeof(TestBehaviour))]
	public class TestBehaviourEditor : UnityEditor.Editor
	{
		private bool _isPressButtonOk;

		public override void OnInspectorGUI()
		{
			// отрисовка по умолчанию:
			//DrawDefaultInspector();

			TestBehaviour testTarget = (TestBehaviour)target;

			EditorGUILayout.HelpBox("Количество", MessageType.Info);
			testTarget.count = EditorGUILayout.IntSlider(testTarget.count, 10, 50);
			EditorGUILayout.HelpBox("Смещение", MessageType.Info);
			testTarget.offset = EditorGUILayout.IntSlider(testTarget.offset, 1, 5);

			testTarget.obj =
				EditorGUILayout.ObjectField("Объект для вставки: ",
						testTarget.obj, typeof(GameObject), false)
					as GameObject;

			var isPressButton = GUILayout.Button("Разместить!",
				EditorStyles.miniButtonLeft);

			_isPressButtonOk = GUILayout.Toggle(_isPressButtonOk, "Ok");

			if (isPressButton)
			{
				testTarget.CreateObj();
				_isPressButtonOk = true;
			}

			if (_isPressButtonOk) // отображается при влюченном Toggle
			{
				testTarget.Test = EditorGUILayout.Slider(testTarget.Test, 10, 50);
				EditorGUILayout.HelpBox("Вы нажали на кнопку", MessageType.Warning);

				var isPressAddButton = GUILayout.Button("Add Com",
					EditorStyles.miniButtonLeft);
				if (isPressAddButton)
				{
					testTarget.AddComponent();
				}
				if (GUILayout.Button("Rem Com",
					EditorStyles.miniButtonLeft))
				{
					testTarget.RemoveComponent();
				}
			}
		}
	}

}
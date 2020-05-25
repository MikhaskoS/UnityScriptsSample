using UnityEngine;
using UnityEditor;
using System.Collections;

/* Создается меню. Выводится диалоговое окно.
 Выделенные объекты можно переименовать. */

// https://docs.unity3d.com/ScriptReference/ScriptableWizard.html
public class BatchRename : ScriptableWizard
{
	public string BaseName = "MyObject_";
	public int StartNumber = 0;
	public int Increment = 1;
	
	[MenuItem("MkGame/Scriptable Wizard/Batch Rename...")]
    static void CreateWizard()
    {
		// Отображение окна из меню
        ScriptableWizard.DisplayWizard("Batch Rename",typeof(BatchRename),"Rename");
    }

	void OnEnable()
	{
		UpdateSelectionHelper();
	}

	void OnSelectionChange()
	{
		UpdateSelectionHelper();
	}

	void UpdateSelectionHelper()
	{
		helpString = "";
		
		if (Selection.objects != null)
			helpString = "Number of objects selected: " + Selection.objects.Length;
	}

	void OnWizardCreate()
	{
		if (Selection.objects == null)
			return;
		
		int PostFix = StartNumber;
		
		foreach(Object O in Selection.objects)
		{
			O.name = BaseName + PostFix;
			PostFix += Increment;
		}
	}
}

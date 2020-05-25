using UnityEditor;
using UnityEngine;


public class CreateLight : ScriptableWizard
{
    public float range = 500;
    public Color color = Color.red;

    [MenuItem("MkGame/Scriptable Wizard/Create Light...")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard<CreateLight>("Create Light", "Create", "Apply");

        // Если вы не хотите использовать кнопку Apply
        //ScriptableWizard.DisplayWizard<WizardCreateLight>("Create Light", "Create");
    }

    // при нажатии кнопки "Create"
    void OnWizardCreate()
    {
        GameObject go = new GameObject("New Light");
        Light lt = go.AddComponent<Light>();
        lt.range = range;
        lt.color = color;
    }

    void OnWizardUpdate()
    {
        helpString = "Please set the color of the light!";
    }

  
    // при наатии другой кнопки ("Apply")
    void OnWizardOtherButton()
    {
        if (Selection.activeTransform != null)
        {
            Light lt = Selection.activeTransform.GetComponent<Light>();

            if (lt != null)
            {
                lt.color = color;
            }
        }
    }
}

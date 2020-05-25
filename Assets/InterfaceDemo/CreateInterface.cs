using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateInterface : MonoBehaviour
{
    #region Editor
    /// <summary>
    /// Создание главного меню
    /// </summary>
    public void CreateMainMenu()
    {
        CreateComponent();
        Clear();
    }
    /// <summary>
    /// Создание игрового UI
    /// </summary>
    public void CreateGameMenu()
    {
        CreateComponent();
        gameObject.AddComponent<MainMenu>();
        Clear();
    }
    private void Clear()
    {
        DestroyImmediate(this);
    }
    private void CreateComponent()
    {
    }
    #endregion

}

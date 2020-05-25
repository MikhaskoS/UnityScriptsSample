using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsUnity : MonoBehaviour
{
    //---------------------------------------------------------
    //                   EDITOR
    //---------------------------------------------------------
    // Срабатывает в момент присоединения скрипта к объекту
    private void Reset() => Debug.Log("Reset...");
    //---------------------------------------------------------

    //---------------------------------------------------------
    //                   ИНИЦИАЛИЗАЦИЯ
    //---------------------------------------------------------

    // Срабатывает, даже если объект в сцене выключен
    private void Awake() => Debug.Log("Awake...");
    private void OnEnable() => Debug.Log("Enable...");
    void Start() => Debug.Log("Start...");



    //---------------------------------------------------------
    //                   ЛОГИКА ИГРы
    //---------------------------------------------------------
    void Update()
    {

    }
    // Работает по таймеру (deltaTime не нужен )
    private void FixedUpdate()
    {

    }

    private void LateUpdate()
    {
        
    }

    #region Render

    private void OnWillRenderObject()
    {
        
    }
    private void OnPreCull()
    {
        
    }

    private void OnBecameVisible()
    {
        
    }

    private void OnBecameInvisible()
    {
        
    }

    private void OnPreRender()
    {
        
    }

    private void OnRenderObject()
    {
        
    }

    private void OnPostRender()
    {
        
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        
    }

    #endregion

    #region Gizmo
    
    private void OnDrawGizmos()
    {
        
    }

    #endregion

    #region GUI

    private void OnGUI()
    {
        
    }

    #endregion

    private void OnApplicationPause(bool pause)
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void OnApplicationQuit()
    {
        
    }

    private void OnDestroy()
    {
        
    }
}

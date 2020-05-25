using MkGame;
using System;
using UnityEngine;

public class DetectedObject : MonoBehaviour, ISelectable
{
    Vector3 pos;
    bool _isVisible;
    [SerializeField] float _aiUpdateFrequency = 0.6f;

    public static  event Action<GameObject> detectAction;

    private void Start()
    {
        // Функция медленная, но может существенно скратить число расчетов
        // см пример с оптимизацией Update. Там же примеры, как можно
        // иначе оптимизировать
        InvokeRepeating("CursorDetected", 0.0f, _aiUpdateFrequency);
    }


    public string GetMessage()
    {
        return name;
    }

    protected virtual bool CameraDetected()
    {
        if (!_isVisible) return false;

        pos = Camera.main.WorldToScreenPoint(transform.position);

        float posX = Camera.main.pixelWidth / 2;
        float posY = Camera.main.pixelHeight / 2;

        if (pos.x < posX + 50 && pos.x > posX - 50 && pos.y < posY + 50 && pos.y > posY - 50)
        {
            Debug.Log("Camera Detect!!!");
            return true;
        }

        return false;
    }

    protected virtual bool CursorDetected()
    {
        if (!_isVisible) return false;

        Vector3 point = Input.mousePosition;

        pos = Camera.main.WorldToScreenPoint(transform.position);

        if (pos.x < point.x + 50 && pos.x > point.x - 50 && pos.y < point.y + 50 && pos.y > point.y - 50)
        {
            Debug.Log("Cursor Detect!!!");
            detectAction?.Invoke(gameObject);
            return true;
        }

        return false;
    }


    // вычисления не нужны. Важно - камера сцены тоже не должна видеть объекты
    // (развернуть ее так, чтобы игровые объекты не попадали в поле видимости)
    private void OnBecameInvisible()
    {
        _isVisible = false;
    }

    private void OnBecameVisible()
    {
        _isVisible = true;
    }
}

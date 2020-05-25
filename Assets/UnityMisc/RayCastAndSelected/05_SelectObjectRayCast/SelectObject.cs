using MkGame;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    private Camera _camera;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private GameObject _dedicatedObj;
    private ISelectable _selectedObj;

    private void Awake()
    {
        _camera = Camera.main;
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    void Update()
    {
        Vector3 point = Input.mousePosition;
        Ray ray = _camera.ScreenPointToRay(point);

        if (Physics.Raycast(ray, out RaycastHit hit ))
        {
            Select(hit.collider.gameObject);
        }
    }

    private void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 4;

        GUI.Label(new Rect(posX, posY, size, size), "*");
    }


    private void Select(GameObject obj)
    {
        if (obj == _dedicatedObj) return;
        _selectedObj = obj.GetComponent<ISelectable>();

        if (_selectedObj != null)
        {
            Debug.Log(_selectedObj.GetMessage());
        }
        else
        {
            Debug.Log("---");
        }

        _dedicatedObj = obj;
    }
}

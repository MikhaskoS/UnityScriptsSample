using System.Collections;
using UnityEngine;


public class RayCastMousePos : MonoBehaviour
{
    private Camera _camera;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private void Awake()
    {
        _camera = Camera.main;
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = Input.mousePosition;   // <--
            Ray ray = _camera.ScreenPointToRay(point);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log($"Hit {hit.point }");
                StartCoroutine(CreateSphere(hit.point));
            }
        }
    }

    private void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 4;

        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    private IEnumerator CreateSphere(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }
}

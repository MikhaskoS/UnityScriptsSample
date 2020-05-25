using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *   Определение центра экрана и проброс луча из центра.
 */
public class RayCast : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
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

using UnityEngine;


namespace MkGame
{
    public class SelectObjInArea : MonoBehaviour
    {
        private Camera _camera;
        public Texture2D cursorTexture;
        public CursorMode cursorMode = CursorMode.Auto;
        public Vector2 hotSpot = Vector2.zero;

        private GameObject _dedicatedObj;
        private ISelectable _selectedObj;

        UIDemo uiDemo;

        private void Awake()
        {
            _camera = Camera.main;
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            uiDemo = FindObjectOfType<UIDemo>();
        }

        private void OnEnable()
        {
            DetectedObject.detectAction += DetectedObject_detectAction;
        }

        private void OnDisable()
        {
            DetectedObject.detectAction -= DetectedObject_detectAction;
        }

        private void DetectedObject_detectAction(GameObject obj)
        {
            uiDemo.Text4 = obj.GetComponent<ISelectable>().GetMessage();

            if (obj.GetComponent<DetectVisObject>() != null)
            {
                obj.GetComponent<DetectVisObject>().DrawArea();
            }
        }

        void Update()
        {
            // координаты мыши в координатах экрана 
            // (0,0) - левый нижний угол
            Vector3 point = Input.mousePosition;
            
            uiDemo.Text1 = $"Screen:  x = {point.x} y = {point.y}";
            
            
            Vector3 point_world = _camera.ScreenToWorldPoint(point);
            uiDemo.Text2 = $"World:  x = {point_world.x} y = {point_world.y}";
        }

        private void OnGUI()
        {
            int size = 12;
            float posX = _camera.pixelWidth / 2 - size / 4;
            float posY = _camera.pixelHeight / 2 - size / 4;

            GUI.Label(new Rect(posX, posY, size, size), "*");

            //--------------------------------------------------------
            Vector3 point = new Vector3();
            Event currentEvent = Event.current;
            Vector2 mousePos = new Vector2();

            mousePos.x = currentEvent.mousePosition.x;
            mousePos.y = _camera.pixelHeight - currentEvent.mousePosition.y;

            point = _camera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, _camera.nearClipPlane));
            uiDemo.Text3 = $"Screen:  x = {point.x} y = {point.y}";
            //--------------------------------------------------------
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
}

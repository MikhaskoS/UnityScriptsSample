using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MkGame
{
    public class UIVisor : MonoBehaviour
    {

        Image image;
        RectTransform rectTransform;

        private void Awake()
        {
            image = GetComponent<Image>();
            rectTransform = GetComponent<RectTransform>();
        }

        public void SetPosition(float x0, float y0, float width, float height)
        {
            rectTransform.position = new Vector3(x0, y0, 0);
            rectTransform.sizeDelta = new Vector2(width, height);
        }
    }
}
